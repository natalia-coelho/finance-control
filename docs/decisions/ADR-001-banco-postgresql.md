# ADR-001 — PostgreSQL como persistência durável inicial

- **Status:** Aceita
- **Data:** 05/11/2026
- **Decisora:** responsável pelo projeto

## Contexto

As especificações divergiam entre SQLite, descrito na decisão do ambiente agêntico, e PostgreSQL, descrito em `docs/architecture/architecture.md`. O legado ainda usa EF Core InMemory, sem persistência durável. A responsável confirmou PostgreSQL como banco servidor inicial e aceita configurar e manter esse serviço.

## Decisão

Usar PostgreSQL como persistência durável inicial do Finance Control. Clientes acessarão os dados por meio da aplicação, não por conexão direta ao banco. A hospedagem doméstica permanece o cenário-alvo; detalhes do serviço, segurança operacional e backup/restauração serão definidos antes da implantação.

Esta decisão define somente a persistência durável inicial. A estratégia de migrations está no ADR-002; o MVP e seu primeiro incremento estão definidos no PRD, seção 5.1. Nenhuma migração de código foi feita como parte da decisão.

## Alternativas consideradas

- **SQLite:** menor operação e adequado a um arquivo local para um único host; rejeitado nesta decisão em favor do banco servidor escolhido pela responsável.
- **PostgreSQL:** servidor relacional, alinhado à arquitetura técnica já descrita; selecionado, com o custo de configuração, operação, credenciais e backups.

## Consequências

- O provider de persistência durável deverá ser compatível com PostgreSQL (a arquitetura propõe EF Core/Npgsql).
- Build, testes de integração, configuração e documentação do banco deverão cobrir o ambiente PostgreSQL quando B2.4 e B3.7 forem executados.
- Usuários, backups, restauração, rede e privilégios mínimos permanecem por definir em B5.1/B2.6.
- A implementação do provider e a operação do PostgreSQL permanecem em B2.4, B2.6 e B5.1.

## Referências

- `docs/architecture/architecture.md`, seções 3, 6 e 9.
- `docs/decisions/decisoes-arquiteturais-ambiente-agentico.md`, seção 6.
- `docs/planning/backlog-adaptacao.md`, itens B0.1, B2.4–B2.6 e B5.1.
