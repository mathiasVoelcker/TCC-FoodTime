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

        [HttpPost, Route("registrar")]
        public IHttpActionResult CriarEstabelecimento([FromBody] Estabelecimento estabelecimento)
        {
            context.Enderecos.Add(estabelecimento.Endereco);
            foreach (Categoria categoria in estabelecimento.Categorias)
            {
                context.Categorias.Add(categoria);
            }
            foreach (Foto foto in estabelecimento.Fotos)
            {
                context.Fotos.Add(foto);
            }
            context.Estabelecimentos.Add(estabelecimento);
            context.SaveChanges();
            return Created("Sucesso", estabelecimento);
        }

        [HttpGet, Route("recomendacao")]
        public IHttpActionResult BuscarRecomendacoes(int idUsuario, decimal latitude, decimal longitude)
        {
            List<Estabelecimento> estabelecimentosAprovados = context.Estabelecimentos
                .Include(x => x.Endereco)
                .Include(x => x.Categorias)
                .Include(x => x.Fotos)
                .AsNoTracking()
                .Where(x => x.Aprovado)
                .ToList();
            if(estabelecimentosAprovados.Count == 0)
            {
                BadRequest("Não há estabelecimentos cadastrados no sistema ainda.");
            }
            estabelecimentosAprovados = estabelecimentosAprovados.Where(x => !context.Usuarios.Include(y => y.Estabelecimento).FirstOrDefault(y => y.Id == idUsuario).Estabelecimento.Any(z => z.Id == x.Id)).ToList();
            List<Estabelecimento> estabelecimentoAbertos = estabelecimentosAprovados.Where(x => x.EstaAberto(new DateTime(2017, 11, 4, 12, 12, 0, 0))).ToList();
            if (estabelecimentoAbertos.Count == 0)
            {
                BadRequest("Não há estabelecimentos abertos no momento.");
            }
            List<EstabelecimentoRecomendacaoModel> estabelecimentosRecomendados = new List<EstabelecimentoRecomendacaoModel>();
            var numPreferenciasCorrespondentes = 0;
            var usuario = context.Usuarios.Include(x => x.Preferencias).AsNoTracking().FirstOrDefault(x => x.Id == idUsuario);
            foreach (Estabelecimento estabelecimento in estabelecimentoAbertos)
            {
                var estabelecimentoRecomendado = new EstabelecimentoRecomendacaoModel(estabelecimento);
                var EstabelecimentoPreferencias = context.EstabelecimentoPreferencias.Include(x => x.Preferencia).Include(x => x.Estabelecimento).AsNoTracking().Where(x => (x.Estabelecimento.Id == estabelecimento.Id && x.Aprovado)).ToList();
                numPreferenciasCorrespondentes = EstabelecimentoPreferencias.Where(x => (usuario.Preferencias.Any(y => y.Id == x.Preferencia.Id) && x.Aprovado)).Count();
                var notasEst = context.Avaliacoes.Include(x => x.Estabelecimento).AsNoTracking().Where(x => x.Estabelecimento.Id == estabelecimento.Id).Select(x => x.Nota).ToList();
                decimal notaMedia = notasEst.Count == 0 ? 0.5m : (decimal)notasEst.Average(); 
                decimal distancia = estabelecimento.DistanciaCoeficiente(latitude, longitude);
                var numPreferencias = usuario.Preferencias.Count();
                var preferenciaCoeficiente = 0;
                if (numPreferencias != 0)
                {
                    preferenciaCoeficiente = numPreferenciasCorrespondentes/numPreferencias;
                }
                estabelecimentoRecomendado.setRelevancia(preferenciaCoeficiente, (notaMedia / 10), distancia);
                estabelecimentosRecomendados.Add(estabelecimentoRecomendado);
            }
            return Ok(estabelecimentosRecomendados.OrderByDescending(x => x.Relevancia).Take(4));
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult buscarTodosEstabelecimentos()
        {
            List<Estabelecimento> listaDeEstabelecimentos = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).ToList();
            if (listaDeEstabelecimentos.Count == 0)
            {
                return BadRequest("Não existem estabelecimentos cadastrados.");
            }
            return Ok(listaDeEstabelecimentos);
        }

        [HttpGet]
        [Route("listarCinco")]
        public IHttpActionResult buscarCincoEstabelecimentos()
        {
            List<Estabelecimento> listaDeEstabelecimentos = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).Take(5).ToList();
            if (listaDeEstabelecimentos.Count == 0)
            {
                return BadRequest("Não existem estabelecimentos cadastrados.");
            }
            return Ok(listaDeEstabelecimentos);
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult BuscarEstabelecimentoPorId(int id)
        {
            Estabelecimento estabelecimentoExistente = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (estabelecimentoExistente==null)
            {
                return BadRequest("Estabelecimento não existente.");
            }

            EstabelecimentoModel estabModel = new EstabelecimentoModel(estabelecimentoExistente);
            var avaliacoes = context.Avaliacoes.Include(x => x.Usuario).AsNoTracking().Where(x => x.Estabelecimento.Id == id).ToList();
            if (avaliacoes != null) {
                foreach (Avaliacao avaliacao in avaliacoes)
                {
                    estabModel.Avaliacoes.Add(avaliacao);
                }
                estabModel.EstaAberto = estabelecimentoExistente.EstaAberto(new DateTime(2017, 11, 4, 12, 12, 0, 0));
                var notasAvaliacoes = avaliacoes.Select(x => x.Nota);
                estabModel.MediaAvaliacoes = (decimal)notasAvaliacoes.Average();
                estabModel.NumAvaliacoes = notasAvaliacoes.Count();
            }
            return Ok(estabModel);
        }

        [HttpGet]
        [Route("buscarPorFiltros")]
        public IHttpActionResult BuscarEstabelecimentoPorFiltros([FromUri] EstabelecimentoFiltroModel estabFiltro)
        {
            var estabs = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).AsNoTracking().ToList();

            if (estabFiltro.endereco != null)
            {
                estabs = estabs.Where(x => x.Endereco.Comparar(estabFiltro.endereco)).ToList();
            }
            if (estabFiltro.nome != null)
            {
                estabs = estabs.Where(x => x.CompareNome(estabFiltro.nome)).ToList();
            }
            if(estabFiltro.categorias[0] != null)
            {
                estabs = estabs.Where(x => x.Categorias.Any(y => estabFiltro.categorias.Any(z => z.Equals(y.Descricao)))).ToList();
            }

            return Ok(estabs);
        }

        [HttpGet]
        [Route("buscarPorFiltrosLocalizacao")]
        public IHttpActionResult BuscarEstabelecimentoPorFiltrosLocalizacao([FromUri] EstabelecimentoFiltroLocalModel estabLocalFiltro)
        {
            var estabs = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).AsNoTracking().ToList();

            estabs = estabs.Where(x => x.DistanciaEstabelecimento(estabLocalFiltro.latitude, estabLocalFiltro.longitude) < 1m).ToList();
            if (estabLocalFiltro.nome != null)
            {
                estabs = estabs.Where(x => x.CompareNome(estabLocalFiltro.nome)).ToList();
            }
            if(estabLocalFiltro.categorias != null)
            {
                if (estabLocalFiltro.categorias[0] != null)
                {
                    estabs = estabs.Where(x => x.Categorias.Any(y => estabLocalFiltro.categorias.Any(z => z.Equals(y.Descricao)))).ToList();
                }
            }

            return Ok(estabs);
        }



    }
}
