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
        public IHttpActionResult ObterUsuarioPorEmail(string email)
        {
            var usuario = context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Email == email);
            if (usuario == null)
                return BadRequest("Usuário ou senha incorretos");
            return Ok(new UsuarioModel(usuario));
        }

        [HttpGet]
        [Route("buscarPorFiltro")]
        public IHttpActionResult ObterUsuarioPorFiltro(string filtro)
        {
            if (filtro == null)
                filtro = "";
            List<Usuario> usuarios = context.Usuarios.AsNoTracking().Where(x => (x.Email.Contains(filtro) || x.Nome.Contains(filtro))).ToList();
            if (usuarios == null)
                return BadRequest("Nenhum usuário encontrado");
            return Ok(usuarios);
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Adicionar([FromBody]UsuarioCadastroModel usuarioCadastroModel)
        {
            List<Preferencia> novaListaPreferencias = new List<Preferencia>();

            foreach (var item in usuarioCadastroModel.IdsPreferencias)
            {
                var preferenciaExistente = context.Preferencias.FirstOrDefault(x => x.Id == item && x.Aprovado == true);
                if (preferenciaExistente != null)
                {
                    novaListaPreferencias.Add(preferenciaExistente);
                }
            }
            var novoUsuario = new Usuario(usuarioCadastroModel.Email, usuarioCadastroModel.Senha, usuarioCadastroModel.Nome, usuarioCadastroModel.Sobrenome, usuarioCadastroModel.FotoPerfil, usuarioCadastroModel.DataNascimento, usuarioCadastroModel.Admin, novaListaPreferencias);
            context.Usuarios.Add(novoUsuario);
            context.SaveChanges();
            return Created($"api/usuario/{novoUsuario.Id}", novoUsuario);
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
            List<Avaliacao> avaliacoes = context.Avaliacoes.Include(x => x.Usuario).Where(x => x.Usuario.Id == usuario.Id).OrderByDescending(x => x.DataAvaliacao).ToList();
            if (avaliacoes.Count == 0)
                return BadRequest("Nenhuma avaliacão encontrada.");
            return Ok(avaliacoes);
        }

        [HttpGet]
        [Route("buscarPorGrupo")]
        public IHttpActionResult BuscarUsuariosNaoMembrosDeGrupo(int idGrupo, string filtro)
        {
            if (filtro == null)
                filtro = "";
            List<Usuario> usuarios = context.Usuarios.AsNoTracking().Where(x => !context.GrupoUsuarios.Any(y => (y.Usuario.Id == x.Id && y.Grupo.Id == idGrupo))).ToList();
            if (usuarios == null)
                return BadRequest("Nenhum usuário encontrado");
            usuarios = usuarios.Where(x => (x.Email.Contains(filtro) || x.Nome.Contains(filtro))).ToList();
            return Ok(usuarios);
        }

        [HttpPut]
        [Route("excluirRecomendacao")]
        public IHttpActionResult ExcluirRecomendacao(int idEstabelecimento, int idUsuario)
        {
            var usuario = context.Usuarios.Include(x => x.EstabelecimentosRecusados).FirstOrDefault(x => x.Id == idUsuario);
            var estabelecimento = context.Estabelecimentos.FirstOrDefault(x => x.Id == idEstabelecimento);
            usuario.EstabelecimentosRecusados.Add(estabelecimento);
            context.SaveChanges();
            return Ok(usuario);
        }

        [HttpPut]
        [Route("adicionarPreferencias")]
        public IHttpActionResult AdicionarPreferencias([FromBody]List<int> idPreferencias, int idUsuario)
        {
            var usuario = context.Usuarios.Include(x => x.Preferencias).FirstOrDefault(x => x.Id == idUsuario);
            if (usuario == null)
            {
                return BadRequest("Usuario não encontrado");
            }
            foreach(int idPreferencia in idPreferencias)
            {
                var preferencia = context.Preferencias.FirstOrDefault(x => x.Id == idPreferencia);
                if (preferencia == null)
                {
                    return BadRequest("Preferencia não encontrada");
                }
                usuario.Preferencias.Add(preferencia);
            }
            context.SaveChanges();
            return Ok(usuario);
        }
    }
}
