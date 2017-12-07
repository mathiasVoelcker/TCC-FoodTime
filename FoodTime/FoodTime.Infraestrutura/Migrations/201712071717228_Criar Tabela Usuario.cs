namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarTabelaUsuario : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("schemaFoodTime.Usuario");
        }
    }
}
