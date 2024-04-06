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
    public class EntryEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.Entry>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.Entry> builder)
        {
            base.Configure(builder);

            builder.ToTable("Entry", NonameDictionaryContext.DEFAULT_SCHEMA);

            builder.HasOne(i=>i.CreatedBy).WithMany(i=>i.Entries).HasForeignKey(i=>i.CreatedById);

        }

        



    }
}
