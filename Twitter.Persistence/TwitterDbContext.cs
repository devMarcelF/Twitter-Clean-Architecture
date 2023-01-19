using Microsoft.EntityFrameworkCore;
using Twitter.Application.Contracts;
using Twitter.Domain.Common;
using Twitter.Domain.Entities;

namespace Twitter.Persistence
{
    public class TwitterDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public TwitterDbContext(DbContextOptions<TwitterDbContext> options) : base(options)
        {
        }

        public TwitterDbContext(DbContextOptions<TwitterDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<TwitterStatistic> TwitterStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterDbContext).Assembly);

            //seed data
            modelBuilder.Entity<TwitterStatistic>().HasData(new TwitterStatistic
            {
                Id = 1,
                NumberOfTweets = 1000,
                Hashtag = "#brasil#saopaulo#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan",
                CreatedDate= DateTime.Now
            });

            modelBuilder.Entity<TwitterStatistic>().HasData(new TwitterStatistic
            {
                Id = 2,
                NumberOfTweets = 2000,
                Hashtag = "#usa#tampa#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan",
                CreatedDate = DateTime.Now.AddDays(-1)
            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
