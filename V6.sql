drop database if exists cafeV5
create database cafeV6

-- Create Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) UNIQUE
);

-- Create Customers Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
	Passcode INT CHECK (Passcode BETWEEN 1000 AND 9999)
);

-- Create Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name VARCHAR(100),
    CategoryID INT,
    Price DECIMAL(10, 2),
	StockCount INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Create Orders Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATETIME,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
--Alter the Orders Table to Add an Auto-incrementing OrderID Column



-- Create OrderItems Table
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Subtotal DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Insert Sample Categories
INSERT INTO Categories (CategoryID, CategoryName)
VALUES
    (1, 'Main Course'),
    (2, 'Beverage'),
    (3, 'Breakfast'),
	(4, 'Dessert'),
    (5, 'Snack'),
	(6, 'Appetizer'),
    (7, 'Vegetarian');

-- Insert Sample Customers
INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Passcode)
VALUES
    (1, 'Ali', 'Khan', 'ali.khan@example.com', '+923001234567', '1234'),
    (2, 'Sara', 'Ahmed', 'sara.ahmed@example.com', '+923451234567', '1234'),
	(3, 'Ahmed', 'Malik', 'ahmed.malik@example.com', '+923341234567', '1234'),
    (4, 'Fatima', 'Khan', 'fatima.khan@example.com', '+923112345678', '1234'),
    (5, 'Omar', 'Ali', 'omar.ali@example.com', '+923221234567','1234');


-- Insert Sample Products with Specific StockCounts
INSERT INTO Products (ProductID, Name, CategoryID, Price, StockCount)
VALUES
    (1, 'Biryani', 1, 300.00, 50),
    (2, 'Nihari', 1, 250.00, 30),
    (3, 'Karhai', 1, 280.00, 40),
    (4, 'Chai', 2, 80.00, 100),
    (5, 'Qeema Paratha', 3, 150.00, 20),
    (6, 'Gulab Jamun', 4, 120.00, 60),
    (7, 'Samosa', 5, 50.00, 80),
    (8, 'Kheer', 4, 180.00, 25),
    (9, 'Pakoras', 5, 70.00, 45),
    (10, 'Fruit Chaat', 3, 100.00, 35),
    (11, 'Hummus with Pita Bread', 6, 90.00, 55),
    (12, 'Mango Lassi', 2, 120.00, 75),
    (13, 'Vegetable Biryani', 7, 250.00, 15),
    (14, 'Chicken Tikka', 6, 180.00, 90),
    (15, 'Cold Coffee', 2, 80.00, 70);


-- Insert Sample Orders
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES
    (1, 1, '2023-12-01 12:30:00', 580.00),
    (2, 2, '2023-12-02 18:45:00', 350.00),
	(3, 1, '2023-12-03 15:20:00', 320.00),
    (4, 2, '2023-12-04 20:00:00', 450.00);

-- Insert Sample OrderItems
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Subtotal)
VALUES
    (1, 1, 1, 2, 600.00),
    (2, 1, 4, 1, 80.00),
    (3, 2, 2, 1, 250.00),
    (4, 2, 5, 2, 300.00),
	(5, 3, 6, 3, 360.00),
    (6, 3, 8, 1, 180.00),
    (7, 4, 7, 2, 100.00),
    (8, 4, 10, 1, 100.00);


-- Create Staff Table
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
	Passcode INT CHECK (Passcode BETWEEN 1000 AND 9999)
);

select * from Staff
-- Insert Sample Staff
INSERT INTO Staff (StaffID, FirstName, LastName, Email, Phone, Passcode)
VALUES
    (1, 'Ahmad ', 'Raza', 'Ahmad.Raza@example.com', '+923001234567', '4321'),
    (2, 'Umer ', 'Farooq', 'Umer.Farooq@example.com', '+923451234567', '4321'),
    (3, 'Muhammad', 'Akram', 'Muhammad.Akram@example.com', '+923341234567', '4321'),
    (4, 'Sara', 'Malik', 'Sara.Malik@example.com', '+923551234567', '1234'),
    (5, 'Fahad', 'Khan', 'Fahad.Khan@example.com', '+923112345678', '5678'),
    (6, 'Aisha', 'Ahmed', 'Aisha.Ahmed@example.com', '+923221234567', '9876'),
    (7, 'Nida', 'Ali', 'Nida.Ali@example.com', '+923331234567', '5432'),
    (8, 'Saad', 'Hussain', 'Saad.Hussain@example.com', '+923441234567', '7890'),
    (9, 'Maryam', 'Asif', 'Maryam.Asif@example.com', '+923551234567', '1357');


