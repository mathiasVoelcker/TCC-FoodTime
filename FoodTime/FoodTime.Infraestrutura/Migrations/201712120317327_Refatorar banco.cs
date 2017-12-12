namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refatorarbanco : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "schemaFoodTime.GrupoUsuario", newName: "Grupo_Usuario");
            RenameColumn(table: "schemaFoodTime.Avaliacao", name: "IdEstabelecimento", newName: "Id_Estabelecimento");
            RenameColumn(table: "schemaFoodTime.Avaliacao", name: "IdUsuario", newName: "Id_Usuario");
            RenameIndex(table: "schemaFoodTime.Avaliacao", name: "IX_IdEstabelecimento", newName: "IX_Id_Estabelecimento");
            RenameIndex(table: "schemaFoodTime.Avaliacao", name: "IX_IdUsuario", newName: "IX_Id_Usuario");
            AddColumn("schemaFoodTime.Grupo", "Foto", c => c.String(nullable: false, maxLength: 500));
            DropColumn("schemaFoodTime.Grupo", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("schemaFoodTime.Grupo", "Imagem", c => c.String(nullable: false, maxLength: 500));
            DropColumn("schemaFoodTime.Grupo", "Foto");
            RenameIndex(table: "schemaFoodTime.Avaliacao", name: "IX_Id_Usuario", newName: "IX_IdUsuario");
            RenameIndex(table: "schemaFoodTime.Avaliacao", name: "IX_Id_Estabelecimento", newName: "IX_IdEstabelecimento");
            RenameColumn(table: "schemaFoodTime.Avaliacao", name: "Id_Usuario", newName: "IdUsuario");
            RenameColumn(table: "schemaFoodTime.Avaliacao", name: "Id_Estabelecimento", newName: "IdEstabelecimento");
            RenameTable(name: "schemaFoodTime.Grupo_Usuario", newName: "GrupoUsuario");
        }
    }
}
