using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.Persistence.Entities;

namespace Study.Persistence.Configuration
{
    public partial class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            builder.HasKey(l => l.Id);

            builder
                .HasOne(l => l.Course)
                .WithMany(c => c.Lessons);
        }
    }
}
