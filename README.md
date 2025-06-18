# Identity Integration

## Step-by-Step Implementation Guide

### 1. Define the ApplicationUser Entity

Extend the default IdentityUser to add custom properties:

```csharp
using Microsoft.AspNetCore.Identity;
using System;

namespace Shop.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
```
### 2. Setup the Application DbContext
Inherit from IdentityDbContext<ApplicationUser> to enable Identity tables:
```csharp 
public class AppilcationDbContext : IdentityDbContext<ApplicationUser>
```
### 3. Configure Identity Services in Program.cs 
Register Identity and configure database connection:
```csharp

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppilcationDbContext>()
    .AddDefaultTokenProviders();
```
