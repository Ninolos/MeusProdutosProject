using DevIO.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Mappings
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(x => x.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            Property(c => c.Imagem)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(f => f.FornecedorId);

            ToTable("Produtos");
        }
    }
}
