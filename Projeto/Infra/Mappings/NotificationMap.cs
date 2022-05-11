using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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

            builder.Property(t => t.Body)
                   .HasColumnName("Corpo")
                    .IsRequired();
        }

    }
}

