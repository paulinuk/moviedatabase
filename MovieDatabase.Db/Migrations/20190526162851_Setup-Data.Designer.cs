﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDatabase.Db;

namespace MovieDatabase.Db.Migrations
{
    [DbContext(typeof(MovieDatabaseContext))]
    [Migration("20190526162851_Setup-Data")]
    partial class SetupData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieDatabase.Common.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("GenreId");

                    b.ToTable("tblGenre");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "Thriller"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Animation"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("MovieDatabase.Common.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId");

                    b.Property<int>("RunningTime");

                    b.Property<string>("Title");

                    b.Property<int>("YearOfRelease");

                    b.HasKey("Id");

                    b.ToTable("tblMovie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieId = 1,
                            RunningTime = 94,
                            Title = "Road Trip",
                            YearOfRelease = 2000
                        },
                        new
                        {
                            Id = 2,
                            MovieId = 2,
                            RunningTime = 182,
                            Title = "Avengers Endgame",
                            YearOfRelease = 2019
                        },
                        new
                        {
                            Id = 3,
                            MovieId = 3,
                            RunningTime = 149,
                            Title = "Wonder Woman",
                            YearOfRelease = 2017
                        },
                        new
                        {
                            Id = 4,
                            MovieId = 4,
                            RunningTime = 139,
                            Title = "The Silence Of The Lambs",
                            YearOfRelease = 1991
                        },
                        new
                        {
                            Id = 5,
                            MovieId = 5,
                            RunningTime = 135,
                            Title = "It",
                            YearOfRelease = 2017
                        },
                        new
                        {
                            Id = 6,
                            MovieId = 6,
                            RunningTime = 132,
                            Title = "Bridesmaids",
                            YearOfRelease = 2011
                        },
                        new
                        {
                            Id = 7,
                            MovieId = 7,
                            RunningTime = 125,
                            Title = "Incredibles 2",
                            YearOfRelease = 2018
                        },
                        new
                        {
                            Id = 8,
                            MovieId = 8,
                            RunningTime = 89,
                            Title = "The Lion King",
                            YearOfRelease = 1994
                        },
                        new
                        {
                            Id = 9,
                            MovieId = 9,
                            RunningTime = 108,
                            Title = "The Hangover",
                            YearOfRelease = 2009
                        },
                        new
                        {
                            Id = 10,
                            MovieId = 10,
                            RunningTime = 121,
                            Title = "Hot Fuzz",
                            YearOfRelease = 2007
                        });
                });

            modelBuilder.Entity("MovieDatabase.Common.Models.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId");

                    b.Property<int>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("tblMovieGenre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 3,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 1,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 1,
                            MovieId = 3
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 2,
                            MovieId = 4
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 2,
                            MovieId = 5
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 1,
                            MovieId = 6
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 4,
                            MovieId = 7
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 4,
                            MovieId = 8
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 3,
                            MovieId = 9
                        },
                        new
                        {
                            Id = 11,
                            GenreId = 3,
                            MovieId = 10
                        });
                });

            modelBuilder.Entity("MovieDatabase.Common.Models.MovieRating", b =>
                {
                    b.Property<int>("MovieRatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,1)");

                    b.Property<int>("UserId");

                    b.HasKey("MovieRatingId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("tblRating");

                    b.HasData(
                        new
                        {
                            MovieRatingId = 1,
                            MovieId = 1,
                            Rating = 4.5m,
                            UserId = 1
                        },
                        new
                        {
                            MovieRatingId = 2,
                            MovieId = 2,
                            Rating = 4.249m,
                            UserId = 1
                        },
                        new
                        {
                            MovieRatingId = 3,
                            MovieId = 1,
                            Rating = 4.5m,
                            UserId = 2
                        },
                        new
                        {
                            MovieRatingId = 4,
                            MovieId = 2,
                            Rating = 4.249m,
                            UserId = 2
                        },
                        new
                        {
                            MovieRatingId = 5,
                            MovieId = 3,
                            Rating = 3.8m,
                            UserId = 1
                        },
                        new
                        {
                            MovieRatingId = 6,
                            MovieId = 8,
                            Rating = 2.4m,
                            UserId = 2
                        },
                        new
                        {
                            MovieRatingId = 7,
                            MovieId = 5,
                            Rating = 4.94m,
                            UserId = 1
                        },
                        new
                        {
                            MovieRatingId = 9,
                            MovieId = 4,
                            Rating = 1.4m,
                            UserId = 2
                        },
                        new
                        {
                            MovieRatingId = 10,
                            MovieId = 5,
                            Rating = 4.94m,
                            UserId = 2
                        },
                        new
                        {
                            MovieRatingId = 11,
                            MovieId = 7,
                            Rating = 3m,
                            UserId = 1
                        },
                        new
                        {
                            MovieRatingId = 12,
                            MovieId = 7,
                            Rating = 3.8m,
                            UserId = 2
                        },
                        new
                        {
                            MovieRatingId = 13,
                            MovieId = 9,
                            Rating = 3.8m,
                            UserId = 1
                        },
                        new
                        {
                            MovieRatingId = 14,
                            MovieId = 10,
                            Rating = 3.8m,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MovieDatabase.Common.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("tblUser");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Paul Saxton"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Fred Smith"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "John Jones"
                        });
                });

            modelBuilder.Entity("MovieDatabase.Common.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieDatabase.Common.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieDatabase.Common.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieDatabase.Common.Models.MovieRating", b =>
                {
                    b.HasOne("MovieDatabase.Common.Models.Movie", "Movie")
                        .WithMany("MovieRatings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieDatabase.Common.Models.User")
                        .WithMany("MovieRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
