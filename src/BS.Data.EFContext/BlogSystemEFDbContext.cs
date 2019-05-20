using BS.Data.EFContext.DataSeed;
using BS.Data.EFContext.ModelsConfig;
using BS.Data.Models;
using BS.Data.Models.Abstract.Author;
using BS.Data.Models.Abstract.EntityBase;
using BS.Identity.Models;
using DateTimeWrapper.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BS.Data.EFContext
{
    public class BlogSystemEFDbContext : IdentityDbContext<BaseIdentityUser>
    {
        private readonly IDateTimeWrapper dateTimeProvider;

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostTag> BlogPostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostEditor> BlogPostEditors { get; set; }

        public BlogSystemEFDbContext(DbContextOptions<BlogSystemEFDbContext> options, IDateTimeWrapper dateTimeProvider)
            : base(options)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(DefaultRolesDataSeed.SeedData());
            builder.Entity<Author>().HasData(AuthorDataSeed.SeedData());
            builder.Entity<BlogPost>().HasData(BlogPostDataSeed.SeedData());
            builder.Entity<BlogPostEditor>().HasData(BlogPostEditorDataSeed.SeedData());
            builder.Entity<Tag>().HasData(TagDataSeed.SeedData());
            builder.Entity<BlogPostTag>().HasData(BlogPostTagDataSeed.SeedData());

            this.ApplyModelConfigurations(builder);
            this.SeedDefaultAdmin(builder);

            base.OnModelCreating(builder);
        }

       

        private void ApplyModelConfigurations(ModelBuilder builder)
        {
           builder.ApplyConfiguration(new AuthorConfig());
           builder.ApplyConfiguration(new BlogPostConfig());
           builder.ApplyConfiguration(new BlogPostTagConfig());
           builder.ApplyConfiguration(new TagConfig());

        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletionRules();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletionRules();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyDeletionRules()
        {
            var entitiesForDeletion = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is IDeletable);

            foreach (var entry in entitiesForDeletion)
            {
                var entity = (IDeletable)entry.Entity;
                entity.DeletedOn = this.dateTimeProvider.Now();
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModifiable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IModifiable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = this.dateTimeProvider.Now();
                }
                else
                {
                    entity.ModifiedOn = this.dateTimeProvider.Now();
                }
            }
        }

        

        private void SeedDefaultAdmin(ModelBuilder builder)
        {
            var adminUser = new BaseIdentityUser
            {
                Id = "33e30ac8-a39b-4979-90a9-9d999e514bd0",
                UserName = "Admin1",
                NormalizedUserName = "admin1@mail.com".ToUpper(),
                Email = "admin1@mail.com",
                TwoFactorEnabled = false,
                NormalizedEmail = "admin1@mail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+359359",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                AccessFailedCount = 0,
                LockoutEnabled = false
            };

            var hashePass = new PasswordHasher<BaseIdentityUser>().HashPassword(adminUser, "!Aa12345678");
            adminUser.PasswordHash = hashePass;

            builder.Entity<BaseIdentityUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = 1.ToString(),
                UserId = adminUser.Id
            });
        }
    }
}
