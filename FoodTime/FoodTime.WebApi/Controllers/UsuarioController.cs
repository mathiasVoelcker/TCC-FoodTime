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

    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        IFoodTimeContext context;

        public UsuarioController(IFoodTimeContext context)
        {
           // context = new FoodTimeContext();
            this.context = context;
        }

        //Listar usuario logado
        [HttpGet]
        [Route("usuariologado")]

        public IHttpActionResult GetUsuarioLogado()

        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.Email.Equals(User.Identity.Name));

            if (usuario == null)
                return BadRequest("Usuário não encontrado.");

            return Ok(new { dados = usuario });

        }
        [HttpGet]
        public IHttpActionResult ObterUsuario(String email)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Email == email);
            if (usuario == null)
                return BadRequest("Usuário ou senha incorretos");
            return Ok(new UsuarioModel(usuario));
        }

        [HttpPost]
        public IHttpActionResult Adicionar([FromBody]UsuarioCadastroModel usuarioCadastroModel)
        {
            List<Preferencia> novaListaPreferencias = new List<Preferencia>();

            foreach (var item in usuarioCadastroModel.IdsPreferencias)
            {
                var preferenciaExistente = context.Preferencias.FirstOrDefault(x => x.Id == item && x.Aprovado==true);
                if (preferenciaExistente != null)
                {
                    novaListaPreferencias.Add(preferenciaExistente);
                }
            }
            var novoUsuario = new Usuario(usuarioCadastroModel.Email, usuarioCadastroModel.Senha, usuarioCadastroModel.Nome, usuarioCadastroModel.Sobrenome, usuarioCadastroModel.FotoPerfil, usuarioCadastroModel.DataNascimento, usuarioCadastroModel.Admin, novaListaPreferencias, null);

            context.Usuarios.Add(novoUsuario);
            context.SaveChanges();
            return Created($"api/usuario/{novoUsuario.Id}", novoUsuario);
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
        [Route("{id}")]
        public IHttpActionResult BuscarUsuarioPorId([FromUri]int id)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (usuario == null)
                return BadRequest("Usuário não existe");
            return Ok(new UsuarioModel(usuario));
        }

        [HttpGet]
        [Route("buscarPorAvaliacoes")]
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
