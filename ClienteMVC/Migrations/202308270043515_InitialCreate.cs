namespace ClienteMVC.Migrations
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
                        Nome = c.String(nullable: false),
                        Rg = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        DataExpecicao = c.DateTime(nullable: false),
                        OrgaoExpedicao = c.String(nullable: false),
                        UfCli = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false),
                        EstadoCivil = c.String(nullable: false),
                        CEP = c.String(nullable: false),
                        Logradouro = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Uf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
