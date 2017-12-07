using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class UsuarioLoginModel
    {
        public UsuarioLoginModel() { }

        public UsuarioLoginModel(Usuario usuario)
        {
            Email = usuario.Email;
            Senha = usuario.Senha;
        }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}