# 🚀 Fundoo Notes Backend API

## 📌 Project Overview

Fundoo Notes is a note management application developed using ASP.NET Core Web API following a layered architecture approach. The project implements secure user authentication using JWT Tokens, password hashing with BCrypt, email notifications, and note management functionalities.

---

# 🏗️ Architecture

The application follows a 4-Layer Architecture:

```text
Presentation Layer (Controllers)
            │
            ▼
Business Logic Layer (BLL)
            │
            ▼
Data Access Layer (DAL)
            │
            ▼
Database Layer (SQL Server)
```

---

# 🔄 Request Flow Diagram

## User Registration Flow

```text
User
 │
 ▼
POST /Register
 │
 ▼
UserController
 │
 ▼
UserBLL
 │
 ├── Validate Request
 ├── Hash Password (BCrypt)
 ├── Send Welcome Email
 │
 ▼
UserDAL
 │
 ▼
Entity Framework Core
 │
 ▼
SQL Server Database
 │
 ▼
User Created Successfully
```

---

## Login & JWT Authentication Flow

```text
User
 │
 ▼
POST /Login
 │
 ▼
UserController
 │
 ▼
UserBLL
 │
 ├── Verify Email
 ├── Verify Password (BCrypt)
 ├── Generate Claims
 ├── Generate JWT Token
 │
 ▼
Return JWT Token
```

---

## Protected API Flow

```text
Client Request
 │
 │ Bearer Token
 ▼
JWT Middleware
 │
 ├── Validate Signature
 ├── Validate Issuer
 ├── Validate Audience
 ├── Validate Expiration
 │
 ▼
[Authorize]
 │
 ▼
Controller
 │
 ▼
Response Returned
```
<img width="770" height="473" alt="image" src="https://github.com/user-attachments/assets/f578823b-11e6-439a-8f02-5390a5ec6305" />


---

# 🗄️ Database Design (Current)

## Users Table

| Column    | Data Type | Description            |
| --------- | --------- | ---------------------- |
| UserId    | INT       | Primary Key            |
| FirstName | NVARCHAR  | User First Name        |
| LastName  | NVARCHAR  | User Last Name         |
| Email     | NVARCHAR  | Unique Email           |
| Password  | NVARCHAR  | BCrypt Hashed Password |
| CreatedAt | DATETIME  | Created Timestamp      |
| ChangedAt | DATETIME  | Updated Timestamp      |

---

# 📂 Current Project Structure

```text
FundooNotes
│
├── Controllers
│   ├── UserController.cs
│
├── BusinessLogicLayer
│   │
│   ├── Interface
│   │   ├── IUserBLL.cs
│   │   └── IEmailService.cs
│   │
│   └── Service
│       ├── UserBLL.cs
│       └── EmailService.cs
│
├── DataBaseLayer
│   │
│   ├── Context
│   │   └── UserDbContext.cs
│   │
│   ├── Interface
│   │   └── IUserDAL.cs
│   │
│   └── Repository
│       └── UserDAL.cs
│
├── ModelLayer
│   │
│   ├── DTO
│   │   └── User
│   │       ├── RegisterUserRequest.cs
│   │       ├── LoginRequest.cs
│   │       ├── LoginResponse.cs
│   │       └── UserResponse.cs
│   │
│   └── Entity
│       └── User.cs
│
├── appsettings.json
├── Program.cs
│
└── SQL Server Database
```

---

# ✅ Completed Features

### 👤 User Module

* User Registration
* User Login
* Password Encryption using BCrypt
* Welcome Email Service
* User Validation

### 🔐 Authentication & Authorization

* JWT Token Generation
* JWT Token Validation
* Protected APIs using [Authorize]
* Token Expiration Handling
* Claims-Based Authentication

### 📧 Email Service

* SMTP Configuration
* Automated Welcome Email
* HTML Email Templates

### 🛡️ Security Features

* BCrypt Password Hashing
* Secure JWT Authentication
* Authorization Middleware
* Protected Endpoints

---

# 🛠️ Technologies Used

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt.Net
* SMTP Email Service
* Swagger UI
* Dependency Injection
* LINQ

---

# 📈 Current Progress

✅ User Registration

✅ User Login

✅ Password Hashing

✅ Welcome Email Service

✅ JWT Authentication

✅ JWT Authorization

✅ Protected APIs

🚧 Notes Module (Next Phase)

---

# 🔜 Upcoming Features

### 📝 Notes Module

* Create Note
* Get All Notes
* Get Note By Id
* Update Note
* Move To Trash

### 🗑️ Trash Module

* Get Trashed Notes
* Restore Notes
* Permanent Delete

### 📦 Archive Module

* Archive Note
* Unarchive Note

### 📌 Pin Module

* Pin Note
* Unpin Note

### 🎨 Customization

* Change Note Color
* Image Support
* Reminder Support

---

## 👨‍💻 Developer

**Amarnath Kolla**

Cloud Researcher & .NET Trainee ☁️💻

