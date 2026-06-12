# 🚀 Fundoo Notes Backend API

Fundoo Notes is a Note Management Application developed using ASP.NET Core Web API, Entity Framework Core, SQL Server, Redis Cache, Docker, and Layered Architecture.

The application provides secure user authentication using JWT Tokens, password encryption using BCrypt, SMTP Email Services, complete Notes Management, Labels Management, Redis Caching, and Note Collaboration functionalities.

---

# 📌 Project Overview

Fundoo Notes follows:

- 4-Layer Architecture
- Entity Framework Core
- Code First Approach
- SQL Server Database
- Redis Cache Integration
- JWT Authentication
- Docker Containerization

---

# 🏗️ Architecture

Presentation Layer (Controllers)

↓

Business Logic Layer (BLL)

↓

Data Access Layer (DAL)

↓

Database Layer (SQL Server)

↓

Redis Cache Layer

<img width="919" height="693" alt="image" src="https://github.com/user-attachments/assets/0f5a8177-67f9-4b11-b713-2cab483650be" />


---

# ✨ Features Implemented

## 👤 User Module

- User Registration
- User Login
- User Validation
- BCrypt Password Hashing
- SMTP Email Service
- JWT Token Generation
- JWT Authentication
- JWT Authorization
- Protected APIs using Authorize Attribute

---

## 📝 Notes Module

### Basic Operations

- Create Note
- Get All Notes
- Get Note By Id
- Update Note
- Delete Note

### Trash Management

- Move To Trash
- Restore Note
- Get Trashed Notes
- Permanent Delete

### Archive Management

- Archive Note
- UnArchive Note
- Get Archived Notes

### Pin Management

- Pin Note
- UnPin Note

### Additional Features

- Change Note Colour
- Note Reminder
- Note Image Support

---

## 🏷️ Labels Module

- Create Label
- Update Label
- Delete Label
- Get All Labels
- Add Label To Note
- Remove Label From Note
- Get Labels By Note

---

## 🤝 Collaborator Module

Allows multiple users to collaborate on the same note.

### Features

- Add Collaborator to Note
- Get Collaborators of a Note
- Remove Collaborator
- Shared Note Management
- Permission Based Collaboration (VIEW / EDIT)

---

## ⚡ Redis Cache Integration

Implemented Redis using Docker containers.

### Redis Features

- Note Data Caching
- Faster Retrieval of Frequently Accessed Notes
- Reduced SQL Server Database Calls
- Improved API Performance
- Cache Expiration Support

---

## 🐳 Docker Integration

Redis Server is deployed using Docker.

### Implemented

- Redis Container Setup
- Redis Configuration
- Application Integration with Redis Cache
- Persistent Redis Service

---

# 🗄️ Database Tables

## Users

- UserId
- FirstName
- LastName
- Email
- Password
- CreatedAt
- UpdatedAt

---

## Notes

- NoteId
- Title
- Description
- Reminder
- Colour
- Image
- IsArchive
- IsPin
- IsTrash
- UserId

---

## Labels

- LabelId
- LabelName
- UserId

---

## NoteLabels

- Id
- NoteId
- LabelId

---

## Collaborators

- CollaboratorId
- OwnerUserId
- CollaboratorUserId
- NoteId
- Email
- Permission
- CreatedAt

---

# 🔐 Security Features

- BCrypt Password Hashing
- JWT Authentication
- JWT Authorization
- Claims Based Authorization
- Protected Endpoints
- Secure User Validation

---

# ⚙️ Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Redis
- Docker
- JWT Authentication
- BCrypt.Net
- SMTP Email Service
- Swagger UI
- LINQ
- Dependency Injection

---

# 📂 Project Structure

FundooNotes

├── Controllers

├── BusinessLogicLayer

├── DataBaseLayer

├── ModelLayer

├── Redis Integration

├── Migrations

├── appsettings.json

├── Program.cs

└── SQL Server Database

---

# 📈 Current Progress

✅ User Module Completed

✅ Authentication & Authorization Completed

✅ Notes Module Completed

✅ Labels Module Completed

✅ Redis Cache Integration Completed

✅ Docker Integration Completed

✅ Collaborator Module Completed

🔄 Next Planned Features

- RabbitMQ Integration
- Notification Services
- Microservices Architecture
- Unit Testing
- CI/CD Pipeline

# 👨‍💻 Author

**Amarnath Kolla**
Cloud Researcher & .NET Trainee ☁️💻
