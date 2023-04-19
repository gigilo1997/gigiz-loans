using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class UserLoanConfiguration : IEntityTypeConfiguration<UserLoan>
{
    public void Configure(EntityTypeBuilder<UserLoan> builder)
    {
        builder.Property(e => e.Amount).HasPrecision(19, 4);
        builder.OwnsOne(e => e.LoanPeriod);
    }
}
