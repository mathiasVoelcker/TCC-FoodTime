﻿using FoodTime.Dominio.Entidades;
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
            List<Estabelecimento> estabelecimentoAbertos = estabelecimentosAprovados.Where(x => x.EstaAberto(new DateTime(2017, 11, 4, 20, 20, 0, 0))).ToList();
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
                decimal notaMedia = (decimal)context.Avaliacoes.Include(x => x.Estabelecimento).AsNoTracking().Where(x => x.Estabelecimento.Id == estabelecimento.Id).Select(x => x.Nota).Average();
                decimal distancia = estabelecimento.DistanciaEstabelecimento(latitude, longitude);
                estabelecimentoRecomendado.setRelevancia((numPreferenciasCorrespondentes / (usuario.Preferencias.Count())), (notaMedia / 10), ((201 - distancia) / 201));
                estabelecimentosRecomendados.Add(estabelecimentoRecomendado);
            }
            return Ok(estabelecimentosRecomendados.OrderByDescending(x => x.Relevancia).Take(5));
        }

        [HttpGet]
        [Route("BuscarEstabelecimentoPorId")]
        public IHttpActionResult BuscarEstabelecimentoPorId(int idEstabelecimento)
        {
            Estabelecimento estabelecimentoExistente = context.Estabelecimentos.Include(x => x.Endereco).Include(x => x.Categorias).Include(x => x.Fotos).FirstOrDefault(x => x.Id == idEstabelecimento);
            if (estabelecimentoExistente==null)
            {
                return BadRequest("Estabelecimento não existente.");
            }
            return Ok(estabelecimentoExistente);
        }



    }
}
