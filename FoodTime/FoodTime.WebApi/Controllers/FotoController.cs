using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura;
using FoodTime.WebApi.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Configuration;
using System.IO;

namespace FoodTime.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/foto")]
    public class FotoController : ApiController
    {
        [HttpPost]
        [Route("novaFoto")]
        public IHttpActionResult AdicionarFoto()
        {
            var httpRequest = HttpContext.Current.Request;
            var file = httpRequest.Files[0];

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    Foto foto = new Foto(file.FileName);
                    var directory = ConfigurationManager.AppSettings["pathFotos"];
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    var pathOriginal = Path.Combine(directory, file.FileName);
                    file.SaveAs(pathOriginal);
                    return Ok("Arquivo salvo com sucesso!");
                }
            }
            return BadRequest("Ocorreu um erro ao salvar o arquivo.");
        }

    }
}