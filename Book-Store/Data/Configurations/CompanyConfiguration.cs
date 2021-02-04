using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Book_Store.Models;

namespace Book_Store.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    Id = 1,
                    Name = "MIT",
                    StreetAddress = "Không biết",
                    District = "Hải Châu",
                    ProvinceOrCity = "Đà Nẵng",
                    PostalCode = "55000",
                    PhoneNumber = "0123456789",
                    IsAuthorizedCompany = true
                }
            );
        }
    }
}
