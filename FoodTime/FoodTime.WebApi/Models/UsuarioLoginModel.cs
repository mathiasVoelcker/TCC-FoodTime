using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class UsuarioLoginModel
    {

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}