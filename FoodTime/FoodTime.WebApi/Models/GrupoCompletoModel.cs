﻿using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class GrupoCompletoModel
    {
        public GrupoCompletoModel(Grupo grupo)
        {
            Nome = grupo.Nome;
            Foto = grupo.Foto;
            GrupoUsuarios = new List<GrupoUsuario>();
        }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public List<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}