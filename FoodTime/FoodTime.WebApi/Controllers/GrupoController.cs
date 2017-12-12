﻿using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FoodTime.WebApi.Controllers
{
    [RoutePrefix("api/grupo")]
    public class GrupoController : ApiController
    {
        IFoodTimeContext context;

        public GrupoController(IFoodTimeContext context)
        {
            // context = new FoodTimeContext();
            this.context = context;
        }

        [HttpPost]
        public IHttpActionResult CriarGrupo(GrupoModel grupoModel)
        {
            context.Grupos.Add(new Grupo(grupoModel.Nome, grupoModel.Imagem));
            context.SaveChanges();
            var grupo = context.Grupos.OrderByDescending(x => x.Id).FirstOrDefault();
            foreach (int idUsuario in grupoModel.IdUsuarios)
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == idUsuario);
                if(usuario == null)
                {
                    return BadRequest("Usuário não encontrado");
                }
                context.GrupoUsuarios.Add(new GrupoUsuario(usuario, grupo, false));
            }
            context.SaveChanges();
            return Ok(grupoModel);
        }

        [HttpGet]
        [Route("buscarPorUsuario")]
        public IHttpActionResult BuscarGruposPorUsuario(int idUsuario)
        {
            List<Grupo> grupos = context.GrupoUsuarios.Where(x => x.Usuario.Id == idUsuario).Select(x => x.Grupo).ToList();
            if (grupos == null)
            {
                BadRequest("Nenhum grupo encontrado para este usuário");
            }
            return Ok(grupos);
        }
    }
}