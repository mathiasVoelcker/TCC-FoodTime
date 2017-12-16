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
    [RoutePrefix("api/estabelecimentoPreferencia")]
    public class EstabelecimentoPreferenciaController : ApiController
    {
        IFoodTimeContext context;

        public EstabelecimentoPreferenciaController()
        {
            context = new FoodTimeContext();
        }

        [HttpPost]
        public IHttpActionResult AdicionarPreferencias([FromBody]List<int> idPreferencias, int idEstabelecimento)
        {
            var estabelecimento = context.Estabelecimentos.FirstOrDefault(x => x.Id == idEstabelecimento);
            if (estabelecimento == null)
                return BadRequest("Estabelecimento não encontrado");
            foreach (int idPreferencia in idPreferencias)
            {
                var preferencia = context.Preferencias.FirstOrDefault(x => x.Id == idPreferencia);
                if (preferencia == null)
                    return BadRequest("Preferencia não encontrada");
                context.EstabelecimentoPreferencias.Add(new EstabelecimentoPreferencia(estabelecimento, preferencia, true));
            }
            context.SaveChanges();
            return Ok("Preferencias salvas com sucesso");
        }
    }
}
