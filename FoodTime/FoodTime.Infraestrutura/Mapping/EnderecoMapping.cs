﻿using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace FoodTime.Infraestrutura.Mapping
{
    class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMapping()
        {
            ToTable("Endereco", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Apto).HasMaxLength(20).IsRequired();
            Property(x => x.Bairro).HasMaxLength(50).IsRequired();
            Property(x => x.CEP).HasMaxLength(8).IsRequired();
            Property(x => x.Cidade).HasMaxLength(50).IsRequired();
            Property(x => x.Complemento).HasMaxLength(50).IsRequired();
            Property(x => x.Estado).HasMaxLength(50).IsRequired();
            Property(x => x.Latitude).IsRequired();
            Property(x => x.Longitude).IsRequired();
            Property(x => x.Numero).HasMaxLength(20).IsRequired();
            Property(x => x.Rua).HasMaxLength(50).IsRequired();


        }
    }
}