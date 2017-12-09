using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            List<Avaliacao> avaliacoesUsuario = context.Avaliacoes.AsNoTracking().Where(x => x.Usuario.Id == idUsuario).ToList();
            return Ok(avaliacoesUsuario);
        }

    }
}
