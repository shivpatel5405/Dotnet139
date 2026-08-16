-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 24, 2025 at 06:16 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tourismapp`
--

-- --------------------------------------------------------

--
-- Table structure for table `bookings`
--

CREATE TABLE `bookings` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `DestinationId` int(11) NOT NULL,
  `BookingDate` datetime NOT NULL DEFAULT current_timestamp(),
  `NumberOfPeople` int(11) NOT NULL,
  `ChargePerPerson` decimal(18,2) NOT NULL,
  `TotalCost` decimal(18,2) GENERATED ALWAYS AS (`NumberOfPeople` * `ChargePerPerson`) STORED,
  `Name` varchar(100) NOT NULL,
  `Phone` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--


-- --------------------------------------------------------

--
-- Table structure for table `destinations`
--

CREATE TABLE `destinations` (
  `Id` int(11) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Description` longtext NOT NULL,
  `ImageUrl` varchar(500) NOT NULL,
  `Location` varchar(100) NOT NULL,
  `Price` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `destinations`
--

INSERT INTO `destinations` (`Id`, `Name`, `Description`, `ImageUrl`, `Location`, `Price`) VALUES
(1, 'Paris, France', 'The City of Light, known for Eiffel Tower, Louvre Museum, and romantic ambiance. Explore the Seine River cruises, Montmartre\'s artistic charm, Notre-Dame Cathedral, and world-class cuisine including croissants and fine wines.', 'https://images.unsplash.com/photo-1431274172761-fca41d930114?w=800&h=600&fit=crop', 'France', 1200.00),
(2, 'Tokyo, Japan', 'A bustling metropolis blending traditional culture with cutting-edge technology. Visit Shibuya Crossing, ancient temples like Senso-ji, neon-lit districts, sushi restaurants, and experience bullet trains and futuristic skyscrapers.', 'https://images.unsplash.com/photo-1540959733332-eab4deabeeaf?w=800&h=600&fit=crop', 'Japan', 1500.00),
(3, 'Bali, Indonesia', 'Tropical paradise with beautiful beaches, temples, and vibrant culture. Relax on pristine beaches, hike volcanoes like Mount Batur, explore rice terraces in Ubud, and enjoy traditional Balinese dances and ceremonies.', 'https://images.unsplash.com/photo-1537953773345-d172ccf13cf1?w=800&h=600&fit=crop', 'Indonesia', 800.00),
(4, 'Rome, Italy', 'Ancient history meets modern charm in the Eternal City with Colosseum and Vatican. Wander through ancient Roman ruins, visit St. Peter\'s Basilica, toss coins in the Trevi Fountain, and savor authentic Italian pizza and gelato.', 'https://images.unsplash.com/photo-1555992336-fb0d29498b13?w=800&h=600&fit=crop', 'Italy', 1100.00),
(5, 'Dubai, UAE', 'Luxury and innovation in the desert with Burj Khalifa and stunning architecture. Experience desert safaris, luxury shopping at Dubai Mall, indoor skiing at Ski Dubai, and breathtaking views from the world\'s tallest building.', 'https://images.unsplash.com/photo-1512453979798-5ea266f8880c?w=800&h=600&fit=crop', 'UAE', 1800.00),
(6, 'Sydney, Australia', 'Iconic Opera House and Harbour Bridge in a vibrant coastal city. Enjoy harbor cruises, relax at Bondi Beach, visit the Sydney Aquarium, and explore the Royal Botanic Gardens with stunning ocean views.', 'https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9?w=800&h=600&fit=crop', 'Australia', 2000.00),
(7, 'Santorini, Greece', 'Stunning sunsets and white-washed buildings overlooking the Aegean Sea. Discover blue-domed churches, volcanic beaches, ancient Minoan ruins, and enjoy local wines while watching spectacular Mediterranean sunsets.', 'https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff?w=800&h=600&fit=crop', 'Greece', 1300.00),
(8, 'Maldives', 'Overwater bungalows and crystal-clear waters in paradise islands. Dive into coral reefs, enjoy private beach dinners, relax in luxury spas, and experience world-class snorkeling in the Indian Ocean\'s clearest waters.', 'https://images.unsplash.com/photo-1573843981267-be1999ff37cd?w=800&h=600&fit=crop', 'Maldives', 2500.00),
(9, 'Taj Mahal, Agra, India', 'The iconic symbol of love, a magnificent white marble mausoleum built by Mughal Emperor Shah Jahan. Marvel at intricate Mughal architecture, reflective pools, and beautiful gardens.', 'https://images.unsplash.com/photo-1587135941948-670b381f08ce?w=800&h=600&fit=crop', 'India', 600.00),
(10, 'Jaipur, Rajasthan, India', 'The Pink City with stunning palaces, forts, and vibrant culture. Visit Amber Fort and City Palace. Explore royal heritage, bustling markets, elephant rides to forts, and experience traditional Rajasthani cuisine and folk performances.', 'https://images.unsplash.com/photo-1477587458883-47145ed94245?w=800&h=600&fit=crop', 'India', 500.00),
(11, 'Goa, India', 'Beautiful beaches, Portuguese architecture, and vibrant nightlife. Perfect for relaxation and adventure. Relax on golden sands, explore colonial churches, enjoy water sports, and experience Goan cuisine with Portuguese influences.', 'https://images.unsplash.com/photo-1512343879784-a960bf40e7f2?w=800&h=600&fit=crop', 'India', 700.00),
(12, 'Kerala Backwaters, India', 'Serene houseboat cruises through palm-fringed canals, lush greenery, and traditional village life. Experience traditional Kerala houseboats, spice plantations, wildlife sanctuaries, and authentic Ayurvedic treatments amidst tropical backwaters.', 'https://images.unsplash.com/photo-1602216056096-3b40cc0c9944?w=800&h=600&fit=crop', 'India', 800.00),
(13, 'Varanasi, India', 'The spiritual capital of India with ancient temples, ghats along the Ganges, and rich cultural heritage. Witness sacred Ganges rituals, explore ancient temples, take boat rides at dawn, and immerse in India\'s oldest living city\'s spiritual traditions.', 'https://images.unsplash.com/photo-1699630923504-9a24dbaab37c?w=800&h=600&fit=crop', 'India', 450.00),
(14, 'Mumbai, India', 'The city that never sleeps with Bollywood glamour, colonial architecture, and bustling street life. Visit the Gateway of India, explore Bollywood studios, enjoy street food, and experience the vibrant mix of cultures in India\'s financial capital.', 'https://images.unsplash.com/photo-1562979314-bee7453e911c?w=800&h=600&fit=crop', 'India', 650.00);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `IsAdmin` tinyint(1) NOT NULL DEFAULT 0,
  `CreatedDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Username`, `Email`, `Password`, `FullName`, `IsAdmin`, `CreatedDate`) VALUES
(1, 'admin', 'admin@tourism.com', 'admin123', 'Admin User', 1, '2025-10-24 20:46:18'),

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Bookings_UserId` (`UserId`),
  ADD KEY `IX_Bookings_DestinationId` (`DestinationId`);

--
-- Indexes for table `destinations`
--
ALTER TABLE `destinations`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `destinations`
--
ALTER TABLE `destinations`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`),
  ADD CONSTRAINT `bookings_ibfk_2` FOREIGN KEY (`DestinationId`) REFERENCES `destinations` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
