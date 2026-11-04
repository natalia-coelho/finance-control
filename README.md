# Finance Control

Projeto legado de controle financeiro familiar e repositório de referência para construir um workflow agêntico de engenharia de software. A prioridade atual é estabelecer um processo de desenvolvimento rastreável e supervisionado antes de ampliar as funcionalidades financeiras.

## Estado atual

O repositório contém uma solução ASP.NET Core em C# com projetos separados para domínio, aplicação, infraestrutura e API, além de um projeto de testes xUnit.

- A solução e os projetos atualmente têm como alvo **.NET 8**.
- A API expõe operações básicas de consulta e criação de transações em `GET /api/transactions` e `POST /api/transactions`.
- A persistência configurada na API usa o provider **Entity Framework Core InMemory**. Os dados não são duráveis entre reinicializações.
- Os testes atuais cobrem regras básicas da entidade `Transaction` e operações do repositório usando banco InMemory.
- Ainda não há persistência relacional, migrations, importador da planilha financeira nem interface de consultas SQL.

As especificações em `docs/` descrevem a direção desejada, que ainda não corresponde integralmente à implementação. Consulte `AGENTS.md` antes de trabalhar no repositório e o backlog em `docs/planning/backlog-adaptacao.md` para as lacunas conhecidas. Há decisões de arquitetura a reconciliar antes da migração da persistência.

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
docs/
  product/                       # Requisitos de produto
  architecture/                  # Direção arquitetural do sistema
  decisions/                     # Decisões do ambiente agêntico
  planning/                      # Backlog de adaptação
```

## Requisitos

- .NET 8 SDK

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

## Workflow agêntico

O ambiente agêntico está em fase inicial. O `AGENTS.md` define as instruções operacionais para agentes; as especificações em `docs/` definem o contexto de produto e arquitetura. O fluxo começa com execução supervisionada: tarefas delimitadas, verificações pertinentes, revisão do diff e relato dos resultados.

## Direção futura

As especificações propõem evoluir gradualmente para uma base financeira rastreável, com importação idempotente do histórico e consultas seguras. Framework, banco de dados, migrations e outros pontos ainda precisam ser reconciliados/confirmados. Não interprete a direção documentada como funcionalidade já disponível.
