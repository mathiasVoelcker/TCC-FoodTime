namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverColunaApartamento1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("schemaFoodTime.Endereco", "Apto");
        }
        
        public override void Down()
        {
            AddColumn("schemaFoodTime.Endereco", "Apto", c => c.String());
        }
    }
}
