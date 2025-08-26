# ASP.NET MVC Machine Test

This project implements the given machine test requirements using **ASP.NET MVC 5** and **Entity Framework 6 (Code First approach)**.  
> Note: No scaffolding has been used — all controllers and views are written manually.

---

## ✅ Requirements Implemented
1. **Category Master** with full CRUD operations.  
2. **Product Master** with full CRUD operations (each product belongs to a category).  
3. **Product List** view displays the following columns:  
   - ProductId  
   - ProductName  
   - CategoryId  
   - CategoryName  
4. **Server-side Pagination** on the product list:  
   - Records are fetched from DB only for the current page.  
   - Example: If page size = 10 and user is on page 9 → only records 90–100 are retrieved.  

---

## 🏗️ Tech Stack
- ASP.NET MVC 5  
- Entity Framework 6 (Code First)  
- SQL Server (LocalDB / Express)  
- Bootstrap (for basic styling)  

---

## 📂 Project Structure
```
ASP-NET-Web-app/
│
├── Controllers/
│ ├── CategoryController.cs
│ ├── ProductController.cs
│
├── Data/
│ ├── AppDbContext.cs
│ ├── SeedData.cs
│
├── Models/
│ ├── Category.cs
│ ├── Product.cs
│
├── Repositories/
│ ├── IRepositories/
│ ├── IRepository.cs
│ ├── EFRepository.cs
│
├── Views/
│ ├── Category/ (CRUD Razor views)
│ ├── Product/ (CRUD + Pagination Razor views)
│ ├── Shared/ (Layout.cshtml, error handling, etc.)
│
├── Web.config
├── README.md
```
---

## 🛠️Features
1. **Category Master**
   - Add, Edit, Delete, and View categories.  
   - Categories are stored in the database and used while creating products.
2. **Product Master**
   - Add, Edit, Delete, and View products.  
   - Each product belongs to a category (foreign key relationship).  
   - Product creation form includes category selection (dropdown).
3. **Product List**
   - Displays the following columns:
     - ProductId
     - ProductName
     - CategoryId
     - CategoryName
4. **Server-Side Pagination**
   - Pagination implemented on the product list view.  
   - Records are fetched from the database based on the current page and page size.  
   - Example: If page size = 10 and user is on page 9, only records **90–100** are pulled from the database.

---

## How to Run
1. Clone this repository:
   ```bash
   git clone https://github.com/Pratik5767/ASP-NET-Web-App.git
   ```
2. Open the solution in Visual Studio.
3. Update the connection string in Web.config with your SQL Server details.
4. Run the following (for EF Code First):
   ```
   Update-Database
   ```
   This will create tables for Categories and Products.
5. Press F5 to build and run the project.

---

## Expected Output
- Category Master: Manage categories.
- Product Master: Manage products linked with categories.
- Product List: Displays product details with category names and pagination.

---

## Notes
- No scaffolding was used; all CRUD operations are implemented manually.
- Pagination is fully server-side to ensure performance.
