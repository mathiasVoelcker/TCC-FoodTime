﻿using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Configuration;
using System.IO;

namespace FoodTime.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/avaliacao")]
    public class AvaliacaoController : ApiController
    {
        IFoodTimeContext context;

        public AvaliacaoController()
        {
            context = new FoodTimeContext();
        }

        [HttpPost, Route("registro")]
        public IHttpActionResult Registrar([FromBody]AvaliacaoModel avaliacaoModel)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.Id == avaliacaoModel.IdUsuario);
            if (usuario == null)
                return BadRequest("Usuario nao encontrado.");
            var estabelecimento = context.Estabelecimentos.FirstOrDefault(x => x.Id == avaliacaoModel.IdEstabelecimento);
            if (estabelecimento == null)
                return BadRequest("Estabelecimento nao encontrado.");
            var avaliacao = new Avaliacao(avaliacaoModel.Nota,
                avaliacaoModel.PrecoMedio,
                avaliacaoModel.Comentario,
                avaliacaoModel.FotoAvaliacao,
                avaliacaoModel.Recomendado,
                DateTime.Now,
                usuario,
                estabelecimento);
            var mensagensErro = avaliacao.ValidarEntrada();
            if (mensagensErro.Count == 0)
            {
                context.Avaliacoes.Add(avaliacao);
                context.SaveChanges();
                return Created($"api/avaliacao/{avaliacao.Id}", avaliacaoModel);
            }
            return BadRequest(String.Join(" " , mensagensErro.ToArray()));
        }

        [HttpGet]
        [Route("buscarPorIdUsuario")]
        public IHttpActionResult BuscarUltimasAvaliacoesPorIdUsuario([FromUri]int idUsuario)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == idUsuario);
            if (usuario == null)
                return BadRequest("Usuário não existe");
            List<Avaliacao> avaliacoes = context.Avaliacoes
                .Include(x => x.Usuario)
                .Include(x => x.Estabelecimento)
                .Where(x => x.Usuario.Id == usuario.Id)
                .OrderByDescending(x => x.DataAvaliacao)
                .Take(5).ToList();
            if (avaliacoes.Count == 0)
                return BadRequest("Nenhuma avaliação encontrada.");
            return Ok(avaliacoes);
        }

        [HttpGet]
        [Route("buscarPorIdEstabelecimento")]
        public IHttpActionResult BuscarUltimasAvaliacoesPorIdEstabelecimento([FromUri]int idEstab)
        {
            var estabelecimento = context.Estabelecimentos.AsNoTracking().FirstOrDefault(x => x.Id == idEstab);
            if (estabelecimento == null)
                return BadRequest("Estabelecimento não existe");
            List<Avaliacao> avaliacoes = context.Avaliacoes
                .Include(x => x.Usuario)
                .Include(x => x.Estabelecimento)
                .Where(x => x.Estabelecimento.Id == idEstab)
                .OrderByDescending(x => x.DataAvaliacao)
                .Take(5).ToList();
            if (avaliacoes.Count == 0)
                return BadRequest("Nenhuma avaliação encontrada.");
            return Ok(avaliacoes);
        }
    }
}
