# MesLite

A lightweight MES (Manufacturing Execution System) clone — a learning project for practicing production-line and batch-tracking patterns, including quality-control business logic.

## Stack
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core + SQL Server
- Swagger / OpenAPI

## Features
- CRUD for production lines and batches
- One-to-many relationship (ProductionLine → Batches)
- Quality-control logic (auto-hold a batch when defect rate exceeds threshold)
- DTO layer for request validation (protects against over-posting)

## Why
Built to practice MES-specific concepts (production floor tracking, quality control) ahead of interviewing for an MES Developer role.
