# Finance Control Microservice - Onion Architecture

A clean, minimal .NET 8 Web API microservice for personal finance control, built following **Onion Architecture** principles.

## 🏗️ Onion Architecture

This project implements **Onion Architecture**, a refined version of Clean Architecture that emphasizes:

- **Dependency Direction**: Dependencies point inward - outer layers depend on inner layers, never the reverse
- **Core Domain**: Business entities and rules at the center with no external dependencies
- **Application Services**: Business logic and use cases that orchestrate domain objects
- **Infrastructure**: External concerns like databases, APIs, and frameworks
- **API Layer**: Presentation layer that depends on all inner layers

### Architecture Layers

```
┌─────────────────────────────────────────────────────────────┐
│                    API Layer (Presentation)                 │
│                    - Controllers                           │
│                    - Middleware                            │
│                    - Configuration                         │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                Infrastructure Layer (External)              │
│                - Database Context                          │
│                - Repository Implementations                │
│                - External Service Clients                  │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│              Application Layer (Business Logic)            │
│              - Use Cases                                   │
│              - Command/Query Handlers                     │
│              - Business Rules                             │
│              - Interface Definitions                      │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                   Domain Layer (Core)                      │
│                   - Entities                              │
│                   - Value Objects                         │
│                   - Domain Services                       │
│                   - Business Rules                        │
└─────────────────────────────────────────────────────────────┘
```

## 📁 Project Structure

```
src/
├── FinanceControl.Domain/           # Core business entities (no dependencies)
│   └── Entities/
│       └── Transaction.cs          # Domain entity with business rules
├── FinanceControl.Application/       # Business logic and use cases
│   ├── Commands/                   # CQRS commands
│   ├── Queries/                    # CQRS queries
│   ├── Handlers/                   # Command/Query handlers
│   ├── Interfaces/                 # Repository interfaces
│   └── UseCases/                   # Business use cases
├── FinanceControl.Infrastructure/   # Data access and external services
│   ├── Data/                       # EF Core context and unit of work
│   └── Repositories/               # Repository implementations
└── FinanceControl.Api/              # Web API controllers and configuration

tests/
└── FinanceControl.Tests/            # Unit tests for all layers
```

## 🚀 Key Features

- **Onion Architecture**: Clean dependency direction and separation of concerns
- **Domain-Driven Design**: Rich domain entities with business rules
- **CQRS Pattern**: Commands and queries separated using MediatR
- **Repository Pattern**: Abstracted data access through interfaces
- **Unit of Work**: Transaction management and consistency
- **In-Memory Database**: Entity Framework Core with in-memory provider for development
- **Minimal Dependencies**: Only essential .NET packages

## 🏛️ Architecture Benefits

### 1. **Dependency Inversion**
- Outer layers depend on inner layers
- Domain layer has zero external dependencies
- Easy to swap implementations (e.g., different databases)

### 2. **Testability**
- Each layer can be tested in isolation
- Mock interfaces for external dependencies
- Domain logic tested without infrastructure

### 3. **Maintainability**
- Clear separation of concerns
- Business rules centralized in domain
- Easy to modify without affecting other layers

### 4. **Scalability**
- Add new features by extending layers
- Replace infrastructure without changing business logic
- Support multiple presentation layers (API, gRPC, etc.)

## 🛠️ Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or VS Code

## 🔧 Getting Started

### 1. Build the Solution

```bash
dotnet build
```

### 2. Run the API

```bash
cd src/FinanceControl.Api
dotnet run
```

The API will be available at `https://localhost:7000` (or the port shown in the console).

### 3. Run Tests

```bash
dotnet test
```

## 📡 API Endpoints

### Transactions

- **GET** `/api/transactions` - Retrieve all transactions
- **POST** `/api/transactions` - Add a new transaction

#### Transaction Model

```json
{
  "amount": 100.50,
  "category": "Food",
  "date": "2024-01-15T10:30:00Z",
  "description": "Lunch at restaurant"
}
```

## 🧪 Testing

The solution includes comprehensive unit tests:

- **Domain Tests**: Business rule validation
- **Application Tests**: Use case logic
- **Infrastructure Tests**: Repository operations
- **Integration Tests**: End-to-end scenarios

### Test Examples

- `AddTransaction_ShouldCreateNewTransaction` - Tests transaction creation
- `GetTransactions_ShouldReturnAllTransactions` - Tests transaction retrieval
- `Transaction_Create_WithInvalidAmount_ShouldThrowException` - Tests business rules
- `Transaction_Create_WithEmptyCategory_ShouldThrowException` - Tests validation

## 🔮 Future Enhancements

This Onion Architecture foundation makes it easy to add:

### **Authentication & Authorization**
- JWT tokens, user management
- Role-based access control
- OAuth integration

### **Real Database**
- SQL Server, PostgreSQL with migrations
- Database-specific optimizations
- Connection pooling and resilience

### **Advanced Features**
- Budgets, reports, categories
- Recurring transactions
- Financial analytics and insights

### **Infrastructure**
- Docker containerization
- AWS integration (S3, DynamoDB, Lambda)
- Message queues (SQS, RabbitMQ)
- Caching (Redis, ElastiCache)

### **Architecture Extensions**
- Event sourcing and CQRS
- Microservices communication
- API versioning and rate limiting
- Health checks and monitoring

## 🏛️ Design Principles

- **Dependency Inversion**: High-level modules don't depend on low-level modules
- **Single Responsibility**: Each class has one reason to change
- **Open/Closed**: Open for extension, closed for modification
- **Interface Segregation**: Clients don't depend on interfaces they don't use
- **Dependency Injection**: Services are injected, not created
- **Domain Primacy**: Business rules are in the domain, not in infrastructure

## 📦 Dependencies

- **MediatR**: CQRS implementation
- **Entity Framework Core**: Data access with in-memory provider
- **Swagger**: API documentation
- **xUnit**: Unit testing framework

## 🚀 Deployment Ready

The project is configured for easy expansion:
- Clean Onion Architecture with proper dependency direction
- Comprehensive dependency injection
- Repository pattern with unit of work
- CQRS architecture for scalability
- Minimal external dependencies
- Comprehensive test coverage
- Easy to add new features and swap implementations

## 📝 License

This project is open source and available under the MIT License.
