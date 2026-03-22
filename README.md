# 🛡️ SecureVault API - C# & Cybersecurity Portfolio

O **SecureVault** é uma Web API desenvolvida em **ASP.NET Core** com foco em segurança desde a concepção (*Security by Design*). O projeto simula um cofre de dados sensíveis, onde a autenticação e autorização são tratadas com padrões rigorosos de mercado.

## 🚀 Tecnologias e Conceitos Aplicados 

### 💻 Backend (C# / .NET 8)
* **ASP.NET Core Web API:** Estrutura robusta para serviços escaláveis.
* **Entity Framework Core:** ORM para manipulação segura de dados.
* **SQLite:** Banco de dados relacional leve e eficiente para persistência.
* **Injeção de Dependência:** Código modular e fácil de testar.
* **Data Transfer Objects (DTOs):** Proteção contra ataques de *Mass Assignment*.

### 🔒 Cybersecurity (Segurança)
* **BCrypt.Net:** Hashing de senhas com *Salt* automático (proteção contra Rainbow Tables).
* **JWT (JSON Web Tokens):** Autenticação *stateless* segura com assinatura HMAC-SHA256.
* **RBAC (Role-Based Access Control):** Controle de acesso baseado em níveis (Admin vs User).
* **Input Validation:** Validação rigorosa de dados (Regex, DataAnnotations) contra XSS e Injection.
* **Protection against SQL Injection:** Uso de consultas parametrizadas via EF Core.

---

## 🛠️ Arquitetura do Projeto

O projeto segue uma estrutura de camadas para separar responsabilidades:

* **Controllers:** Gerenciam as rotas e a validação de entrada via DTOs.
* **Services:** Camada de lógica de segurança (Geração de Tokens, Hashing).
* **Data:** Gerencia o contexto do banco de dados e Migrations.
* **Models:** Representação das entidades de segurança no banco.
