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
    }
}
