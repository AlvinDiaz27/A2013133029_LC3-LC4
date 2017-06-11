namespace _2013105920_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATM",
                c => new
                    {
                        AtmId = c.Int(nullable: false, identity: true),
                        Mensaje = c.String(nullable: false, maxLength: 200),
                        idRanuraDeposito = c.Int(nullable: false),
                        idTeclado = c.Int(nullable: false),
                        idDispensadorEfectivo = c.Int(nullable: false),
                        idPantalla = c.Int(nullable: false),
                        idRetiro = c.Int(nullable: false),
                        idBaseDatos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtmId)
                .ForeignKey("dbo.BaseDatos", t => t.AtmId)
                .Index(t => t.AtmId);
            
            CreateTable(
                "dbo.BaseDatos",
                c => new
                    {
                        BaseDatosId = c.Int(nullable: false, identity: true),
                        AutentificarCuenta = c.Boolean(nullable: false),
                        ObtenerSaldoDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ObtenerSaldoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debitar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acreditar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Administrador = c.String(nullable: false, maxLength: 100),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BaseDatosId);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 100),
                        Apellidos = c.String(nullable: false, maxLength: 100),
                        NumeroCuenta = c.Int(nullable: false),
                        pin = c.Int(nullable: false),
                        saldo = c.String(nullable: false),
                        BaseDatosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CuentaId)
                .ForeignKey("dbo.BaseDatos", t => t.BaseDatosId, cascadeDelete: true)
                .Index(t => t.BaseDatosId);
            
            CreateTable(
                "dbo.Retiro",
                c => new
                    {
                        RetiroId = c.Int(nullable: false, identity: true),
                        Monto = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RetiroId)
                .ForeignKey("dbo.DispensadorEfectivo", t => t.RetiroId)
                .ForeignKey("dbo.Pantalla", t => t.RetiroId)
                .ForeignKey("dbo.Teclado", t => t.RetiroId)
                .ForeignKey("dbo.BaseDatos", t => t.RetiroId)
                .ForeignKey("dbo.ATM", t => t.RetiroId)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.DispensadorEfectivo",
                c => new
                    {
                        DispensadorefectivoId = c.Int(nullable: false, identity: true),
                        contador = c.Int(nullable: false),
                        AtmId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DispensadorefectivoId)
                .ForeignKey("dbo.ATM", t => t.DispensadorefectivoId)
                .Index(t => t.DispensadorefectivoId);
            
            CreateTable(
                "dbo.Pantalla",
                c => new
                    {
                        PantallaId = c.Int(nullable: false, identity: true),
                        AtmId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PantallaId)
                .ForeignKey("dbo.ATM", t => t.PantallaId)
                .Index(t => t.PantallaId);
            
            CreateTable(
                "dbo.Teclado",
                c => new
                    {
                        TecladoId = c.Int(nullable: false, identity: true),
                        idATM = c.Int(nullable: false),
                        idRetiro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TecladoId)
                .ForeignKey("dbo.ATM", t => t.TecladoId)
                .Index(t => t.TecladoId);
            
            CreateTable(
                "dbo.RanuraDeposito",
                c => new
                    {
                        RanuraDepositoId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        AtmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RanuraDepositoId)
                .ForeignKey("dbo.ATM", t => t.RanuraDepositoId)
                .Index(t => t.RanuraDepositoId);
            
            CreateTable(
                "dbo.CuentaRetiros",
                c => new
                    {
                        CuentaId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CuentaId, t.RetiroId })
                .ForeignKey("dbo.Retiro", t => t.CuentaId, cascadeDelete: true)
                .ForeignKey("dbo.Cuenta", t => t.RetiroId, cascadeDelete: true)
                .Index(t => t.CuentaId)
                .Index(t => t.RetiroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teclado", "TecladoId", "dbo.ATM");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.ATM");
            DropForeignKey("dbo.RanuraDeposito", "RanuraDepositoId", "dbo.ATM");
            DropForeignKey("dbo.Pantalla", "PantallaId", "dbo.ATM");
            DropForeignKey("dbo.DispensadorEfectivo", "DispensadorefectivoId", "dbo.ATM");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.BaseDatos");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Teclado");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Pantalla");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.DispensadorEfectivo");
            DropForeignKey("dbo.CuentaRetiros", "RetiroId", "dbo.Cuenta");
            DropForeignKey("dbo.CuentaRetiros", "CuentaId", "dbo.Retiro");
            DropForeignKey("dbo.Cuenta", "BaseDatosId", "dbo.BaseDatos");
            DropForeignKey("dbo.ATM", "AtmId", "dbo.BaseDatos");
            DropIndex("dbo.CuentaRetiros", new[] { "RetiroId" });
            DropIndex("dbo.CuentaRetiros", new[] { "CuentaId" });
            DropIndex("dbo.RanuraDeposito", new[] { "RanuraDepositoId" });
            DropIndex("dbo.Teclado", new[] { "TecladoId" });
            DropIndex("dbo.Pantalla", new[] { "PantallaId" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "DispensadorefectivoId" });
            DropIndex("dbo.Retiro", new[] { "RetiroId" });
            DropIndex("dbo.Cuenta", new[] { "BaseDatosId" });
            DropIndex("dbo.ATM", new[] { "AtmId" });
            DropTable("dbo.CuentaRetiros");
            DropTable("dbo.RanuraDeposito");
            DropTable("dbo.Teclado");
            DropTable("dbo.Pantalla");
            DropTable("dbo.DispensadorEfectivo");
            DropTable("dbo.Retiro");
            DropTable("dbo.Cuenta");
            DropTable("dbo.BaseDatos");
            DropTable("dbo.ATM");
        }
    }
}
