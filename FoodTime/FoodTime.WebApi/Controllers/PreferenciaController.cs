﻿using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}