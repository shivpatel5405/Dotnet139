using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tourism_App.Models;

namespace Tourism_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --------------------------
            // User entity
            // --------------------------
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.FullName).HasMaxLength(100);

                // ✅ Changed from GETDATE() (SQL Server) to MySQL CURRENT_TIMESTAMP
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // --------------------------
            // Destination entity
            // --------------------------
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Location).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            // --------------------------
            // Booking entity
            // --------------------------
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);

                // ✅ Changed from GETDATE() (SQL Server) to MySQL CURRENT_TIMESTAMP
                entity.Property(e => e.BookingDate)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ChargePerPerson)
                      .HasColumnType("decimal(18,2)");

                // ✅ Fixed computed column syntax for MySQL (removed SQL Server [] brackets)
                entity.Property(e => e.TotalCost)
                      .HasColumnType("decimal(18,2)")
                      .HasComputedColumnSql("NumberOfPeople * ChargePerPerson", stored: true);

                // --------------------------
                // ✅ Removed old DestinationId1 / UserId1 references
                // --------------------------
                entity.HasOne(b => b.User)
                      .WithMany()
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Destination)
                      .WithMany()
                      .HasForeignKey(b => b.DestinationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --------------------------
            // Seed admin user
            // --------------------------
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@tourismapp.com",
                    Password = "admin123",
                    FullName = "Administrator",
                    IsAdmin = true,
                    CreatedDate = new DateTime(2024, 1, 1)
                }
            );

            // --------------------------
            // Seed destinations
            // --------------------------
            modelBuilder.Entity<Destination>().HasData(
                new Destination
                {
                    Id = 1,
                    Name = "Paris, France",
                    Description = "The City of Light, known for Eiffel Tower, Louvre Museum, and romantic ambiance. Explore the Seine River cruises, Montmartre's artistic charm, Notre-Dame Cathedral, and world-class cuisine including croissants and fine wines.",
                    Location = "France",
                    Price = 1200,
                    ImageUrl = "https://images.unsplash.com/photo-1431274172761-fca41d930114?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 2,
                    Name = "Tokyo, Japan",
                    Description = "A bustling metropolis blending traditional culture with cutting-edge technology. Visit Shibuya Crossing, ancient temples like Senso-ji, neon-lit districts, sushi restaurants, and experience bullet trains and futuristic skyscrapers.",
                    Location = "Japan",
                    Price = 1500,
                    ImageUrl = "https://images.unsplash.com/photo-1540959733332-eab4deabeeaf?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 3,
                    Name = "Bali, Indonesia",
                    Description = "Tropical paradise with beautiful beaches, temples, and vibrant culture. Relax on pristine beaches, hike volcanoes like Mount Batur, explore rice terraces in Ubud, and enjoy traditional Balinese dances and ceremonies.",
                    Location = "Indonesia",
                    Price = 800,
                    ImageUrl = "https://images.unsplash.com/photo-1537953773345-d172ccf13cf1?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 4,
                    Name = "Rome, Italy",
                    Description = "Ancient history meets modern charm in the Eternal City with Colosseum and Vatican. Wander through ancient Roman ruins, visit St. Peter's Basilica, toss coins in the Trevi Fountain, and savor authentic Italian pizza and gelato.",
                    Location = "Italy",
                    Price = 1100,
                    ImageUrl = "https://images.unsplash.com/photo-1555992336-fb0d29498b13?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 5,
                    Name = "Dubai, UAE",
                    Description = "Luxury and innovation in the desert with Burj Khalifa and stunning architecture. Experience desert safaris, luxury shopping at Dubai Mall, indoor skiing at Ski Dubai, and breathtaking views from the world's tallest building.",
                    Location = "UAE",
                    Price = 1800,
                    ImageUrl = "https://images.unsplash.com/photo-1512453979798-5ea266f8880c?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 6,
                    Name = "Sydney, Australia",
                    Description = "Iconic Opera House and Harbour Bridge in a vibrant coastal city. Enjoy harbor cruises, relax at Bondi Beach, visit the Sydney Aquarium, and explore the Royal Botanic Gardens with stunning ocean views.",
                    Location = "Australia",
                    Price = 2000,
                    ImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 7,
                    Name = "Santorini, Greece",
                    Description = "Stunning sunsets and white-washed buildings overlooking the Aegean Sea. Discover blue-domed churches, volcanic beaches, ancient Minoan ruins, and enjoy local wines while watching spectacular Mediterranean sunsets.",
                    Location = "Greece",
                    Price = 1300,
                    ImageUrl = "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 8,
                    Name = "Maldives",
                    Description = "Overwater bungalows and crystal-clear waters in paradise islands. Dive into coral reefs, enjoy private beach dinners, relax in luxury spas, and experience world-class snorkeling in the Indian Ocean's clearest waters.",
                    Location = "Maldives",
                    Price = 2500,
                    ImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 9,
                    Name = "Taj Mahal, Agra, India",
                    Description = "The iconic symbol of love, a magnificent white marble mausoleum built by Mughal Emperor Shah Jahan. Marvel at intricate Mughal architecture, reflective pools, and beautiful gardens, while learning about the legendary love story of Shah Jahan and Mumtaz Mahal.",
                    Location = "India",
                    Price = 600,
                    ImageUrl = "https://images.unsplash.com/photo-1587135941948-670b381f08ce?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 10,
                    Name = "Jaipur, Rajasthan, India",
                    Description = "The Pink City with stunning palaces, forts, and vibrant culture. Visit Amber Fort and City Palace. Explore royal heritage, bustling markets, elephant rides to forts, and experience traditional Rajasthani cuisine and folk performances.",
                    Location = "India",
                    Price = 500,
                    ImageUrl = "https://images.unsplash.com/photo-1477587458883-47145ed94245?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 11,
                    Name = "Goa, India",
                    Description = "Beautiful beaches, Portuguese architecture, and vibrant nightlife. Perfect for relaxation and adventure. Relax on golden sands, explore colonial churches, enjoy water sports, and experience Goan cuisine with Portuguese influences.",
                    Location = "India",
                    Price = 700,
                    ImageUrl = "https://images.unsplash.com/photo-1512343879784-a960bf40e7f2?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 12,
                    Name = "Kerala Backwaters, India",
                    Description = "Serene houseboat cruises through palm-fringed canals, lush greenery, and traditional village life. Experience traditional Kerala houseboats, spice plantations, wildlife sanctuaries, and authentic Ayurvedic treatments amidst tropical backwaters.",
                    Location = "India",
                    Price = 800,
                    ImageUrl = "https://images.unsplash.com/photo-1602216056096-3b40cc0c9944?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 13,
                    Name = "Varanasi, India",
                    Description = "The spiritual capital of India with ancient temples, ghats along the Ganges, and rich cultural heritage. Witness sacred Ganges rituals, explore ancient temples, take boat rides at dawn, and immerse in India's oldest living city's spiritual traditions.",
                    Location = "India",
                    Price = 450,
                    ImageUrl = "https://images.unsplash.com/photo-1561361513-2d000a50f0dc?w=800&h=600&fit=crop"
                },
                new Destination
                {
                    Id = 14,
                    Name = "Mumbai, India",
                    Description = "The city that never sleeps with Bollywood glamour, colonial architecture, and bustling street life. Visit the Gateway of India, explore Bollywood studios, enjoy street food, and experience the vibrant mix of cultures in India's financial capital.",
                    Location = "India",
                    Price = 650,
                    ImageUrl = "https://images.unsplash.com/photo-1625731226721-b4d51ae70e20?w=800&h=600&fit=crop"
                }
            );
        }
    }
}
