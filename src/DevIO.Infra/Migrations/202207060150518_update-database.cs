namespace DevIO.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Fornecedores", new[] { "Documento" });
            AlterColumn("dbo.Enderecos", "Estado", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Fornecedores", "Documento", c => c.String(nullable: false, maxLength: 14, unicode: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "IX_Documento",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                    },
                }));
            AlterColumn("dbo.Produtos", "Imagem", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Imagem", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Fornecedores", "Documento", c => c.String(nullable: false, maxLength: 14, unicode: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "IX_Documento",
                        new AnnotationValues(oldValue: "IndexAnnotation: { IsUnique: True }", newValue: null)
                    },
                }));
            AlterColumn("dbo.Enderecos", "Estado", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.Fornecedores", "Documento", unique: true);
        }
    }
}
