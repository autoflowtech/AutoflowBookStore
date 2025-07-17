using Autoflow;
using Autoflow.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AutoflowDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AutoflowDbContext>();
    SeedData(context);
}

app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

void SeedData(AutoflowDbContext context)
{
    if (!context.Books.Any())
    {
        context.Books.AddRange(
            new Book { Id = 100, Name = "To Kill a Mockingbird", Author = "Harper Lee", Language = "English", Price = 12.99f },
            new Book { Id = 101, Name = "1984", Author = "George Orwell", Language = "English", Price = 9.99f },
            new Book { Id = 102, Name = "Pride and Prejudice", Author = "Jane Austen", Language = "English", Price = 8.49534f },
            new Book { Id = 103, Name = "The Great Gatsby", Language = "English", Price = 10.50f },
            new Book { Id = 104, Name = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Language = "Spa", Price = 14.99f },
            new Book { Id = 105, Name = "The Alchemist", Author = "Paulo Coelho", Language = "Portuguese", Price = 11.99f },
            new Book { Id = 106, Name = "Crime and Punishment", Author = "Fyodor Dostoevsky", Language = "Russian", Price = 13.4924f },
            new Book { Id = 107, Name = "The Catcher in the Rye", Author = "J.D. Salinger", Language = "English", Price = 9.49f },
            new Book { Id = 108, Name = "The Hobbit", Author = "J.R.R. Tolkien", Language = "EN", Price = 15.99111f },
            new Book { Id = 109, Name = "Les Misérables", Language = "French", Price = 12.49f },
            new Book { Id = 110, Name = "The Kite Runner", Author = "Khaled Hosseini", Language = "ENG", Price = 10.99000001f },
            new Book { Id = 111, Name = "Don Quixote", Author = "Miguel de Cervantes", Language = "Spanish", Price = 16.99f },
            new Book { Id = 112, Name = "The Book Thief", Author = "Markus Zusak", Price = 9.99f },
            new Book { Id = 113, Name = "War and Peace", Author = "Leo Tolstoy", Language = "Rusian", Price = 18.99f },
            new Book { Id = 114, Name = "The Little Prince", Author = "Antoine de Saint-Exupéry", Language = "Fnch", Price = 7.99f },
            new Book { Id = 115, Name = "Brave New World", Author = "Aldous Huxley", Language = "ENGLISH", Price = 11.49f }
        );
        
        context.SaveChanges();
    }
}