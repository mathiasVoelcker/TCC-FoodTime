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

namespace FoodTime.WebApi.Controllers
{
    public class FotoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AdicionarFoto(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0 && file != null)
            {

                //        model.ANEXO.NOME_ARQUIVO = file.FileName;
                //        model.ANEXO.TIPO_CONTENT = file.ContentType;
                //        model.ANEXO.NOME_HASH = model.ID_ATIVIDADE_EXTENSAO + Criptografia.MD5Hash(model.ANEXO.NOME_ARQUIVO);

                //        var fileNameHash = Path.GetFileName(model.ANEXO.NOME_HASH);
                //        var fileName = Path.GetFileName(model.ANEXO.NOME_ARQUIVO);
                //        var directory = (String.IsNullOrEmpty(ConfigurationManager.AppSettings["pathAnexos"])) ? Server.MapPath("~/App_Data/Images/") : ConfigurationManager.AppSettings["pathAnexos"];

                //        if (!Directory.Exists(directory))
                //        {
                //            Directory.CreateDirectory(directory);
                //        }
                //        var path = Path.Combine(directory, fileNameHash);
                //        var pathOriginal = Path.Combine(directory, fileName);
                //        model.ANEXO.TIPO_ARQUIVO = Path.GetExtension(pathOriginal);
                //        file.SaveAs(path);

                //        model.ANEXO.ID_ATIVIDADE_EXTENSAO = model.ID_ATIVIDADE_EXTENSAO;
                //        model.ANEXO.Insert();
                //        TempData["Message_Anexo"] = "Arquivo armazenado com sucesso!";

                //    return null;
                //}

            }
            return null;

        }
    }
}