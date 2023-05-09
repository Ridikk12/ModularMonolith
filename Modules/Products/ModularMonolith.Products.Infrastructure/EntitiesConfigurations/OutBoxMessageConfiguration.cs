//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using ModularMonolith.Contracts.Entities;

//namespace ModularMonolith.Products.Infrastructure.EntitiesConfigurations
//{
//    public class OutBoxMessageConfiguration : IEntityTypeConfiguration<OutBoxMessage>
//    {
//        public void Configure(EntityTypeBuilder<OutBoxMessage> builder)
//        {
//            builder.ToTable("OutboxMessages", "out");
//            builder.HasKey(x => x.Id);
//        }
//    }
//}
