namespace TrabalhoLocadoraMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Nascimento = c.DateTime(nullable: false),
                        Endereco = c.String(maxLength: 200),
                        NumeroEndereco = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 50),
                        Complemento = c.String(maxLength: 50),
                        Cidade = c.String(maxLength: 50),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
            DropTable("dbo.Clientes");
        }
    }
}
