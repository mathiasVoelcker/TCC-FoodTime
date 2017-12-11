namespace FoodTime.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarGrupos : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "schemaFoodTime.Foto", name: "Id_Estabelecimzento", newName: "Id_Estabelecimento");
            RenameIndex(table: "schemaFoodTime.Foto", name: "IX_Id_Estabelecimzento", newName: "IX_Id_Estabelecimento");
            CreateTable(
                "schemaFoodTime.Grupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Imagem = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "schemaFoodTime.GrupoUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aprovado = c.Boolean(nullable: false),
                        Id_Grupo = c.Int(nullable: false),
                        Id_Usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("schemaFoodTime.Grupo", t => t.Id_Grupo, cascadeDelete: true)
                .ForeignKey("schemaFoodTime.Usuario", t => t.Id_Usuario, cascadeDelete: true)
                .Index(t => t.Id_Grupo)
                .Index(t => t.Id_Usuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("schemaFoodTime.GrupoUsuario", "Id_Usuario", "schemaFoodTime.Usuario");
            DropForeignKey("schemaFoodTime.GrupoUsuario", "Id_Grupo", "schemaFoodTime.Grupo");
            DropIndex("schemaFoodTime.GrupoUsuario", new[] { "Id_Usuario" });
            DropIndex("schemaFoodTime.GrupoUsuario", new[] { "Id_Grupo" });
            DropTable("schemaFoodTime.GrupoUsuario");
            DropTable("schemaFoodTime.Grupo");
            RenameIndex(table: "schemaFoodTime.Foto", name: "IX_Id_Estabelecimento", newName: "IX_Id_Estabelecimzento");
            RenameColumn(table: "schemaFoodTime.Foto", name: "Id_Estabelecimento", newName: "Id_Estabelecimzento");
        }
    }
}