-- Create CafeManager Table
CREATE TABLE CafeManager (
    ManagerID INT PRIMARY KEY,
    StaffID INT,
    Responsibilities VARCHAR(255), -- Specific responsibilities of the cafe manager
    ExperienceYears INT, -- Number of years of experience
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

-- Create InventoryManager Table
CREATE TABLE InventoryManager (
    InventoryManagerID INT PRIMARY KEY,
    StaffID INT,
    Department VARCHAR(50), -- Inventory department details
    InventoryTrackingSystem VARCHAR(100), -- Name of the tracking system used
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

-- Create Cashier Table
CREATE TABLE Cashier (
    CashierID INT PRIMARY KEY,
    StaffID INT,
    CashRegisterID INT, -- Identifier for the cash register assigned
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);


-- Insert Sample CafeManager
INSERT INTO CafeManager (ManagerID, StaffID, Responsibilities, ExperienceYears)
VALUES
    (1, 1, 'Menu Planning, Staff Management', 5),
    (2, 2, 'Financial Management, Customer Satisfaction', 7),
    (3, 3, 'Inventory Management, Vendor Relationships', 6);

-- Insert Sample InventoryManager
INSERT INTO InventoryManager (InventoryManagerID, StaffID, Department, InventoryTrackingSystem)
VALUES
    (1, 4, 'Kitchen Supplies', 'InventoryPro'),
    (2, 5, 'Beverages', 'StockMaster'),
    (3, 6, 'Dessert Ingredients', 'InventoryPlus');

-- Insert Sample Cashier
INSERT INTO Cashier (CashierID, StaffID, CashRegisterID)
VALUES
    (1, 7, 101),
    (2, 8, 102),
    (3, 9, 103);

-- Create Schedule Table
CREATE TABLE Schedule (
    ScheduleID INT PRIMARY KEY,
    StaffID INT,
    ShiftStart DATETIME,
    ShiftEnd DATETIME,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

-- Insert Sample Schedules
INSERT INTO Schedule (ScheduleID, StaffID, ShiftStart, ShiftEnd)
VALUES
    (1, 1, '2023-12-01 09:00:00', '2023-12-01 17:00:00'),
    (2, 2, '2023-12-01 09:00:00', '2023-12-01 17:00:00'),
    (3, 3, '2023-12-01 13:00:00', '2023-12-01 21:00:00');





-- Create LoyaltyProgram Table
CREATE TABLE LoyaltyProgram (
    LoyaltyProgramID int,
	CustomerID INT,
    Points INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


-- Create Rewards Table
CREATE TABLE Rewards (
    RewardID INT PRIMARY KEY,
    PointsRequired INT,
    Description VARCHAR(255)
);

-- Create CustomerRewards Table
CREATE TABLE CustomerRewards (
    CustomerID INT,
    RewardID INT,
    RedeemDate DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (RewardID) REFERENCES Rewards(RewardID)
);


-- Insert Sample LoyaltyProgram
INSERT INTO LoyaltyProgram (LoyaltyProgramID, CustomerID, Points)
VALUES
    (1, 1, 100),
    (2,2, 200),
    (3,3, 150),
    (4,4, 250),
    (5,5, 300);

-- Insert Sample Rewards
INSERT INTO Rewards (RewardID, PointsRequired, Description)
VALUES
    (1, 100, 'Free Coffee'),
    (2, 200, 'Free Dessert'),
    (3, 300, 'Free Main Course');

-- Insert Sample CustomerRewards
INSERT INTO CustomerRewards (CustomerID, RewardID, RedeemDate)
VALUES
    (1, 1, '2023-12-01 12:30:00'),
    (2, 2, '2023-12-02 18:45:00'),
    (3, 1, '2023-12-03 15:20:00'),
    (4, 3, '2023-12-04 20:00:00');


-- Create Feedback Table
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY,
    CustomerID INT,
    OrderID INT,
    Rating INT,
    Comment TEXT,
    FeedbackDate DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);
-- Insert Sample Feedback
INSERT INTO Feedback (FeedbackID, CustomerID, OrderID, Rating, Comment, FeedbackDate)
VALUES
    (1, 1, 1, 4, 'Great service and delicious food!', '2023-12-05 14:30:00'),
    (2, 2, 2,  5, 'Quick and friendly service. Loved the atmosphere.', '2023-12-06 12:15:00'),
    (3, 3, 3, 3, 'Food was good, but it took a bit longer than expected.', '2023-12-07 19:45:00');



	-- List of All Products
SELECT * FROM Products;

-- List of All Categories
SELECT * FROM Categories;

-- Products of a Specific Category 
SELECT * FROM Products WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = 'Main Course');

-- Change Customer Profile Information
UPDATE Customers
SET FirstName = 'NewFirstName', LastName = 'NewLastName', Email = 'new.email@example.com', Phone = '+1234567890'
WHERE CustomerID = 1; -- Replace with the desired CustomerID

-- Change Passcode for a Customer
UPDATE Customers
SET Passcode = 4321 -- Replace with the desired 4-digit passcode
WHERE CustomerID = 1; -- Replace with the desired CustomerID

-- List All Orders
SELECT * FROM Orders;

-- List Order Items for a Specific Order
SELECT * FROM OrderItems WHERE OrderID = 1;

-- Total Sales for a Specific Date Range 
SELECT SUM(TotalAmount) AS TotalSales
FROM Orders
WHERE OrderDate BETWEEN '2023-12-01' AND '2023-12-05';

-- Customer Loyalty Points
SELECT CustomerID, Points FROM LoyaltyProgram;

-- List Rewards and Points Required
SELECT * FROM Rewards;

-- Customer Redeemed Rewards
SELECT cr.CustomerID, r.Description, cr.RedeemDate
FROM CustomerRewards cr
JOIN Rewards r ON cr.RewardID = r.RewardID;

-- Top 5 Selling Products
SELECT top 5 p.ProductID, p.Name, COUNT(oi.OrderItemID) AS SalesCount
FROM Products p
JOIN OrderItems oi ON p.ProductID = oi.ProductID
GROUP BY p.ProductID, p.Name
ORDER BY SalesCount DESC;

-- Staff Schedule for a Specific Date (e.g., 2023-12-01)
SELECT s.StaffID, s.FirstName, s.LastName, sc.ShiftStart, sc.ShiftEnd
FROM Schedule sc
JOIN Staff s ON sc.StaffID = s.StaffID
WHERE sc.ShiftStart <= '2023-12-01' AND sc.ShiftEnd >= '2023-12-01';

-- Average Rating and Comments for Orders with Feedback
SELECT o.OrderID, AVG(f.Rating) AS AverageRating, COUNT(f.FeedbackID) AS FeedbackCount
FROM Orders o
LEFT JOIN Feedback f ON o.OrderID = f.OrderID
GROUP BY o.OrderID;

-- Check Stock Count for a Specific Product (e.g., ProductID = 1)
SELECT ProductID, StockCount FROM Products WHERE ProductID = 1;


-- List All Customers and Their Orders
SELECT c.CustomerID, c.FirstName, c.LastName, o.OrderID, o.OrderDate, oi.ProductID, p.Name AS ProductName, oi.Quantity, oi.Subtotal
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN OrderItems oi ON o.OrderID = oi.OrderID
JOIN Products p ON oi.ProductID = p.ProductID;

-- List Top 5 Customers with Highest Total Spending
SELECT c.CustomerID, c.FirstName, c.LastName, SUM(o.TotalAmount) AS TotalSpending
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
ORDER BY TotalSpending DESC;

-- List Staff and Their Roles
SELECT s.StaffID, s.FirstName, s.LastName,
       CASE
           WHEN cm.ManagerID IS NOT NULL THEN 'Cafe Manager'
           WHEN im.InventoryManagerID IS NOT NULL THEN 'Inventory Manager'
           WHEN c.CashierID IS NOT NULL THEN 'Cashier'
           ELSE 'No Role'
       END AS Role
FROM Staff s
LEFT JOIN CafeManager cm ON s.StaffID = cm.StaffID
LEFT JOIN InventoryManager im ON s.StaffID = im.StaffID
LEFT JOIN Cashier c ON s.StaffID = c.StaffID;

-- List Orders and Feedback (if available)
SELECT o.OrderID, o.OrderDate, c.FirstName, c.LastName, f.Rating, f.Comment
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
LEFT JOIN Feedback f ON o.OrderID = f.OrderID;

-- List Staff with Their Shifts for a Specific Date
SELECT s.StaffID, s.FirstName, s.LastName, sc.ShiftStart, sc.ShiftEnd
FROM Staff s
JOIN Schedule sc ON s.StaffID = sc.StaffID
WHERE sc.ShiftStart <= '2023-12-01' AND sc.ShiftEnd >= '2023-12-01';

-- List Available Rewards for Customers
SELECT r.RewardID, r.Description, r.PointsRequired
FROM Rewards r
WHERE r.PointsRequired <= (SELECT Points FROM LoyaltyProgram WHERE CustomerID = 1);

-- List Customers and Their Redeemed Rewards
SELECT cr.CustomerID, r.Description, cr.RedeemDate
FROM CustomerRewards cr
JOIN Rewards r ON cr.RewardID = r.RewardID;

-- List Customers and Their Feedback
SELECT c.FirstName, c.LastName, f.Rating, f.Comment, f.FeedbackDate
FROM Customers c
JOIN Feedback f ON c.CustomerID = f.CustomerID;


SELECT OrderItems.OrderItemID, OrderItems.Quantity, OrderItems.Subtotal, Products.Name AS ProductName, Orders.OrderDate
FROM OrderItems
JOIN Products ON OrderItems.ProductID = Products.ProductID
JOIN Orders ON OrderItems.OrderID = Orders.OrderID;

SELECT Orders.OrderID, Orders.OrderDate, Orders.TotalAmount, Customers.FirstName, Customers.LastName
FROM Orders
JOIN Customers ON Orders.CustomerID = Customers.CustomerID;
