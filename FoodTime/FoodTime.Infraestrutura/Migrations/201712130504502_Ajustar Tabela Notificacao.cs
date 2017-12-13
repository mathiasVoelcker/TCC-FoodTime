namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustarTabelaNotificacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "schemaFoodTime.Notificacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Visibilidade = c.Boolean(nullable: false),
                        Id_Estabelecimento = c.Int(),
                        Id_Grupo = c.Int(),
                        Id_Usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("schemaFoodTime.Estabelecimento", t => t.Id_Estabelecimento)
                .ForeignKey("schemaFoodTime.Grupo", t => t.Id_Grupo)
                .ForeignKey("schemaFoodTime.Usuario", t => t.Id_Usuario, cascadeDelete: true)
                .Index(t => t.Id_Estabelecimento)
                .Index(t => t.Id_Grupo)
                .Index(t => t.Id_Usuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("schemaFoodTime.Notificacao", "Id_Usuario", "schemaFoodTime.Usuario");
            DropForeignKey("schemaFoodTime.Notificacao", "Id_Grupo", "schemaFoodTime.Grupo");
            DropForeignKey("schemaFoodTime.Notificacao", "Id_Estabelecimento", "schemaFoodTime.Estabelecimento");
            DropIndex("schemaFoodTime.Notificacao", new[] { "Id_Usuario" });
            DropIndex("schemaFoodTime.Notificacao", new[] { "Id_Grupo" });
            DropIndex("schemaFoodTime.Notificacao", new[] { "Id_Estabelecimento" });
            DropTable("schemaFoodTime.Notificacao");
        }
    }
}
