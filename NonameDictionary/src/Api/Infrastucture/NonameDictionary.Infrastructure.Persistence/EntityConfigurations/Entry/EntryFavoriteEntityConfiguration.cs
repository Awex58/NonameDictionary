using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NonameDictionary.Api.Domain.Models;
using NonameDictionary.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration:BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);
            builder.ToTable("entryfavorite", NonameDictionaryContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry).WithMany(i => i.EntryFavorites).HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser).WithMany(i => i.EntryFavorites).HasForeignKey(i => i.CreatedById);

        }
    }
}
