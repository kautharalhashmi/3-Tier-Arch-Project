# 🧱 Building a 3-Tier Architecture in ASP.NET Core (Product & Category Example)

This guide explains how to create a **3-tier architecture** in an ASP.NET Core Web API project for managing **Products** and **Categories**. It uses clean separation of concerns across three layers: the **Presentation Layer**, the **Business Logic Layer**, and the **Data Access Layer**.


## ✅ What is 3-Tier Architecture?
![3tiers](https://github.com/user-attachments/assets/0af0cc50-7e1c-4b55-a808-41eedb8a1905)


## 🏗️ Step-by-Step Overview

### 1. Create the Project Structure

Start by creating a **solution** and three separate **projects**:
- A Web API project for the presentation layer.
- A class library for the business logic layer.
- A class library for the data access layer.

Add all three to your solution.

---

### 2. Add Project References

The **Presentation layer** should reference the **Business layer**, and the **Business layer** should reference the **Data layer**. This allows the top layer to access services, and services to access repositories and models.

---

### 3. Install Required Packages

Install the necessary Entity Framework Core packages in the **Data Access Layer** project. These are required to manage database context, migrations, and SQL Server connectivity.

![pack](https://github.com/user-attachments/assets/9eececbd-8063-4faa-978a-60319fc2b937)

---

### 4. Create Model Classes

Add simple classes for `Product` and `Category`. These represent your domain entities. A product belongs to a category, and a category can have many products — this forms a one-to-many relationship.

![c](https://github.com/user-attachments/assets/d080348f-c47a-4700-9428-483c7042f568)


---

### 5. Create ApplicationDbContext

Add a new class called `ApplicationDbContext` in the DAL. This class manages your database using Entity Framework Core. It will include `DbSet` properties for Products and Categories and configure their relationships using Fluent API.

---

### 6. Configure Fluent API in a Separate File

To keep your code clean, move relationship configurations (like foreign key rules) into separate files using EF Core’s `IEntityTypeConfiguration<T>`. For example, define in one file that a product must belong to a category and set up the foreign key.

---

### 7. Configure Dependency Injection (DI)

In the API project, register your DbContext, repositories, and services with the Dependency Injection container in `Program.cs`. This tells ASP.NET Core how to resolve dependencies automatically.

---

### 8. Set Up the Connection String

Define your SQL Server connection string in the `appsettings.json` file. This will tell your application where the database lives.

---

### 9. Run Migration and Update Database

Use the Entity Framework CLI to create a database migration. This generates SQL scripts based on your model and DbContext configuration. Then apply the migration to your database to create tables.

![Screenshot 2025-06-17 220658](https://github.com/user-attachments/assets/cbf46e1c-857e-40e2-b37e-247f78621053)

---



## 🔜 Next Steps

Once the architecture is in place:
- Create generic repositories for CRUD operations.
- Implement services that use repositories.

---

## 📌 Final Thoughts

Using a 3-tier architecture ensures your application is:
- **Modular** – You can develop and test each layer independently.
- **Maintainable** – Changes in one layer don’t break the others.
- **Scalable** – Easy to add more features and services later.

