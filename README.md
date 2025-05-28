# Binary Beans - Café Management System (.NET WinForms)
A desktop-based café management application built using Windows Forms (.NET Framework 4.7.2) for managing orders, users, inventory, and staff roles.

## 🔧 Tech Stack
- **Frontend:** WinForms (.NET Framework 4.7.2)
- **Backend:** C# (Typed Datasets, ADO.NET)
- **Database:** SQL Server (`.sql` script included)
- **Architecture:** Multi-role system with custom authentication

## 👥 User Roles
### ☕ Customer
- Register / Login
- Edit profile
- Browse products & categories (even as guest)
- Add food items to cart
- Checkout & place order
- View receipt on screen after order
- Give feedback
- View order history

### 🧾 Staff
#### Cafe Manager
- Manage products
- Edit product categories
- View all orders

#### Inventory Manager
- Update stock count
- Add/edit products and categories

#### Cashier
- Process orders
- View order list

## 📂 Project Structure
- `*.cs`, `*.Designer.cs` – UI and logic for forms
- `*.resx` – Resources for localization/UI
- `*.xsd`, `*.xsc`, `*.xss` – Typed datasets for data access
- `V6.sql` – SQL schema and seed data

## 🚀 Getting Started
1. Clone the repo
2. Open `.sln` in Visual Studio
3. Restore NuGet packages if any
4. Set up SQL Server and import `V6.sql`
5. Update connection string in `App.config`
6. Build and run

## 📋 Prerequisites
- Windows OS
- .NET Framework 4.7.2+
- SQL Server (Express or full)
- Visual Studio 2019+
