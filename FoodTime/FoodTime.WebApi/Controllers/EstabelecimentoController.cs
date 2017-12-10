using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

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
                decimal distancia = estabelecimento.DistanciaEstabelecimento(latitude, longitude);
                estabelecimentoRecomendado.setRelevancia((numPreferenciasCorrespondentes / (usuario.Preferencias.Count())), (notaMedia / 10), distancia);
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
            Estabelecimento estabelecimentoExistente = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).FirstOrDefault(x => x.Id == id);
            if (estabelecimentoExistente==null)
            {
                return BadRequest("Estabelecimento não existente.");
            }
            return Ok(estabelecimentoExistente);
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
            if(estabFiltro.categorias != null)
            {
                estabs = estabs.Where(x => x.Categorias.Any(y => estabFiltro.categorias.Any(z => z.Equals(y.Descricao)))).ToList();
            }

            return Ok();
        }



    }
}
