namespace TrabalhoLocadoraMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocacoesToCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tituloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Sinopse = c.String(nullable: false),
                        OrigemTitulo = c.String(nullable: false, maxLength: 100),
                        Ano = c.Short(nullable: false),
                        TipoTituloId = c.Int(nullable: false),
                        TipoTitulo_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoTituloes", t => t.TipoTitulo_Id)
                .Index(t => t.TipoTitulo_Id);
            
            CreateTable(
                "dbo.Copias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TituloId = c.Int(nullable: false),
                        TipoCopiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCopias", t => t.TipoCopiaId, cascadeDelete: true)
                .ForeignKey("dbo.Tituloes", t => t.TituloId, cascadeDelete: true)
                .Index(t => t.TipoCopiaId)
                .Index(t => t.TituloId);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        CopiaId = c.Int(nullable: false),
                        DataLocacao = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(),
                        Copia_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Copias", t => t.Copia_Id)
                .Index(t => t.ClienteId)
                .Index(t => t.Copia_Id);
            
            CreateTable(
                "dbo.TipoCopias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoTituloes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TituloAtors",
                c => new
                    {
                        Titulo_Id = c.Int(nullable: false),
                        Ator_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Titulo_Id, t.Ator_Id })
                .ForeignKey("dbo.Tituloes", t => t.Titulo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ators", t => t.Ator_Id, cascadeDelete: true)
                .Index(t => t.Titulo_Id)
                .Index(t => t.Ator_Id);
            
            CreateTable(
                "dbo.GeneroTituloes",
                c => new
                    {
                        Genero_Id = c.Long(nullable: false),
                        Titulo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genero_Id, t.Titulo_Id })
                .ForeignKey("dbo.Generoes", t => t.Genero_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tituloes", t => t.Titulo_Id, cascadeDelete: true)
                .Index(t => t.Genero_Id)
                .Index(t => t.Titulo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tituloes", "TipoTitulo_Id", "dbo.TipoTituloes");
            DropForeignKey("dbo.GeneroTituloes", "Titulo_Id", "dbo.Tituloes");
            DropForeignKey("dbo.GeneroTituloes", "Genero_Id", "dbo.Generoes");
            DropForeignKey("dbo.Copias", "TituloId", "dbo.Tituloes");
            DropForeignKey("dbo.Copias", "TipoCopiaId", "dbo.TipoCopias");
            DropForeignKey("dbo.Locacaos", "Copia_Id", "dbo.Copias");
            DropForeignKey("dbo.Locacaos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.TituloAtors", "Ator_Id", "dbo.Ators");
            DropForeignKey("dbo.TituloAtors", "Titulo_Id", "dbo.Tituloes");
            DropIndex("dbo.Tituloes", new[] { "TipoTitulo_Id" });
            DropIndex("dbo.GeneroTituloes", new[] { "Titulo_Id" });
            DropIndex("dbo.GeneroTituloes", new[] { "Genero_Id" });
            DropIndex("dbo.Copias", new[] { "TituloId" });
            DropIndex("dbo.Copias", new[] { "TipoCopiaId" });
            DropIndex("dbo.Locacaos", new[] { "Copia_Id" });
            DropIndex("dbo.Locacaos", new[] { "ClienteId" });
            DropIndex("dbo.TituloAtors", new[] { "Ator_Id" });
            DropIndex("dbo.TituloAtors", new[] { "Titulo_Id" });
            DropTable("dbo.GeneroTituloes");
            DropTable("dbo.TituloAtors");
            DropTable("dbo.TipoTituloes");
            DropTable("dbo.Generoes");
            DropTable("dbo.TipoCopias");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Copias");
            DropTable("dbo.Tituloes");
            DropTable("dbo.Ators");
        }
    }
}
