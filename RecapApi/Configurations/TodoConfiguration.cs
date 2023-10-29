using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecapApi.Entities;

namespace RecapApi.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        var todos = new List<Todo>
        {
            new()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "Todo #1",
                Description = "This is the description for Todo #1",
                Completed = false
            },
            new()
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "Todo #2",
                Description = "This is the description for Todo #2",
                Completed = true
            },
            new()
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                UserId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Title = "Todo #3",
                Description = "This is the description for Todo #3",
                Completed = false
            }
        };

        builder.HasData(todos);
    }
}