namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atribuiraprovadoaestabelecimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("schemaFoodTime.Estabelecimento", "Aprovado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("schemaFoodTime.Estabelecimento", "Aprovado");
        }
    }
}
