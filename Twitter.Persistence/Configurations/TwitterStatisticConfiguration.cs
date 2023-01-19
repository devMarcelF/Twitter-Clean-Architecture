using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Domain.Entities;

namespace Twitter.Persistence.Configurations
{
    public class TwitterStatisticConfiguration : IEntityTypeConfiguration<TwitterStatistic>
    {
        public void Configure(EntityTypeBuilder<TwitterStatistic> builder)
        {
            builder.Property(e => e.NumberOfTweets)
                .IsRequired();

            builder.Property(e => e.Hashtag)
                .IsRequired()
                .HasMaxLength(200);

            //builder.Property(e => e.Date)
            //    .IsRequired();
        }
    }
}
