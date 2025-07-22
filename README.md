# Customer Management

Um sistema completo de gerenciamento de clientes desenvolvido em .NET 8 com arquitetura limpa, focado em multi-tenancy e funcionalidades empresariais.

## 🌐 Demo Online

**🚀 Teste sem instalar nada!**

Você pode testar o projeto diretamente sem precisar clonar ou configurar nada em sua máquina:

- **API Demo**: [https://api.customermanagement.jean.dev](https://api.customermanagement.jean.dev)
- **Documentação Swagger**: [https://api.customermanagement.jean.dev/swagger](https://api.customermanagement.jean.dev/swagger)

> **Nota**: Esta é uma instância de demonstração. Os dados podem ser resetados periodicamente.

## ✨ Funcionalidades Principais

- **Gestão de Clientes**: Cadastro completo com dados pessoais, documentos (CPF/CNPJ) e endereços
- **Sistema Multi-tenant**: Isolamento completo de dados por empresa/organização
- **Autenticação e Autorização**: Sistema seguro de login com JWT e controle de acesso
- **Geração de Recibos PDF**: Criação automática de recibos em PDF com formatação profissional
- **Upload de Arquivos**: Armazenamento seguro em AWS S3 com URLs pré-assinadas
- **Validações Robustas**: Validação de dados com FluentValidation
- **Sistema de Email**: Envio de notificações e comunicações
- **Rate Limiting**: Proteção contra spam e ataques DDoS

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture** com a seguinte estrutura:

```
├── CustomerManagement.Core/          # Entidades e interfaces
├── CustomerManagement.Application/   # Casos de uso e comandos
├── CustomerManagement.Infrastructure/# Implementações e serviços externos
├── CustomerManagement.API/          # Controllers e configurações
└── CustomerManagement.UnitTests/    # Testes unitários
```

### Padrões Utilizados

- **CQRS** com MediatR
- **Repository Pattern**
- **Dependency Injection**
- **Unit of Work**

## 🛠️ Tecnologias

- **.NET 8**
- **Entity Framework Core** com PostgreSQL
- **MediatR** - CQRS e mediação
- **FluentValidation** - Validação de dados
- **QuestPDF** - Geração de PDFs
- **MailKit** - Envio de emails
- **AWS SDK** - Integração com S3
- **xUnit** - Testes unitários
- **Docker** - Containerização
- **GitHub Actions** - CI/CD

## 📦 Pré-requisitos

- .NET 8 SDK
- PostgreSQL
- Docker (opcional)
- Conta AWS (para armazenamento de arquivos)
- Servidor SMTP (para envio de emails)

## 🚀 Como Executar

### Opção 1: Execução Local

1. **Clone o repositório**
```bash
git clone [url-do-repositorio]
cd CustomerManagementAPI
```

2. **Configure as variáveis de ambiente ou appsettings.json**
```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost;Database=CustomerManagement;Username=seu_usuario;Password=sua_senha"
  },
  "Jwt": {
    "Key": "sua_chave_secreta_jwt_aqui",
    "Issuer": "CustomerManagement",
    "Audience": "CustomerManagement"
  },
  "SmtpSettings": {
    "Server": "seu-servidor-smtp",
    "Port": 587,
    "Username": "seu-usuario",
    "Password": "sua-senha",
    "SenderEmail": "seu-email",
    "SenderName": "Nome do Remetente"
  },
  "Storage": {
    "ServiceURL": "https://s3.amazonaws.com",
    "BucketName": "seu-bucket",
    "AccessKeyId": "sua-access-key",
    "SecretAccessKey": "sua-secret-key"
  },
  "FrontEndUrl": {
    "Url": "http://localhost:3000"
  }
}
```

3. **Execute as migrações**
```bash
dotnet ef database update --project CustomerManagement.Infrastructure --startup-project CustomerManagement.API
```

4. **Execute a aplicação**
```bash
dotnet run --project CustomerManagement.API
```

### Opção 2: Execução com Docker

1. **Clone o repositório**
```bash
git clone [url-do-repositorio]
cd CustomerManagementAPI
```

2. **Configure as variáveis de ambiente no docker-compose.yml**

3. **Execute com Docker Compose**
```bash
docker compose up -d --build
```

## 📋 Endpoints Principais

### Autenticação
- `POST /api/auth/login` - Autenticação de usuário
- `POST /api/auth/forgot-password` - Solicitar recuperação de senha
- `POST /api/auth/reset-password` - Redefinir senha

### Usuários
- `GET /api/users` - Listar usuários
- `POST /api/users` - Criar usuário
- `PUT /api/users/{id}` - Atualizar usuário
- `DELETE /api/users/{id}` - Excluir usuário

### Clientes
- `GET /api/customers` - Listar clientes
- `GET /api/customers/{id}` - Obter cliente por ID
- `POST /api/customers` - Criar cliente
- `PUT /api/customers/{id}` - Atualizar cliente
- `DELETE /api/customers/{id}` - Excluir cliente

### Recibos
- `GET /api/receipts` - Listar recibos
- `POST /api/receipts` - Criar recibo
- `GET /api/receipts/{id}/pdf` - Download do PDF do recibo

### Utilitários
- `GET /api/addresses/{cep}` - Buscar endereço por CEP
- `GET /api/states` - Listar estados
- `GET /api/cities` - Listar cidades

## 🔒 Segurança

- **Autenticação JWT**: Tokens seguros com expiração
- **Rate Limiting**: Proteção contra spam (5 requests por 5 segundos por IP)
- **Validação de entrada**: FluentValidation em todos os endpoints
- **Hash de senhas**: SHA256 para armazenamento seguro
- **Middleware de exceções**: Tratamento centralizado de erros

## 📄 Funcionalidades de Destaque

### Geração de Recibos
O sistema gera recibos profissionais em PDF com:
- Formatação automática de valores por extenso
- Dados completos do cliente e empresa
- Numeração sequencial
- Layout responsivo e profissional

### Sistema Multi-tenant
- Isolamento completo de dados por tenant
- Usuários vinculados a organizações específicas
- Controle de acesso baseado em roles
- Filtros automáticos por tenant

### Validação de Documentos
- Formatação automática de CPF/CNPJ
- Validação de números de telefone brasileiros
- Integração com API de CEP para endereços

### Integração com Serviços Externos
- **OpenCEP**: Busca automática de endereços
- **AWS S3**: Armazenamento de arquivos
- **SMTP**: Envio de emails transacionais

## 🚀 CI/CD

O projeto possui pipeline automatizado com GitHub Actions que:
- Executa build automático
- Realiza deploy para servidor Ubuntu
- Utiliza Docker para containerização
- Reinicia serviços automaticamente

## 📚 Documentação da API

A documentação da API está disponível via Swagger UI:
- **Demo Online**: [https://api.customermanagement.jean.dev/swagger](https://api.customermanagement.jean.dev/swagger)
- **Local**: `http://localhost:5000/swagger`

## 🤝 Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Faça fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### Padrões de Código
- Siga os princípios SOLID
- Utilize padrões da Clean Architecture
- Escreva testes para novas funcionalidades
- Mantenha a cobertura de testes alta

## 🔧 Configuração de Desenvolvimento

### Pré-requisitos para Desenvolvimento
- Visual Studio 2022 ou VS Code
- .NET 8 SDK
- PostgreSQL local ou Docker
- Git

### Estrutura de Branches
- `main` - Branch principal (produção)
- `develop` - Branch de desenvolvimento
- `feature/nome-da-feature` - Branches de features

## 📈 Performance

- **Rate Limiting**: 5 requests por 5 segundos por IP
- **Connection Pooling**: Entity Framework otimizado
- **Async/Await**: Operações assíncronas em toda aplicação
- **Caching**: Implementado onde apropriado

## 🌟 Roadmap

- [ ] Finalizar testes unitários
- [ ] Implementar testes de integração

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

Para mais informações, entre em contato ou abra uma issue no repositório.