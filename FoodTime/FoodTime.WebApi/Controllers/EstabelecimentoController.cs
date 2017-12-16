using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FoodTime.WebApi.Models;

namespace FoodTime.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/estabelecimento")]
    public class EstabelecimentoController : ApiController
    {
        IFoodTimeContext context;

        public EstabelecimentoController()
        {
            context = new FoodTimeContext();
        }

        [HttpPost]
        public IHttpActionResult CriarEstabelecimento([FromBody] EstabelecimentoRegistroModel estabelecimentoModel)
        {
            context.Enderecos.Add(estabelecimentoModel.Endereco);
            context.SaveChanges();
            Endereco endereco = context.Enderecos.OrderByDescending(x => x.Id).FirstOrDefault();
            List<Categoria> categorias = new List<Categoria>();
            List<Foto> fotos = new List<Foto>();
            foreach (int idCategoria in estabelecimentoModel.IdCategorias)
            {
                categorias.Add(context.Categorias.FirstOrDefault(x => x.Id == idCategoria));
            }
            Estabelecimento estabelecimento = new Estabelecimento(estabelecimentoModel.Nome,
                estabelecimentoModel.Telefone,
                endereco,
                categorias,
                estabelecimentoModel.HorarioAbertura,
                estabelecimentoModel.HorarioFechamento,
                estabelecimentoModel.PrecoMedio,
                fotos,
                estabelecimentoModel.Aprovado
                );
            foreach (int idPreferencia in estabelecimentoModel.IdPreferencias)
            {
                var preferencia = context.Preferencias.FirstOrDefault(x => x.Id == idPreferencia);
                if (preferencia == null)
                {
                    return BadRequest("Preferencia nao encontrada");
                }
                context.EstabelecimentoPreferencias.Add(new EstabelecimentoPreferencia(estabelecimento, preferencia, true));
            }
            context.Estabelecimentos.Add(estabelecimento);
            context.SaveChanges();
            foreach (string foto in estabelecimentoModel.Fotos)
            {
                fotos.Add(new Foto(foto));
            }
            context.SaveChanges();
            return Created("Sucesso", estabelecimento);
        }

        [HttpGet, Route("recomendacao")]
        public IHttpActionResult BuscarRecomendacoes(int idUsuario, decimal latitude, decimal longitude)
        {
            List<Estabelecimento> estabelecimentos = new List<Estabelecimento>();
            var retorno = ConferirEstabRecomendados(idUsuario, out estabelecimentos); //atribui estabelecimentos abertos, aprovados e nao recusados, e retorna mensagem de erro caso nao encontre
            if(retorno != null)
            {
                return BadRequest(retorno);
            }
            List<EstabelecimentoRecomendacaoModel> estabelecimentosRecomendados = new List<EstabelecimentoRecomendacaoModel>();
            var usuario = context.Usuarios.Include(x => x.Preferencias).AsNoTracking().FirstOrDefault(x => x.Id == idUsuario);
            var numPreferencias = usuario.Preferencias.Count();
            foreach (Estabelecimento estabelecimento in estabelecimentos)
            {
                var estabelecimentoRecomendado = new EstabelecimentoRecomendacaoModel(estabelecimento);
                var EstabelecimentoPreferencias = context.EstabelecimentoPreferencias.Include(x => x.Preferencia).Include(x => x.Estabelecimento).AsNoTracking().Where(x => (x.Estabelecimento.Id == estabelecimento.Id && x.Aprovado)).ToList(); //lista todas preferencias aprovadas do estabelecimento
                var numPreferenciasCorrespondentes = EstabelecimentoPreferencias.Where(x => (usuario.Preferencias.Any(y => y.Id == x.Preferencia.Id) && x.Aprovado)).Count(); //contagem de preferencias de estabelecimento correspondentes as preferencias do usuario
                var notasEstab = context.Avaliacoes.Include(x => x.Estabelecimento).AsNoTracking().Where(x => x.Estabelecimento.Id == estabelecimento.Id).Select(x => x.Nota).ToList();
                decimal notaMedia = notasEstab.Count == 0 ? 0.5m : (decimal)notasEstab.Average(); // calcula media de notas de estabelecimento
                decimal distanciaCoeficiente = estabelecimento.DistanciaCoeficiente(latitude, longitude); // coeficiente de distancia para calculo de relevancia
                decimal preferenciaCoeficiente = numPreferencias == 0 ? 0 : (decimal)numPreferenciasCorrespondentes / (decimal)numPreferencias; //coeficiente de preferencia para calculo de relevancia
                estabelecimentoRecomendado.setRelevancia(preferenciaCoeficiente, (notaMedia / 10), distanciaCoeficiente); //calcula relevancia de estabelecimento
                estabelecimentosRecomendados.Add(estabelecimentoRecomendado);
            }
            return Ok(estabelecimentosRecomendados.OrderByDescending(x => x.Relevancia).Take(4));
        }

        [HttpGet, Route("recomendacaoGrupo")]
        public IHttpActionResult BuscarRecomendacoesGrupos(int idUsuario, int idGrupo, decimal latitude, decimal longitude)
        {
            List<Estabelecimento> estabelecimentos = new List<Estabelecimento>();
            var retorno = ConferirEstabRecomendados(idUsuario, out estabelecimentos); //atribui estabelecimentos abertos, aprovados e nao recusados, e retorna mensagem de erro caso nao encontre
            if (retorno != null)
            {
                return BadRequest(retorno);
            }
            List<EstabelecimentoRecomendacaoModel> estabelecimentosRecomendados = new List<EstabelecimentoRecomendacaoModel>();
            var usuariosGrupo = context.GrupoUsuarios.Include(x => x.Usuario.Preferencias).AsNoTracking().Where(x => x.Grupo.Id == idGrupo && x.Aprovado).ToList();
            if(usuariosGrupo.Count() == 0)
            {
                return Ok("Este grupo nao possui membros ainda");
            }
            var numPreferencias = usuariosGrupo.Sum(x => x.Usuario.Preferencias.Count());
            foreach (Estabelecimento estabelecimento in estabelecimentos)
            {
                var estabelecimentoRecomendado = new EstabelecimentoRecomendacaoModel(estabelecimento);
                var estabelecimentoPreferencias = context.EstabelecimentoPreferencias.Include(x => x.Preferencia).Include(x => x.Estabelecimento).AsNoTracking().Where(x => (x.Estabelecimento.Id == estabelecimento.Id && x.Aprovado)).ToList(); //lista todas preferencias aprovadas do estabelecimento
                var numPreferenciasCorrespondentes = estabelecimentoPreferencias.Where(x => (usuariosGrupo.Any(y => y.Usuario.Preferencias.Any(z => z.Id == x.Preferencia.Id) && x.Aprovado))).Count();//contagem de preferencias de estabelecimento correspondentes as preferencias dos membros do grupo
                var notasEst = context.Avaliacoes.Include(x => x.Estabelecimento).AsNoTracking().Where(x => x.Estabelecimento.Id == estabelecimento.Id).Select(x => x.Nota).ToList();
                decimal notaMedia = notasEst.Count == 0 ? 0.5m : (decimal)notasEst.Average(); // calcula media de notas de estabelecimento
                decimal distancia = estabelecimento.DistanciaCoeficiente(latitude, longitude); // coeficiente de distancia para calculo de relevancia
                decimal preferenciaCoeficiente = numPreferencias == 0 ? 0 : (decimal)numPreferenciasCorrespondentes / (decimal)numPreferencias; //coeficiente de preferencia para calculo de relevancia
                estabelecimentoRecomendado.setRelevancia(preferenciaCoeficiente, (notaMedia / 10), distancia); //calcula relevancia de estabelecimento
                estabelecimentosRecomendados.Add(estabelecimentoRecomendado);
            }
            return Ok(estabelecimentosRecomendados.OrderByDescending(x => x.Relevancia).Take(4));
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult BuscarTodosEstabelecimentos()
        {
            List<Estabelecimento> listaDeEstabelecimentos = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).ToList();
            if (listaDeEstabelecimentos.Count == 0)
            {
                return BadRequest("Não existem estabelecimentos cadastrados.");
            }
            return Ok(listaDeEstabelecimentos);
        }

        [HttpGet]
        [Route("listarMapa")]
        public IHttpActionResult buscarTodosEstabelecimentosMapa()
        {
            List<Estabelecimento> listaDeEstabelecimentos = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).Take(5).ToList();
            if (listaDeEstabelecimentos.Count == 0)
            {
                return BadRequest("Não existem estabelecimentos cadastrados.");
            }
            return Ok(listaDeEstabelecimentos);
        }

        [HttpGet]
        [Route("listarCinco")]
        public IHttpActionResult BuscarCincoEstabelecimentos()
        {
            List<Estabelecimento> listaDeEstabelecimentos = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).Take(5).ToList();

            if (listaDeEstabelecimentos.Count == 0)
            {
                return BadRequest("Não existem estabelecimentos cadastrados.");
            }
            List<EstabelecimentoModel> listaEstabelecimentosModel = new List<EstabelecimentoModel>();
            foreach (Estabelecimento estabelecimento in listaDeEstabelecimentos)
            {
                listaEstabelecimentosModel.Add(CriarEstabModel(estabelecimento));
            }
            return Ok(listaEstabelecimentosModel);
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult BuscarEstabelecimentoPorId(int id)
        {
            Estabelecimento estabelecimentoExistente = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (estabelecimentoExistente == null)
            {
                return BadRequest("Estabelecimento não existente.");
            }
            return Ok(CriarEstabModel(estabelecimentoExistente));
        }

        [HttpGet]
        [Route("buscarPorFiltros")]
        public IHttpActionResult BuscarEstabelecimentoPorFiltros([FromUri] EstabelecimentoFiltroModel estabFiltro)
        {
            var estabs = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).AsNoTracking().ToList();

            if (estabFiltro.endereco != null)
            {
                estabs = estabs.Where(x => x.Endereco.Comparar(estabFiltro.endereco)).ToList();
            }
            if (estabFiltro.nome != null)
            {
                estabs = estabs.Where(x => x.CompareNome(estabFiltro.nome)).ToList();
            }
            if (estabFiltro.categorias != null)
            {
                if (estabFiltro.categorias[0] != null)
                {
                    estabs = estabs.Where(x => x.Categorias.Any(y => estabFiltro.categorias.Any(z => z.Equals(y.Descricao)))).ToList();
                }
            }
            List<EstabelecimentoModel> estabsModel = new List<EstabelecimentoModel>();
            foreach (Estabelecimento estabelecimento in estabs)
            {
                estabsModel.Add(CriarEstabModel(estabelecimento));
            }

            return Ok(estabsModel);
        }

        [HttpGet]
        [Route("buscarPorFiltrosLocalizacao")]
        public IHttpActionResult BuscarEstabelecimentoPorFiltrosLocalizacao([FromUri] EstabelecimentoFiltroLocalModel estabLocalFiltro)
        {
            var estabs = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).AsNoTracking().ToList();

            estabs = estabs.Where(x => x.DistanciaEstabelecimento(estabLocalFiltro.latitude, estabLocalFiltro.longitude) < 0.5m).ToList();
            if (estabLocalFiltro.nome != null)
            {
                estabs = estabs.Where(x => x.CompareNome(estabLocalFiltro.nome)).ToList();
            }
            if (estabLocalFiltro.categorias != null)
            {
                if (estabLocalFiltro.categorias[0] != null)
                {
                    estabs = estabs.Where(x => x.Categorias.Any(y => estabLocalFiltro.categorias.Any(z => z.Equals(y.Descricao)))).ToList();
                }
            }
            List<EstabelecimentoModel> estabsModel = new List<EstabelecimentoModel>();
            foreach (Estabelecimento estabelecimento in estabs)
            {
                estabsModel.Add(CriarEstabModel(estabelecimento));
            }

            return Ok(estabsModel);
        }

        private EstabelecimentoModel CriarEstabModel(Estabelecimento estabelecimento)
        {
            EstabelecimentoModel estabModel = new EstabelecimentoModel(estabelecimento);
            var avaliacoes = context.Avaliacoes.Include(x => x.Usuario).AsNoTracking().Where(x => x.Estabelecimento.Id == estabelecimento.Id).ToList();
            estabModel.EstaAberto = estabelecimento.EstaAberto(new DateTime(2017, 11, 4, 15, 12, 0, 0));
            if (avaliacoes.Count() != 0)
            {
                foreach (Avaliacao avaliacao in avaliacoes)
                {
                    estabModel.Avaliacoes.Add(avaliacao);
                }
                var notasAvaliacoes = avaliacoes.Select(x => x.Nota);
                estabModel.MediaAvaliacoes = (decimal)notasAvaliacoes.Average();
                estabModel.NumAvaliacoes = notasAvaliacoes.Count();
            }
            estabModel.Avaliacoes.OrderByDescending(x => x.DataAvaliacao);
            return estabModel;
        }

        private String ConferirEstabRecomendados(int idUsuario, out List<Estabelecimento> estabelecimentos)
        {
            estabelecimentos = context.Estabelecimentos
                .Include(x => x.Endereco)
                .Include(x => x.Categorias)
                .Include(x => x.Fotos)
                .AsNoTracking()
                .Where(x => x.Aprovado)
                .ToList(); //buscar estabelecimentos aprovados
            if (estabelecimentos.Count == 0)
            {
                return "Não há estabelecimentos cadastrados no sistema ainda.";
            }
            //buscar estabelecimentos nao recusados
            estabelecimentos = estabelecimentos.Where(x => !context.Usuarios.Include(y => y.EstabelecimentosRecusados).FirstOrDefault(y => y.Id == idUsuario).EstabelecimentosRecusados.Any(z => z.Id == x.Id)).ToList();
            //buscar estabelecimentos abertos
            estabelecimentos = estabelecimentos.Where(x => x.EstaAberto(new DateTime(2017, 11, 4, 15, 12, 0, 0))).ToList();
            if (estabelecimentos.Count == 0)
            {
                return "Não há estabelecimentos abertos no momento.";
            }
            return null;
        }
    }
}
