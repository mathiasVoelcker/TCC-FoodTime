using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FoodTime.WebApi.Controllers
{
    [RoutePrefix("api/grupoUsuario")]
    public class GrupoUsuarioController : ApiController
    {

        IFoodTimeContext context;

        public GrupoUsuarioController(IFoodTimeContext context)
        {
            // context = new FoodTimeContext();
            this.context = context;
        }

        [HttpPost]
        public IHttpActionResult AdicionarParticipantesGrupo([FromBody]List<GrupoUsuarioModel> grupoUsuarioListModel)
        {
            foreach (GrupoUsuarioModel grupoUsuarioModel in grupoUsuarioListModel)
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == grupoUsuarioModel.IdUsuario);
                if (usuario == null)
                {
                    return BadRequest("Usuário não encontrado");
                }
                var grupo = context.Grupos.FirstOrDefault(x => x.Id == grupoUsuarioModel.IdGrupo);
                if (grupo== null)
                {
                    return BadRequest("Grupo não encontrado");
                }
                context.GrupoUsuarios.Add(new GrupoUsuario(usuario, grupo, false));
            }
            context.SaveChanges();
            return Ok(grupoUsuarioListModel);
        }

        [HttpPut]
        [Route("AprovarSolicitacao")]
        public IHttpActionResult AprovarSolicitacaoDeAmizade(int idGrupo, int idUsuario)
        {
            GrupoUsuario grupoUsuario = context.GrupoUsuarios.FirstOrDefault(x => (x.Grupo.Id == idGrupo && x.Usuario.Id == idUsuario));
            if(grupoUsuario == null)
            {
                return BadRequest("Nenhum grupo encontrado");
            }
            grupoUsuario.AprovarSolicitacao();
            context.SaveChanges();
            return Ok();
        }
    }
}