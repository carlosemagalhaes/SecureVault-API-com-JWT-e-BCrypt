# 🛡️ SecureVault API

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=flat&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=flat&logo=jsonwebtokens&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=flat&logo=sqlite&logoColor=white)

Web API desenvolvida em ASP.NET Core com foco em **Security by Design** — 
autenticação e autorização com padrões rigorosos de mercado, 
simulando um cofre de dados sensíveis.

> Projeto desenvolvido para aplicar na prática conceitos de 
> Cibersegurança e desenvolvimento backend seguro.

---

## 🚀 Tecnologias

- **ASP.NET Core Web API** — estrutura para serviços escaláveis
- **Entity Framework Core + SQLite** — persistência com queries parametrizadas
- **BCrypt.Net** — hashing de senhas com salt automático
- **JWT (HMAC-SHA256)** — autenticação stateless segura
- **RBAC** — controle de acesso por roles (Admin / User)

---

## 🔒 Conceitos de Segurança Aplicados

| Ameaça | Solução Implementada |
|---|---|
| Senhas em texto puro | BCrypt com salt automático |
| SQL Injection | Queries parametrizadas via EF Core |
| XSS / Mass Assignment | DTOs + DataAnnotations + Regex |
| Acesso não autorizado | JWT + RBAC |

---

## ▶️ Como Rodar

```bash
# Clone o repositório
git clone https://github.com/carlosemagalhaes/SecureVault-API-com-JWT-e-BCrypt.git

# Entre na pasta
cd SecureVault-API-com-JWT-e-BCrypt

# Restaure as dependências
dotnet restore

# Rode as migrations
dotnet ef database update

# Execute
dotnet run --project SecureVault.Api
```

A API estará disponível em `https://localhost:5001`

---

## 📡 Endpoints Principais

| Método | Rota | Descrição | Auth |
|---|---|---|---|
| POST | /api/auth/register | Cadastro de usuário | ❌ |
| POST | /api/auth/login | Login + retorno de JWT | ❌ |
| GET | /api/vault | Lista itens do cofre | ✅ |
| POST | /api/vault | Adiciona item seguro | ✅ Admin |

---

## 🏗️ Arquitetura

```
SecureVault.Api/
├── Controllers/    # Rotas e validação de entrada
├── Services/       # Lógica de segurança (Token, Hash)
├── Data/           # Contexto EF Core e Migrations
└── Models/         # Entidades e DTOs
```

---

## 👨‍💻 Autor

**Carlos E. Magalhães**  
[LinkedIn](https://www.linkedin.com/in/carlosemagalhaes) • 
[GitHub](https://github.com/carlosemagalhaes)
```
