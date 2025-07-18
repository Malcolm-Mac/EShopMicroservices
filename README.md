# eCommerce Microservices Project

## Overview

This project is a **microservices-based eCommerce system** built using **.NET 8**, **C# 12**, and Docker. It consists of various microservices that handle distinct parts of the eCommerce workflow, including catalog, basket, discount, and ordering management. The architecture follows best practices such as Domain-Driven Design (DDD), Command-Query Responsibility Segregation (CQRS), Clean Architecture, and N-Layer Architecture.

The application is fully **dockerized** for easy deployment and scaling, and all microservices communicate using **gRPC**, **RabbitMQ**, and **MassTransit**.

### Key Components:

* **Catalog Microservice**
* **Basket Microservice**
* **Discount.Grpc Microservice**
* **Ordering Microservice**
* **API Gateway with YARP Reverse Proxy**
* **Shopping Web Client Application (with Refit)**

---

## Microservices

### 1. **Ordering Microservice**

This microservice handles the ordering process and is built using **Domain-Driven Design (DDD)**, **CQRS**, and **Clean Architecture** principles.

* **Technologies:**

  * **.NET 8**, **C# 12**
  * **Entity Framework Core**, **Microsoft SQL Server**
  * **MediatR**, **Mapster**
  * **Carter**, **AspNetCore.HealthChecks.SqlServer**, **AspNetCore.HealthChecks.UI.Client**
  * **Dockerized**

* **Design Patterns:**

  * **CQRS** (separation of read and write models)
  * **Clean Architecture** (separating concerns for maintainability)

* **Endpoints:**

  * Handles order creation, status updates, and retrieval

### 2. **Basket Microservice**

Manages the shopping basket, including adding and removing products, as well as calculating total price.

* **Technologies:**

  * **.NET 8**, **C# 12**
  * **PostgreSQL**, **Marten** (for event sourcing)
  * **Redis** (for caching)
  * **Mapster**, **MediatR**, **Entity Framework Core**
  * **Scrutor** (for DI configuration)
  * **Dockerized**

* **Design Patterns:**

  * **Vertical Slice Architecture**: Organized into **Application**, **Domain**, and **Infrastructure** layers
  * **CQRS**: Separate read and write models for scalability
  * **Proxy** and **Decorator** patterns for caching and request decoration

* **Communication:**

  * Uses **RabbitMQ** and **MassTransit** to communicate with the **Ordering Microservice** for basket checkout

### 3. **Discount.Grpc Microservice**

Handles discount calculations using **gRPC** to provide fast, typed communication between services.

* **Technologies:**

  * **.NET 8**, **C# 12**
  * **SQLite**, **Entity Framework Core**
  * **gRPC** for communication
  * **Dockerized**

* **Design Pattern:**

  * **N-Layer Architecture** for separation of concerns

### 4. **Shopping Web Client Application**

A front-end client application that interacts with the API Gateway, leveraging **YARP Reverse Proxy** to route requests to various microservices.

* **Technologies:**

  * **Refit** (for making HTTP requests to the API Gateway)
  * **Dockerized**

* **Communication:**

  * Uses the **YARP Reverse Proxy** to access endpoints from different microservices

---

## Architecture

The system follows a **microservice architecture** where each service is responsible for a specific domain and can evolve independently. The **API Gateway** is responsible for routing client requests to appropriate microservices, abstracting away the complexity of individual service calls.

The **Vertical Slice Architecture** used in the Basket Microservice organizes the application into the following layers:

* **Application**: Contains business logic for processing commands and queries.
* **Domain**: Contains the core business rules, entities, and aggregates.
* **Infrastructure**: Handles the database, caching, and external integrations.

---

## Tech Stack & Design Patterns

* **.NET 8 & C# 12**: The latest version of .NET and C# for building high-performance, cross-platform microservices.
* **CQRS**: Ensures separation of concerns for reading and writing data, providing better scalability and maintainability.
* **DDD**: Emphasizes the importance of domain-driven design, making the system more aligned with business needs.
* **Docker**: Each microservice is dockerized, enabling consistent, scalable deployment in containerized environments.
* **gRPC**: High-performance RPC framework for communication between microservices.
* **MassTransit & RabbitMQ**: For asynchronous messaging and event-driven communication between Basket and Ordering microservices.
* **Redis**: In-memory caching layer to speed up basket operations.
* **Marten**: A document database and event store used in Basket for persistent storage and event sourcing.

---

## Running the Project

### Prerequisites

1. **Docker**: Ensure Docker is installed and running on your machine.
2. **.NET 8 SDK**: Ensure you have the .NET 8 SDK installed for local development.

### Steps to Run Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ecommerce-microservices.git
   cd ecommerce-microservices
   ```

2. Build and run the Docker containers:

   ```bash
   docker-compose up --build
   ```

   This will start all the services in Docker containers, including the API Gateway and the various microservices (Ordering, Basket, Discount, etc.).

3. The application will be accessible via the **API Gateway** (typically running on `http://localhost:5000`).

---

## API Gateway with YARP Reverse Proxy

The **API Gateway** is used to route client requests to the appropriate microservice endpoints. It uses **YARP** (Yet Another Reverse Proxy) for intelligent request forwarding.

The client (Shopping Web Application) communicates through the API Gateway, and the API Gateway routes requests to the corresponding microservices (Catalog, Basket, Discount, Ordering).

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Acknowledgements

* [YARP Reverse Proxy](https://github.com/microsoft/reverse-proxy)
* [MassTransit](https://masstransit.io/)
* [MediatR](https://github.com/jbogard/MediatR)
* [Marten](https://martendb.io/)
* [gRPC](https://grpc.io/)
