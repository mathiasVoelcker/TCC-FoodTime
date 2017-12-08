namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarTabeladeAvaliacao : DbMigration
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
                .ForeignKey("dbo.Estabelecimentoes", t => t.IdEstabelecimento, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdEstabelecimento)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Estabelecimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        HorarioAbertura = c.DateTime(nullable: false),
                        HorarioFechamento = c.DateTime(nullable: false),
                        PrecoMedio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Estabelecimento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estabelecimentoes", t => t.Estabelecimento_Id)
                .Index(t => t.Estabelecimento_Id);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(),
                        Numero = c.String(),
                        Apto = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        CEP = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Preferencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Aprovado = c.Boolean(nullable: false),
                        Estabelecimento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estabelecimentoes", t => t.Estabelecimento_Id)
                .Index(t => t.Estabelecimento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("schemaFoodTime.Avaliacao", "IdUsuario", "schemaFoodTime.Usuario");
            DropForeignKey("schemaFoodTime.Avaliacao", "IdEstabelecimento", "dbo.Estabelecimentoes");
            DropForeignKey("dbo.Preferencias", "Estabelecimento_Id", "dbo.Estabelecimentoes");
            DropForeignKey("dbo.Estabelecimentoes", "Endereco_Id", "dbo.Enderecoes");
            DropForeignKey("dbo.Categorias", "Estabelecimento_Id", "dbo.Estabelecimentoes");
            DropIndex("dbo.Preferencias", new[] { "Estabelecimento_Id" });
            DropIndex("dbo.Categorias", new[] { "Estabelecimento_Id" });
            DropIndex("dbo.Estabelecimentoes", new[] { "Endereco_Id" });
            DropIndex("schemaFoodTime.Avaliacao", new[] { "IdUsuario" });
            DropIndex("schemaFoodTime.Avaliacao", new[] { "IdEstabelecimento" });
            DropTable("dbo.Preferencias");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Estabelecimentoes");
            DropTable("schemaFoodTime.Avaliacao");
        }
    }
}
