using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Db.Migrations
{
    public partial class SetupData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblGenre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "tblMovie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    YearOfRelease = table.Column<int>(nullable: false),
                    RunningTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tblMovieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovieGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMovieGenre_tblGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMovieGenre_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    MovieRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,1)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating", x => x.MovieRatingId);
                    table.ForeignKey(
                        name: "FK_tblRating_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRating_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Thriller" },
                    { 3, "Comedy" },
                    { 4, "Animation" },
                    { 5, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "MovieId", "RunningTime", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 10, 10, 121, "Hot Fuzz", 2007 },
                    { 9, 9, 108, "The Hangover", 2009 },
                    { 8, 8, 89, "The Lion King", 1994 },
                    { 7, 7, 125, "Incredibles 2", 2018 },
                    { 6, 6, 132, "Bridesmaids", 2011 },
                    { 4, 4, 139, "The Silence Of The Lambs", 1991 },
                    { 3, 3, 149, "Wonder Woman", 2017 },
                    { 2, 2, 182, "Avengers Endgame", 2019 },
                    { 1, 1, 94, "Road Trip", 2000 },
                    { 5, 5, 135, "It", 2017 }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "UserId", "Name" },
                values: new object[,]
                {
                    { 2, "Fred Smith" },
                    { 1, "Paul Saxton" },
                    { 3, "John Jones" }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 1, 3 },
                    { 5, 2, 4 },
                    { 6, 2, 5 },
                    { 7, 1, 6 },
                    { 8, 4, 7 },
                    { 9, 4, 8 },
                    { 10, 3, 9 },
                    { 11, 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "MovieRatingId", "MovieId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 9, 4, 1.4m, 2 },
                    { 6, 8, 2.4m, 2 },
                    { 4, 2, 4.249m, 2 },
                    { 3, 1, 4.5m, 2 },
                    { 14, 10, 3.8m, 1 },
                    { 1, 1, 4.5m, 1 },
                    { 11, 7, 3m, 1 },
                    { 7, 5, 4.94m, 1 },
                    { 5, 3, 3.8m, 1 },
                    { 2, 2, 4.249m, 1 },
                    { 10, 5, 4.94m, 2 },
                    { 13, 9, 3.8m, 1 },
                    { 12, 7, 3.8m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_GenreId",
                table: "tblMovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_MovieId",
                table: "tblMovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRating_MovieId",
                table: "tblRating",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRating_UserId",
                table: "tblRating",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblRating");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
