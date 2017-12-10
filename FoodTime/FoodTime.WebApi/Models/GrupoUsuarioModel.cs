using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class GrupoUsuarioModel
    {
        public int IdUsuario { get; set; }
        public int IdGrupo { get; set; }
        public bool Aprovado { get; private set; }
    }
}