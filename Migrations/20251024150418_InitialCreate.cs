using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tourism_App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "GETDATE()"),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    ChargePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[NumberOfPeople] * [ChargePerPerson]"),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    DestinationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Destinations_DestinationId1",
                        column: x => x.DestinationId1,
                        principalTable: "Destinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "Description", "ImageUrl", "Location", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "The City of Light, known for Eiffel Tower, Louvre Museum, and romantic ambiance. Explore the Seine River cruises, Montmartre's artistic charm, Notre-Dame Cathedral, and world-class cuisine including croissants and fine wines.", "https://images.unsplash.com/photo-1431274172761-fca41d930114?w=800&h=600&fit=crop", "France", "Paris, France", 1200m },
                    { 2, "A bustling metropolis blending traditional culture with cutting-edge technology. Visit Shibuya Crossing, ancient temples like Senso-ji, neon-lit districts, sushi restaurants, and experience bullet trains and futuristic skyscrapers.", "https://images.unsplash.com/photo-1540959733332-eab4deabeeaf?w=800&h=600&fit=crop", "Japan", "Tokyo, Japan", 1500m },
                    { 3, "Tropical paradise with beautiful beaches, temples, and vibrant culture. Relax on pristine beaches, hike volcanoes like Mount Batur, explore rice terraces in Ubud, and enjoy traditional Balinese dances and ceremonies.", "https://images.unsplash.com/photo-1537953773345-d172ccf13cf1?w=800&h=600&fit=crop", "Indonesia", "Bali, Indonesia", 800m },
                    { 4, "Ancient history meets modern charm in the Eternal City with Colosseum and Vatican. Wander through ancient Roman ruins, visit St. Peter's Basilica, toss coins in the Trevi Fountain, and savor authentic Italian pizza and gelato.", "https://images.unsplash.com/photo-1555992336-fb0d29498b13?w=800&h=600&fit=crop", "Italy", "Rome, Italy", 1100m },
                    { 5, "Luxury and innovation in the desert with Burj Khalifa and stunning architecture. Experience desert safaris, luxury shopping at Dubai Mall, indoor skiing at Ski Dubai, and breathtaking views from the world's tallest building.", "https://images.unsplash.com/photo-1512453979798-5ea266f8880c?w=800&h=600&fit=crop", "UAE", "Dubai, UAE", 1800m },
                    { 6, "Iconic Opera House and Harbour Bridge in a vibrant coastal city. Enjoy harbor cruises, relax at Bondi Beach, visit the Sydney Aquarium, and explore the Royal Botanic Gardens with stunning ocean views.", "https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9?w=800&h=600&fit=crop", "Australia", "Sydney, Australia", 2000m },
                    { 7, "Stunning sunsets and white-washed buildings overlooking the Aegean Sea. Discover blue-domed churches, volcanic beaches, ancient Minoan ruins, and enjoy local wines while watching spectacular Mediterranean sunsets.", "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff?w=800&h=600&fit=crop", "Greece", "Santorini, Greece", 1300m },
                    { 8, "Overwater bungalows and crystal-clear waters in paradise islands. Dive into coral reefs, enjoy private beach dinners, relax in luxury spas, and experience world-class snorkeling in the Indian Ocean's clearest waters.", "https://images.unsplash.com/photo-1573843981267-be1999ff37cd?w=800&h=600&fit=crop", "Maldives", "Maldives", 2500m },
                    { 9, "The iconic symbol of love, a magnificent white marble mausoleum built by Mughal Emperor Shah Jahan. Marvel at intricate Mughal architecture, reflective pools, and beautiful gardens, while learning about the legendary love story of Shah Jahan and Mumtaz Mahal.", "https://images.unsplash.com/photo-1587135941948-670b381f08ce?w=800&h=600&fit=crop", "India", "Taj Mahal, Agra, India", 600m },
                    { 10, "The Pink City with stunning palaces, forts, and vibrant culture. Visit Amber Fort and City Palace. Explore royal heritage, bustling markets, elephant rides to forts, and experience traditional Rajasthani cuisine and folk performances.", "https://images.unsplash.com/photo-1477587458883-47145ed94245?w=800&h=600&fit=crop", "India", "Jaipur, Rajasthan, India", 500m },
                    { 11, "Beautiful beaches, Portuguese architecture, and vibrant nightlife. Perfect for relaxation and adventure. Relax on golden sands, explore colonial churches, enjoy water sports, and experience Goan cuisine with Portuguese influences.", "https://images.unsplash.com/photo-1512343879784-a960bf40e7f2?w=800&h=600&fit=crop", "India", "Goa, India", 700m },
                    { 12, "Serene houseboat cruises through palm-fringed canals, lush greenery, and traditional village life. Experience traditional Kerala houseboats, spice plantations, wildlife sanctuaries, and authentic Ayurvedic treatments amidst tropical backwaters.", "https://images.unsplash.com/photo-1602216056096-3b40cc0c9944?w=800&h=600&fit=crop", "India", "Kerala Backwaters, India", 800m },
                    { 13, "The spiritual capital of India with ancient temples, ghats along the Ganges, and rich cultural heritage. Witness sacred Ganges rituals, explore ancient temples, take boat rides at dawn, and immerse in India's oldest living city's spiritual traditions.", "https://images.unsplash.com/photo-1699630923504-9a24dbaab37c?w=800&h=600&fit=crop", "India", "Varanasi, India", 450m },
                    { 14, "The city that never sleeps with Bollywood glamour, colonial architecture, and bustling street life. Visit the Gateway of India, explore Bollywood studios, enjoy street food, and experience the vibrant mix of cultures in India's financial capital.", "https://images.unsplash.com/photo-1562979314-bee7453e911c?w=800&h=600&fit=crop", "India", "Mumbai, India", 650m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FullName", "IsAdmin", "Password", "Username" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@tourismapp.com", "Administrator", true, "admin123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DestinationId",
                table: "Bookings",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DestinationId1",
                table: "Bookings",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
