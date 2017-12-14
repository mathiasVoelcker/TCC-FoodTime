using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodTime.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/preferencia")]
    public class PreferenciaController : ApiController
    {
        IFoodTimeContext context;

        public PreferenciaController()
        {
            context = new FoodTimeContext();
        }

        [HttpPost, Route("registro")]
        public IHttpActionResult RegistrarPreferencia([FromBody]PreferenciaModel preferenciaModel)
        {
            var preferencia = new Preferencia(preferenciaModel.Descricao, preferenciaModel.Aprovado);
            var mensagensErro = preferencia.ValidarEntrada();
            if (mensagensErro.Count == 0)
            {
                context.Preferencias.Add(preferencia);
                context.SaveChanges();
                return Created($"api/avaliacao/{preferencia.Id}", preferenciaModel);
            }
            return BadRequest(String.Join(String.Empty, mensagensErro.ToArray()));
        }

        [HttpPost, Route("estabelecimento/registro")]
        public IHttpActionResult RegistrarEstabelecimentoPreferencia([FromBody]EstabelecimentoPreferenciaModel estabelecimentoPreferenciaModel)
        {
            var estabelecimento = context.Estabelecimentos.FirstOrDefault(x => x.Id == estabelecimentoPreferenciaModel.IdEstabelecimento);
            var preferencia = context.Preferencias.FirstOrDefault(x => x.Id == estabelecimentoPreferenciaModel.IdPreferencia);

            var estabelecimentoPreferencia = new EstabelecimentoPreferencia(estabelecimento, preferencia, estabelecimentoPreferenciaModel.Aprovado);
            var mensagensErro = estabelecimentoPreferencia.ValidarEntrada();
            if (mensagensErro.Count == 0)
            {
                context.EstabelecimentoPreferencias.Add(estabelecimentoPreferencia);
                context.SaveChanges();
                return Created($"api/avaliacao/{estabelecimentoPreferencia.Id}", estabelecimentoPreferenciaModel);
            }
            return BadRequest(String.Join(String.Empty, mensagensErro.ToArray()));
        }

        [HttpGet, Route("listar")]
        public IHttpActionResult BuscarTodasPreferencias()
        {
            var listaDePreferencias = context.Preferencias.Where(x => x.Aprovado).ToList();

            if (listaDePreferencias.Count == 0)
            {
                return BadRequest("Não existem preferencias cadastradas.");
            }
            return Ok(listaDePreferencias);
        }

        [HttpGet, Route("listarPreferenciasMenosAsDoUsuario")]
        public IHttpActionResult BuscarTodasPreferenciasMenosAsDoUsuario([FromUri]int idUsuario)
        {
            var usuarioExistente = context.Usuarios.Include(x => x.Preferencias).FirstOrDefault(x=> x.Id==idUsuario);
            if (usuarioExistente == null)
            {
                return BadRequest("Usuário não existe");
            }

            List<Preferencia> listaDePreferencias = (List<Preferencia>)context.Preferencias.Where(x => x.Aprovado).ToList();
            if (listaDePreferencias.Count == 0)
            {
                return BadRequest("Não existem preferencias cadastradas.");
            }
            listaDePreferencias = listaDePreferencias.Where(x => context.EstabelecimentoPreferencias.Any(y => y.Estabelecimento.Id == x.Id)).ToList();
            var preferenciasFiltradas = listaDePreferencias.Except(usuarioExistente.Preferencias).ToList();
           
            return Ok(preferenciasFiltradas);
        }

        [HttpGet, Route("listarPreferenciasPorEstab")]
        public IHttpActionResult BuscarTodasPreferenciasMenosAsDoEstab([FromUri]int idEstab)
        {
            var estabelecimentoExistente = context.Estabelecimentos.FirstOrDefault(x => x.Id == idEstab);
            if (estabelecimentoExistente == null)
            {
                var listaDeTodasPreferencias = context.Preferencias.Where(x => x.Aprovado).ToList();
                return Ok(listaDeTodasPreferencias);
            }
            List<Preferencia> listaDePreferencias = (List<Preferencia>)context.Preferencias.Where(x => x.Aprovado).ToList();
            if (listaDePreferencias.Count == 0)
            {
                return BadRequest("Não existem preferencias cadastradas.");
            }
            var listaDePreferenciasDeEstab = context.EstabelecimentoPreferencias.Where(x => x.Estabelecimento.Id == idEstab).Select(x => x.Preferencia).ToList();
            listaDePreferencias = listaDePreferencias.Except(listaDePreferenciasDeEstab).ToList();
            return Ok(listaDePreferencias);
        }
    }
}
