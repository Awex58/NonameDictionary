using Microsoft.EntityFrameworkCore;
using NonameDictionary.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Infrastructure.Persistence.Context
{
    public class NonameDictionaryContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public NonameDictionaryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }



        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }



        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries().Where(i => i.State == EntityState.Added).Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntities);
        }
        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach(var en in entities)
            {
                if(en.CreateDate == DateTime.MinValue)
                   en.CreateDate = DateTime.Now;
            }
        }
    }
}
