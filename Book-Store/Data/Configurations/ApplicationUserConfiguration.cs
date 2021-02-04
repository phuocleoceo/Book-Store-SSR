using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Book_Store.Models;

namespace Book_Store.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(x => x.Company).WithMany(x => x.ApplicationUsers)
                                          .HasForeignKey(x => x.CompanyId);

            builder.HasData
            (
                new ApplicationUser
                {
                    Name = "Trương Minh Phước",
                    StreetAddress = "08 Hà Văn Tính",
                    District = "Liên Chiểu",
                    ProvinceOrCity = "Đà Nẵng",
                    PostalCode = "550000",
                    CompanyId = 1
                }
            );
        }
    }
}
