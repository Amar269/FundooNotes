# 🚀 Fundoo Notes Backend API

Fundoo Notes is a Note Management Application developed using **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and **Layered Architecture**.

The application provides secure user authentication using **JWT Tokens**, password encryption using **BCrypt**, email notifications, and complete note management functionalities.

---

# 📌 Project Overview

Fundoo Notes follows a clean **4-Layer Architecture** and **Code First Approach** using Entity Framework Core.

The application currently supports:

* User Registration
* User Login
* JWT Authentication & Authorization
* Password Hashing using BCrypt
* Welcome Email Service
* Complete Notes Management Module

---

# 🏗️ Architecture

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
<img width="538" height="632" alt="image" src="https://github.com/user-attachments/assets/32c75074-82bc-4196-ae00-6f3b2e63b356" />


---

# 🔄 Request Flow Diagram

```text
User
 │
 ▼
Swagger UI / Postman
 │
 ▼
Controller
 │
 ▼
Business Logic Layer
 │
 ▼
Data Access Layer
 │
 ▼
Entity Framework Core
 │
 ▼
SQL Server Database
 │
 ▼
Response Returned
```

---

# 👤 User Registration Flow

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
SQL Server
 │
 ▼
User Created Successfully
```

---

# 🔐 Login & JWT Authentication Flow

<img width="721" height="511" alt="image" src="https://github.com/user-attachments/assets/0235892c-53fc-47fc-bd87-527c83e7bb80" />

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

 ├── Verify Email
 ├── Verify Password
 ├── Generate Claims
 ├── Generate JWT Token

 │
 ▼
Return JWT Token
```

---

# 🛡️ Protected API Flow

```text
Client Request
 │
 │ Bearer Token
 ▼
JWT Middleware

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

---

# 📝 Notes Module Flow

```text
User
 │
 ▼
NoteController
 │
 ▼
NoteBLL

 ├── Validate Note
 ├── Business Logic
 ├── Authorization Check

 │
 ▼
NoteDAL
 │
 ▼
Entity Framework Core
 │
 ▼
SQL Server
 │
 ▼
Response Returned
```

---

# 🗄️ Database Design

## Users Table

| Column    | Data Type | Description            |
| --------- | --------- | ---------------------- |
| UserId    | INT       | Primary Key            |
| FirstName | NVARCHAR  | User First Name        |
| LastName  | NVARCHAR  | User Last Name         |
| Email     | NVARCHAR  | Unique Email           |
| Password  | NVARCHAR  | BCrypt Hashed Password |
| CreatedAt | DATETIME  | Created Timestamp      |
| UpdatedAt | DATETIME  | Updated Timestamp      |

---

## Notes Table

| Column      | Data Type | Description       |
| ----------- | --------- | ----------------- |
| NotesId     | INT       | Primary Key       |
| Title       | NVARCHAR  | Note Title        |
| Description | NVARCHAR  | Note Description  |
| Reminder    | DATETIME  | Reminder Date     |
| Colour      | NVARCHAR  | Note Colour       |
| Image       | NVARCHAR  | Note Image        |
| IsArchive   | BIT       | Archive Status    |
| IsPin       | BIT       | Pin Status        |
| IsTrash     | BIT       | Trash Status      |
| CreatedAt   | DATETIME  | Created Timestamp |
| UpdatedAt   | DATETIME  | Updated Timestamp |
| UserId      | INT       | Foreign Key       |


<img width="112" height="405" alt="image" src="https://github.com/user-attachments/assets/ed13c154-8002-4b27-af8c-a209f379d854" />


---

# 📂 Current Project Structure

```text
FundooNotes
│
├── Controllers
│   ├── UserController.cs
│   └── NoteController.cs
│
├── BusinessLogicLayer
│   │
│   ├── Interface
│   │   ├── IUserBLL.cs
│   │   ├── INoteBLL.cs
│   │   └── IEmailService.cs
│   │
│   └── Service
│       ├── UserBLL.cs
│       ├── NoteBLL.cs
│       └── EmailService.cs
│
├── DataBaseLayer
│   │
│   ├── Context
│   │   └── DbContext.cs
│   │
│   ├── Interface
│   │   ├── IUserDAL.cs
│   │   └── INoteDAL.cs
│   │
│   ├── Repository
│   │   ├── UserDAL.cs
│   │   └── NoteDAL.cs
│   │
│   └── Migrations
│
├── ModelLayer
│   │
│   ├── DTO
│   │
│   │   ├── User
│   │   │   ├── RegisterUserRequest.cs
│   │   │   ├── LoginRequest.cs
│   │   │   ├── LoginResponse.cs
│   │   │   └── UserResponse.cs
│   │
│   │   └── Notes
│   │       ├── CreateNoteRequest.cs
│   │       ├── UpdateNoteRequest.cs
│   │       ├── ChangeColourRequest.cs
│   │       └── NoteResponse.cs
│   │
│   └── Entity
│       ├── User.cs
│       └── Notes.cs
│
├── appsettings.json
├── Program.cs
│
└── SQL Server Database
```

---

# 📡 API Endpoints

## User APIs

| Method | Endpoint           |
| ------ | ------------------ |
| POST   | /api/User/Register |
| POST   | /api/User/Login    |

---

## Note APIs

| Method | Endpoint                     |
| ------ | ---------------------------- |
| POST   | /api/Note/Create             |
| GET    | /api/Note/GetAll             |
| GET    | /api/Note/GetID/{noteId}     |
| PUT    | /api/Note/Update/{noteId}    |
| DELETE | /api/Note/Trash/{noteId}     |
| PUT    | /api/Note/Restore/{noteId}   |
| PUT    | /api/Note/Archive/{noteId}   |
| PUT    | /api/Note/UnArchive/{noteId} |
| PUT    | /api/Note/Pin/{noteId}       |
| PUT    | /api/Note/UnPin/{noteId}     |
| DELETE | /api/Note/Delete/{noteId}    |
| PUT    | /api/Note/Colour/{noteId}    |

---

# ✅ Completed Features

## 👤 User Module

* User Registration
* User Login
* User Validation
* Welcome Email Service
* BCrypt Password Hashing

---

## 🔐 Authentication & Authorization

* JWT Token Generation
* JWT Token Validation
* Claims-Based Authentication
* Token Expiration Handling
* Protected APIs using [Authorize]

---

## 📝 Notes Module

### Basic Note Operations

* Create Note
* Get All Notes
* Get Note By Id
* Update Note

### Trash Management

* Move To Trash
* Restore Note
* Get Trashed Notes
* Permanent Delete

### Archive Management

* Archive Note
* UnArchive Note
* Get Archived Notes

### Pin Management

* Pin Note
* UnPin Note

### Additional Features

* Change Note Colour

---

# 🛡️ Security Features

* BCrypt Password Hashing
* JWT Authentication
* JWT Authorization
* Protected Endpoints
* Claims-Based Authorization

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
* Entity Framework Migrations

---

# 📈 Current Progress

```text
✅ User Registration
✅ User Login
✅ BCrypt Password Hashing
✅ Welcome Email Service
✅ JWT Authentication
✅ JWT Authorization
✅ Create Note
✅ Get All Notes
✅ Get Note By Id
✅ Update Note
✅ Trash Management
✅ Archive Management
✅ Pin Management
✅ Change Colour
```

---

# 🔜 Upcoming Features

```text
🏷️ Labels Module
🔔 Reminder Notifications
🤝 Collaborator Feature

```

---

# 👨‍💻 Author

**Amarnath Kolla**
Cloud Researcher & .NET Trainee ☁️💻


