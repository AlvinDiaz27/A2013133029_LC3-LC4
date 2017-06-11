namespace _2013105920_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cuenta", "BaseDatosId", "dbo.BaseDatos");
            DropIndex("dbo.Cuenta", new[] { "BaseDatosId" });
            RenameColumn(table: "dbo.Cuenta", name: "BaseDatosId", newName: "BaseDatos_BaseDatosId");
            AlterColumn("dbo.Cuenta", "BaseDatos_BaseDatosId", c => c.Int());
            CreateIndex("dbo.Cuenta", "BaseDatos_BaseDatosId");
            AddForeignKey("dbo.Cuenta", "BaseDatos_BaseDatosId", "dbo.BaseDatos", "BaseDatosId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuenta", "BaseDatos_BaseDatosId", "dbo.BaseDatos");
            DropIndex("dbo.Cuenta", new[] { "BaseDatos_BaseDatosId" });
            AlterColumn("dbo.Cuenta", "BaseDatos_BaseDatosId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Cuenta", name: "BaseDatos_BaseDatosId", newName: "BaseDatosId");
            CreateIndex("dbo.Cuenta", "BaseDatosId");
            AddForeignKey("dbo.Cuenta", "BaseDatosId", "dbo.BaseDatos", "BaseDatosId", cascadeDelete: true);
        }
    }
}
