# ADR-002 — EF Core Migrations versionadas

- **Status:** Aceita
- **Data:** 05/11/2026
- **Decisora:** responsável pelo projeto

## Contexto

A arquitetura já propunha EF Core e migrations versionadas, mas deixava em aberto se o schema seria mantido por EF Core Migrations ou scripts SQL-first. A responsável confirmou EF Core Migrations versionadas no Git e autorizou SQL explícito para consultas ou operações especiais.

## Decisão

Usar EF Core Migrations versionadas no Git como fonte canônica de evolução do schema PostgreSQL. Revisar as migrations geradas antes de aplicá-las. SQL explícito pode ser usado em consultas ou operações específicas quando melhorar clareza ou adequação, sem manter uma trilha SQL-first concorrente para o schema.

Esta decisão não gera migrations nem altera a persistência atual InMemory; implementação e validação permanecem nos itens B2.4–B2.5.

## Alternativas consideradas

- **SQL-first:** scripts SQL versionados dariam controle explícito do schema, mas exigiriam sincronizar manualmente o modelo EF e foram preteridos pela responsável.
- **EF Core Migrations:** selecionado por integrar a evolução do schema à ferramenta de persistência já definida, com artefatos revisáveis no Git.

## Consequências

- Mudanças de schema deverão incluir migrations EF revisadas e aplicáveis em ordem.
- Operações críticas deverão ser validadas contra PostgreSQL; migrations não devem ser aplicadas a dados reais sem revisão e autorização aplicáveis.
- B2.5 continua pendente até haver migrations e validação reproduzível.

## Referências

- `docs/architecture/architecture.md`, seções 3, 5.2 e 6.2.
- `docs/decisions/decisoes-arquiteturais-ambiente-agentico.md`, seção 6.1.
- `docs/planning/backlog-adaptacao.md`, item B2.5.
