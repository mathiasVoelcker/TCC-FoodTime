namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinhaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "schemaFoodTime.Estabelecimento_Recusado",
                c => new
                    {
                        Id_Usuario = c.Int(nullable: false),
                        Id_Estabelecimento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Usuario, t.Id_Estabelecimento })
                .ForeignKey("schemaFoodTime.Usuario", t => t.Id_Usuario, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Estabelecimento", t => t.Id_Estabelecimento, cascadeDelete: true)
                .Index(t => t.Id_Usuario)
                .Index(t => t.Id_Estabelecimento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("schemaFoodTime.Estabelecimento_Recusado", "Id_Estabelecimento", "schemaFoodTime.Estabelecimento");
            DropForeignKey("schemaFoodTime.Estabelecimento_Recusado", "Id_Usuario", "schemaFoodTime.Usuario");
            DropIndex("schemaFoodTime.Estabelecimento_Recusado", new[] { "Id_Estabelecimento" });
            DropIndex("schemaFoodTime.Estabelecimento_Recusado", new[] { "Id_Usuario" });
            DropTable("schemaFoodTime.Estabelecimento_Recusado");
        }
    }
}
