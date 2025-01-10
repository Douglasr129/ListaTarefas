using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.ToTable("Produtos");
        }
    }
}
