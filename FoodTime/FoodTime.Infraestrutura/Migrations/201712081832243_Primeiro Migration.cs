namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiroMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "schemaFoodTime.Avaliacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nota = c.Int(nullable: false),
                        PrecoMedio = c.Decimal(nullable: false, precision: 7, scale: 2),
                        Comentario = c.String(nullable: false, maxLength: 500),
                        FotoAvaliacao = c.String(nullable: false, maxLength: 500),
                        Recomendado = c.Boolean(nullable: false),
                        DataAvaliacao = c.DateTime(nullable: false),
                        IdEstabelecimento = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("schemaFoodTime.Estabelecimento", t => t.IdEstabelecimento, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdEstabelecimento)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "schemaFoodTime.Estabelecimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Telefone = c.String(nullable: false, maxLength: 12),
                        HorarioAbertura = c.DateTime(nullable: false),
                        HorarioFechamento = c.DateTime(nullable: false),
                        PrecoMedio = c.Decimal(nullable: false, precision: 7, scale: 2),
                        Id_Endereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("schemaFoodTime.Endereco", t => t.Id_Endereco, cascadeDelete: true)
                .Index(t => t.Id_Endereco);
            
            CreateTable(
                "schemaFoodTime.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "schemaFoodTime.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(nullable: false, maxLength: 50),
                        Numero = c.String(nullable: false, maxLength: 20),
                        Apto = c.String(nullable: false, maxLength: 20),
                        Complemento = c.String(nullable: false, maxLength: 50),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        Estado = c.String(nullable: false, maxLength: 50),
                        CEP = c.String(nullable: false, maxLength: 8),
                        Latitude = c.Decimal(nullable: false, precision: 10, scale: 7),
                        Longitude = c.Decimal(nullable: false, precision: 10, scale: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "schemaFoodTime.Foto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false, maxLength: 500),
                        Id_Estabelecimzento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("schemaFoodTime.Estabelecimento", t => t.Id_Estabelecimzento, cascadeDelete: true)
                .Index(t => t.Id_Estabelecimzento);
            
            CreateTable(
                "schemaFoodTime.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 150),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataNascimento = c.DateTime(nullable: false),
                        Sobrenome = c.String(nullable: false, maxLength: 50),
                        FotoPerfil = c.String(nullable: false, maxLength: 500),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "schemaFoodTime.Preferencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        Aprovado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "schemaFoodTime.Estabelecimento_Preferencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aprovado = c.Boolean(nullable: false),
                        Id_Estabelecimento = c.Int(nullable: false),
                        Id_Preferencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("schemaFoodTime.Estabelecimento", t => t.Id_Estabelecimento, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Preferencia", t => t.Id_Preferencia, cascadeDelete: true)
                .Index(t => t.Id_Estabelecimento)
                .Index(t => t.Id_Preferencia);
            
            CreateTable(
                "schemaFoodTime.Estabelecimento_Categoria",
                c => new
                    {
                        Id_Estabelecimento = c.Int(nullable: false),
                        Id_Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Estabelecimento, t.Id_Categoria })
                .ForeignKey("schemaFoodTime.Estabelecimento", t => t.Id_Estabelecimento, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Categoria", t => t.Id_Categoria, cascadeDelete: true)
                .Index(t => t.Id_Estabelecimento)
                .Index(t => t.Id_Categoria);
            
            CreateTable(
                "schemaFoodTime.Usuario_Preferencia",
                c => new
                    {
                        Id_Usuario = c.Int(nullable: false),
                        Id_Preferencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Usuario, t.Id_Preferencia })
                .ForeignKey("schemaFoodTime.Usuario", t => t.Id_Usuario, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Preferencia", t => t.Id_Preferencia, cascadeDelete: true)
                .Index(t => t.Id_Usuario)
                .Index(t => t.Id_Preferencia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("schemaFoodTime.Estabelecimento_Preferencia", "Id_Preferencia", "schemaFoodTime.Preferencia");
            DropForeignKey("schemaFoodTime.Estabelecimento_Preferencia", "Id_Estabelecimento", "schemaFoodTime.Estabelecimento");
            DropForeignKey("schemaFoodTime.Avaliacao", "IdUsuario", "schemaFoodTime.Usuario");
            DropForeignKey("schemaFoodTime.Usuario_Preferencia", "Id_Preferencia", "schemaFoodTime.Preferencia");
            DropForeignKey("schemaFoodTime.Usuario_Preferencia", "Id_Usuario", "schemaFoodTime.Usuario");
            DropForeignKey("schemaFoodTime.Avaliacao", "IdEstabelecimento", "schemaFoodTime.Estabelecimento");
            DropForeignKey("schemaFoodTime.Foto", "Id_Estabelecimzento", "schemaFoodTime.Estabelecimento");
            DropForeignKey("schemaFoodTime.Estabelecimento", "Id_Endereco", "schemaFoodTime.Endereco");
            DropForeignKey("schemaFoodTime.Estabelecimento_Categoria", "Id_Categoria", "schemaFoodTime.Categoria");
            DropForeignKey("schemaFoodTime.Estabelecimento_Categoria", "Id_Estabelecimento", "schemaFoodTime.Estabelecimento");
            DropIndex("schemaFoodTime.Usuario_Preferencia", new[] { "Id_Preferencia" });
            DropIndex("schemaFoodTime.Usuario_Preferencia", new[] { "Id_Usuario" });
            DropIndex("schemaFoodTime.Estabelecimento_Categoria", new[] { "Id_Categoria" });
            DropIndex("schemaFoodTime.Estabelecimento_Categoria", new[] { "Id_Estabelecimento" });
            DropIndex("schemaFoodTime.Estabelecimento_Preferencia", new[] { "Id_Preferencia" });
            DropIndex("schemaFoodTime.Estabelecimento_Preferencia", new[] { "Id_Estabelecimento" });
            DropIndex("schemaFoodTime.Foto", new[] { "Id_Estabelecimzento" });
            DropIndex("schemaFoodTime.Estabelecimento", new[] { "Id_Endereco" });
            DropIndex("schemaFoodTime.Avaliacao", new[] { "IdUsuario" });
            DropIndex("schemaFoodTime.Avaliacao", new[] { "IdEstabelecimento" });
            DropTable("schemaFoodTime.Usuario_Preferencia");
            DropTable("schemaFoodTime.Estabelecimento_Categoria");
            DropTable("schemaFoodTime.Estabelecimento_Preferencia");
            DropTable("schemaFoodTime.Preferencia");
            DropTable("schemaFoodTime.Usuario");
            DropTable("schemaFoodTime.Foto");
            DropTable("schemaFoodTime.Endereco");
            DropTable("schemaFoodTime.Categoria");
            DropTable("schemaFoodTime.Estabelecimento");
            DropTable("schemaFoodTime.Avaliacao");
        }
    }
}
