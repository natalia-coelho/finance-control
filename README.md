# Finance Control

Projeto legado de controle financeiro familiar e repositório de referência para construir um workflow agêntico de engenharia de software. A prioridade atual é estabelecer um processo de desenvolvimento rastreável e supervisionado antes de ampliar as funcionalidades financeiras.

## Estado atual

O repositório contém uma solução ASP.NET Core em C# com projetos separados para domínio, aplicação, infraestrutura e API, além de um projeto de testes xUnit.

- A solução e os projetos têm como alvo **.NET 10**.
- A API expõe operações básicas de consulta e criação de transações em `GET /api/transactions` e `POST /api/transactions`.
- A persistência configurada na API usa o provider **Entity Framework Core InMemory**. Os dados não são duráveis entre reinicializações.
- Os testes atuais cobrem regras básicas da entidade `Transaction` e operações do repositório usando banco InMemory.
- Ainda não há persistência relacional, migrations, importador da planilha financeira nem interface de consultas SQL.

As especificações em `docs/` descrevem a direção desejada, que ainda não corresponde integralmente à implementação. PostgreSQL foi escolhido para a persistência durável inicial (ADR-001), mas a API continua usando InMemory; a configuração do provider, migrations e importação ainda não estão implementadas. Consulte `AGENTS.md` antes de trabalhar no repositório e o backlog em `docs/planning/backlog-adaptacao.md` para as lacunas conhecidas.

## Estrutura

```text
FinanceControl.sln
src/
  FinanceControl.Domain/         # Entidade e regras básicas de transação
  FinanceControl.Application/    # Comandos, consultas, handlers e interfaces
  FinanceControl.Infrastructure/ # DbContext InMemory e repositório
  FinanceControl.Api/            # API ASP.NET Core
tests/
  FinanceControl.Tests/          # Testes xUnit
compose.yaml                     # PostgreSQL local para desenvolvimento
docs/
  product/                       # Requisitos de produto
  architecture/                  # Direção arquitetural do sistema
  decisions/                     # Decisões do ambiente agêntico
  planning/                      # Backlog de adaptação
```

## Requisitos

- .NET 10 SDK

Confirme a versão instalada com:

```bash
dotnet --version
```

## Compilar e testar

Na raiz do repositório:

```bash
dotnet restore FinanceControl.sln
dotnet build FinanceControl.sln --no-restore
dotnet test FinanceControl.sln --no-build
```

## Executar a API

```bash
dotnet run --project src/FinanceControl.Api/FinanceControl.Api.csproj
```

A API informa no terminal os endereços locais usados. A documentação Swagger é habilitada pela configuração atual da aplicação. A base InMemory é temporária e adequada apenas ao estado de desenvolvimento atual.

## PostgreSQL local para desenvolvimento

O `compose.yaml` prepara um PostgreSQL local para os próximos passos de persistência. Ele ainda não está conectado à API; essa integração pertence a B2.4.

Com Docker Engine e Docker Compose v2 instalados, copie `.env.example` para `.env`, defina uma senha local forte e única, e inicie o serviço:

```bash
cp .env.example .env
docker compose up -d postgres
docker compose ps
```

O serviço publica a porta apenas em `127.0.0.1` e mantém os dados em volume nomeado. `docker compose down` para e remove o container sem apagar o volume; não use `docker compose down -v` se quiser preservar os dados.

## Workflow agêntico

O ambiente agêntico está em fase inicial. O `AGENTS.md` define as instruções operacionais para agentes; as especificações em `docs/` definem o contexto de produto e arquitetura. O fluxo começa com execução supervisionada: tarefas delimitadas, verificações pertinentes, revisão do diff e relato dos resultados.

## Direção futura

As especificações propõem evoluir gradualmente para uma base financeira rastreável, com importação idempotente do histórico e consultas seguras. O banco PostgreSQL está decidido, mas migrations, operação e outros pontos ainda precisam ser concluídos. Não interprete a direção documentada como funcionalidade já disponível.
