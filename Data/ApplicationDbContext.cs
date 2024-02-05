using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppModel.Models;

namespace DataBaseComplete
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book_Author> Book_Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations
            // Many-to-Many: Book and Author
            modelBuilder.Entity<Book_Author>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<Book_Author>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
            // One-to-Many: Book and Publisher
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            //ObjectCreating
            //Authors
            modelBuilder.Entity<Author>()
               .HasData(
                    new Author()
                    {
                        AuthorId = 1,
                        FirstName = "Stanisław",
                        LastName = "Lem",
                        DateOfBirth = new DateTime(1921, 9, 12),
                        CountryOfOrigin = "Poland",
                    },
                    new Author()
                    {
                        AuthorId = 2,
                        FirstName = "Robert C.",
                        LastName = "Martin",
                        DateOfBirth = new DateTime(1952, 12, 5),
                        CountryOfOrigin = "America",
                    },
                    new Author()
                    {
                        AuthorId = 3,
                        FirstName = "Erich",
                        LastName = "Gamma",
                        DateOfBirth = new DateTime(1961, 3, 13),
                        CountryOfOrigin = "Switzerland",
                    },
                    new Author()
                    {
                        AuthorId = 4,
                        FirstName = "Richard",
                        LastName = "Helm",
                        DateOfBirth = new DateTime(9999, 1, 1),
                        CountryOfOrigin = ""
                    },
                    new Author()
                    {
                        AuthorId = 5,
                        FirstName = "Ralph",
                        LastName = "Johnson",
                        DateOfBirth = new DateTime(9999, 1, 1),
                        CountryOfOrigin = "",
                    },
                    new Author()
                    {
                        AuthorId = 6,
                        FirstName = "John",
                        LastName = "Vlissides",
                        DateOfBirth = new DateTime(1961, 8, 2),
                        CountryOfOrigin = "America",
                    },
                    new Author()
                    {
                        AuthorId = 7,
                        FirstName = "Walter",
                        LastName = "Isaacson",
                        DateOfBirth = new DateTime(1952, 3, 20),
                        CountryOfOrigin = "America",
                    }
                );
            //Publishers
            modelBuilder.Entity<Publisher>()
                .HasData(
                    new Publisher()
                    {
                        PublisherId = 1,
                        Name = "Wydawnictwo Literackie",
                        Address = "Długa 1, 31-147 Kraków",
                        YearFounded = 1953,
                    },
                    new Publisher()
                    {
                        PublisherId = 2,
                        Name = "Helion",
                        Address = "Kościuszki 1c, 44-100 Gliwice",
                        YearFounded = 1991,
                    },
                    new Publisher()
                    {
                        PublisherId = 3,
                        Name = "Insignis",	
                        Address = "Lubicz 17d, 31-503 Kraków",
                        YearFounded = 1991,
                    }
                );
            //Books
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    BookId = 1,
                    Title = "Cyberiada",
                    Genre = "Fantastyka naukowa",
                    PublicationYear = 1965,
                    PublisherId = 1
                },
                new Book()
                {
                    BookId = 2,
                    Title = "Niezwyciężony",
                    Genre = "Fantastyka naukowa",
                    PublicationYear = 1964,
                    PublisherId = 1
                },
                 new Book()
                 {
                     BookId = 3,
                     Title = "Eden",
                     Genre = "Fantastyka naukowa",
                     PublicationYear = 1958,
                     PublisherId = 1
                 },
                 new Book()
                 {
                     BookId = 4,
                     Title = "Wzorce projektowe",
                     Genre = "Informatyka",
                     PublicationYear = 1994,
                     PublisherId = 2,
                 },
                 new Book()
                 {
                     BookId = 5,
                     Title = "The Code Breaker",
                     Genre = "Non-fiction",
                     PublicationYear = 2021,
                     PublisherId = 3,
                 },
                 new Book()
                 {
                     BookId = 6,
                     Title = "Steve Jobs",
                     Genre = "Biografia",
                     PublicationYear = 2011,
                     PublisherId = 3,
                 },
                 new Book()
                 {
                     BookId = 7,
                     Title = "Czysty kod. Podręcznik dobrego programisty",
                     Genre = "Informatyka",
                     PublicationYear = 2008,
                     PublisherId = 2,
                 }
            );
            //Books_Authors
            modelBuilder.Entity<Book_Author>().HasData(
                new Book_Author()
                {
                    Id = 1,
                    BookId = 1,//Cyberiada
                    AuthorId = 1,//Lem
                },
                new Book_Author()
                {
                    Id = 2,
                    BookId = 2,//Niezwyciężony
                    AuthorId = 1,//Lem
                },
                new Book_Author()
                {
                    Id = 3,
                    BookId = 3,//Eden
                    AuthorId = 1,//Lem
                },
                new Book_Author()
                {
                    Id = 4,
                    BookId = 4,//Wzorce projektowe
                    AuthorId = 3,//Gamma
                },
                new Book_Author()
                {
                    Id = 4,
                    BookId = 4,//Wzorce projektowe
                    AuthorId = 4,//Helm
                },
                new Book_Author()
                {
                    Id = 4,
                    BookId = 4,//Wzorce projektowe
                    AuthorId = 5,//Johnson
                },
                new Book_Author()
                {
                    Id = 4,
                    BookId = 4,//Wzorce projektowe
                    AuthorId = 6,//Vlissides
                },
                new Book_Author()
                {
                    Id = 5,
                    BookId = 5,//Code Breaker
                    AuthorId = 7,//Isaacson
                },
                new Book_Author()
                {
                    Id = 6,
                    BookId = 6,//S. Jobs
                    AuthorId = 7,//Isaacson
                },
                new Book_Author()
                {
                    Id = 7,
                    BookId = 7,//Czysty kod
                    AuthorId = 2,//Martin
                }
            );
        }
    }
}
