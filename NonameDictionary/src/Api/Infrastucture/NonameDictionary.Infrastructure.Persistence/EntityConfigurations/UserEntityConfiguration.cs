using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NonameDictionary.Api.Domain.Models;
using NonameDictionary.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Infrastructure.Persistence.EntityConfigurations
{
    public class UserEntityConfiguration:BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user",NonameDictionaryContext.DEFAULT_SCHEMA);
        }
    }
}
