namespace MovieDatabase.Db
{
    using Microsoft.EntityFrameworkCore;
    using Common.Models;
    using Extensions;
    public class MovieDatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRating> Ratings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<User> Users { get; set; }

        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options)
            : base(options)
        {
            

        }

        public MovieDatabaseContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().ToTable("tblGenre");
            modelBuilder.Entity<Movie>().ToTable("tblMovie");
            modelBuilder.Entity<User>().ToTable("tblUser");
            modelBuilder.Entity<MovieRating>().ToTable("tblRating");
            modelBuilder.Entity<MovieGenre>().ToTable("tblMovieGenre");
            
            //This will only actually do something via migrations and only if the data has not already been migrated
            modelBuilder.Seed();
        }

    }
}
