using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;


namespace Infra.Mappings
{
    [DbContext(typeof(Context.CodeContext))]
    public class NotificationMap
    {
        public NotificationMap(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable("Notificacao");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                 .HasColumnName("Id")
                 .ValueGeneratedOnAdd();

            builder.Property(t => t.Tipo)
                .HasColumnName("Tipo")
                .IsRequired();

            builder.Property(t => t.Mensagem)
                .HasColumnName("Mensagem")
                .IsRequired();

            builder.Property(t => t.EmailDestinatario)
                .HasColumnName("EmailDestinatario");

            builder.Property(t => t.EmailOrigem)
                .HasColumnName("EmailOrigem");

            builder.Property(t => t.NumDestinario)
                .HasColumnName("NumDestinario");

            builder.Property(t => t.Assunto)
                .HasColumnName("Assunto")
                .IsRequired();

            builder.Property(t => t.Cliente)
                .HasColumnName("Cliente")
                .IsRequired();

            builder.Property(t => t.NomeUsuario)
                .HasColumnName("NomeUsuario")
                .IsRequired();
        }

    }
}

