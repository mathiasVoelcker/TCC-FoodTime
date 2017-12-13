using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;

namespace FoodTime.WebApi.Controllers
{
    [RoutePrefix("api/notificacao")]
    public class NotificacaoController : ApiController
    {
        IFoodTimeContext context;

        public NotificacaoController(IFoodTimeContext context)
        {
            // context = new FoodTimeContext();
            this.context = context;
        }

        [HttpGet]
        [Route("solicitacoes")]
        public IHttpActionResult BuscarSolicitacoesDeGrupo(int idUsuario)
        {
            List<Notificacao> notificacoes = context.Notificacoes.Include(x => x.Usuario).Include(x => x.Grupo).Include(x => x.Estabelecimento).AsNoTracking().Where(x => (x.Visibilidade && x.Estabelecimento == null)).ToList();
            if(notificacoes != null)
            {
                notificacoes = notificacoes.Where(x => x.Usuario.Id == idUsuario).ToList();
            }
            return Ok(notificacoes);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult AtualizarNotificacaoParaInvisivel([FromUri]int id)
        {
            var notificacao = context.Notificacoes.FirstOrDefault(x => x.Id == id);
            if (notificacao == null)
                return BadRequest("Notificação não encontrada");
            notificacao.MarcarComoLida();
            context.SaveChanges();
            return Ok(notificacao);
        }
    }
}