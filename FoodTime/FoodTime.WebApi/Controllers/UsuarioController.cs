using FoodTime.Infraestrutura;
using FoodTime.Dominio.Entidades;
using FoodTime.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodTime.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        IFoodTimeContext context;

        public UsuarioController()
        {
            context = new FoodTimeContext();
        }

        [HttpGet]
        public IHttpActionResult ObterUsuario([FromUri]UsuarioLoginModel usuarioLoginModel)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Email == usuarioLoginModel.Email);
            if (usuario == null)
                return BadRequest("Usuário ou senha incorretos");
            return Ok(new UsuarioModel(usuario));
        }

        [HttpPost]
        public IHttpActionResult Adicionar([FromBody]Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return Created($"api/usuario/{usuario.Id}", usuario);
        }

        [HttpGet]
        [Route("buscar")]
        public IHttpActionResult BuscarUsuario([FromUri]UsuarioModel usuarioModel)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == usuarioModel.Id);
            if (usuario == null)
                return BadRequest("Usuário não existe");
            return Ok(new UsuarioModel(usuario));
        }

        [HttpGet]
        [Route("buscarPorId")]
        public IHttpActionResult BuscarUsuarioPorId([FromUri]int id)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (usuario == null)
                return BadRequest("Usuário não existe");
            return Ok(new UsuarioModel(usuario));
        }

        [HttpGet]
        public IHttpActionResult BuscarAvaliacoesPorUsuario([FromUri]UsuarioModel usuarioModel)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == usuarioModel.Id);
            if (usuario == null)
                return BadRequest("Usuário não existe");
            List<Avaliacao> avaliacoes = context.Avaliacoes.Include(x => x.Usuario).Where(x => x.Usuario.Id == usuario.Id).OrderByDescending(x=> x.DataAvaliacao).ToList();
            if (avaliacoes.Count == 0)
                return BadRequest("Nenhuma avaliacão encontrada.");
            return Ok(avaliacoes);
        }

      

    }
}
