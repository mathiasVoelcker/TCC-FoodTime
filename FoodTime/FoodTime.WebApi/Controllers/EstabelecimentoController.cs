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

    }
}
