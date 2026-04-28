# 🏢 Simple Employee Admin Portal

A RESTful API built with ASP.NET Core for managing employees — supports full CRUD operations with clean architecture using Repository Pattern and Unit of Work.

---

## 🛠️ Technologies Used

- **ASP.NET Core Web API** — .NET 8
- **Entity Framework Core** — ORM for database access
- **SQL Server** — Database

---

## 🏗️ Architecture & Patterns

### Repository Pattern
> "One gate to the database"

A entity has its own repository that is the **only class allowed to talk to the database** — services never access `DbContext` directly.

### Unit of Work
> "All or nothing when saving"

A repository share a single `DbContext` and save  — if one operation fails, nothing is committed.

### Dependency Injection
> "Don't create it, just ask for it"

All services and repositories are registered in `Program.cs` and injected via constructors.


## 📡 API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/Employee` | Get all employees |
| `GET` | `/api/Employee/{id}` | Get employee by Id |
| `POST` | `/api/Employee` | Add new employee |
| `PUT` | `/api/Employee/{id}` | Update employee |
| `DELETE` | `/api/Employee/{id}` | Delete employee |

---

## 📋 Employee Model

```json
{
  "id": "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
  "name": "John Doe",
  "email": "john@example.com",
  "phone": "01234567890",
  "salary": 5000
}
```

---

## 🔁 Request & Response Examples

### Add Employee — POST `/api/Employee`
**Request Body:**
```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "phone": "01234567890",
  "salary": 5000
}
```
**Response:** `201 Created`
```json
{
  "id": "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
  "name": "John Doe",
  "email": "john@example.com",
  "phone": "01234567890",
  "salary": 5000
}
```

### Update Employee — PUT `/api/Employee/{id}`
**Response:** `200 OK` — returns updated employee

### Delete Employee — DELETE `/api/Employee/{id}`
**Response:** `204 No Content`

### Not Found
**Response:** `404 Not Found`
```json
"Employee with id '...' not found."
```

---

## 💡 Key Concepts Used

| Concept | Purpose |
|---|---|
| `async / await` | Non-blocking DB calls — app stays free while waiting |
| `Task<T>` | Promise to return data later |
| `Guid` | Unique Id for each employee |
| `string?` | Nullable — field is optional |
| `required` | Compiler forces property to be set |
| `IEnumerable<T>` | Return a list of employees |

---

## 📦 NuGet Packages

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
```

---
