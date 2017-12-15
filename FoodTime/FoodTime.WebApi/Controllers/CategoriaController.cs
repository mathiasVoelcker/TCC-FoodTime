using FoodTime.WebApi.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodTime.Infraestrutura;
using FoodTime.Dominio.Entidades;

namespace FoodTime.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/categoria")]
    public class CategoriaController : ApiController
    {
        IFoodTimeContext context;

        public CategoriaController(IFoodTimeContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult BuscarCategoriaPorId([FromUri]int id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
                return BadRequest("Nenhuma categoria encontrada.");
            return Ok(categoria);
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult BuscarTodasCategorias()
        {
            List<Categoria> ListaDeCategoria = context.Categorias.ToList();
            if (ListaDeCategoria.Count == 0)
                return BadRequest("Nenhuma categoria encontrada.");
            return Ok(ListaDeCategoria);
        }

    }
}