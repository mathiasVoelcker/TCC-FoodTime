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
            List<Estabelecimento> estabelecimentosAprovados = context.Estabelecimentos.AsNoTracking().Where(x => x.Aprovado).ToList();
            List<Estabelecimento> estabelecimentoAbertos = estabelecimentosAprovados.Where(x => x.EstaAberto(new DateTime(2017, 11, 4, 20, 20, 0, 0))).ToList();

            return Ok(estabelecimentoAbertos);
        }

    }
}
