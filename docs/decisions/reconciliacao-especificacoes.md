# Reconciliação das especificações

**Status:** concluída em 05/11/2026; decisões registradas nas fontes canônicas e ADRs correspondentes.
**Data:** 05/11/2026
**Relacionada a:** B0.1 em `docs/planning/backlog-adaptacao.md`

## Objetivo e fontes

Esta análise registra como as divergências foram resolvidas. O código atual continua sendo a fonte para descrever o que está implementado; a conclusão deste item não significa que as decisões técnicas já foram implementadas.

Fontes canônicas adotadas nesta reconciliação:

- `docs/product/PRD.md`: requisitos, regras de negócio e escopo do MVP. Está em Draft; mudanças de escopo devem ser decididas pela responsável e registradas aqui.
- `docs/architecture/architecture.md`: direção, decisões e restrições técnicas da solução.
- ADRs em `docs/decisions/`: decisões duradouras aprovadas e seus motivos; a arquitetura referencia os ADRs vigentes.
- `docs/decisions/decisoes-arquiteturais-ambiente-agentico.md`: prioridade do projeto e operação do workflow agêntico. Referências a escopo financeiro são direção do projeto de referência e não substituem os requisitos canônicos do PRD.
- `docs/planning/backlog-adaptacao.md`: ordem, status e evidências de execução; não aprova requisitos nem decisões.
- `README.md`: estado implementado e comandos vigentes, sem transformar direção futura em funcionalidade existente.

## Divergências encontradas

| Tema | Registro atual | Divergência/impacto |
|---|---|---|
| Banco | Divergência resolvida em `ADR-001-banco-postgresql.md`: PostgreSQL escolhido para a persistência durável inicial | A responsável aceita configurar e manter o serviço. O legado ainda usa somente EF Core InMemory; a implementação permanece fora desta decisão documental. |
| Hospedagem e segurança | Decisão agêntica §6.2 define como cenário-alvo computador doméstico, um proprietário e acesso pela rede doméstica, sem nuvem/exposição à internet; arquitetura §10 adia procedimentos de deployment e detalhes operacionais | As fontes são compatíveis se a decisão agêntica for referência para o cenário-alvo e a arquitetura para detalhar a operação. Autenticação/autorização, firewall, backups e restauração continuam em B5.1/B2.6. |
| Migrations | Resolvido em `ADR-002-ef-core-migrations.md`: EF Core Migrations versionadas no Git; SQL explícito permitido para consultas/operações específicas | A ferramenta está decidida, mas ainda não há migrations no código; revisão e validação continuam pendentes em B2.5. |
| Escopo financeiro | PRD §5.1 contém o MVP completo. A decisão agêntica registrava um subconjunto e chamava algumas áreas de “fora do MVP”. | Resolvido: o MVP completo do PRD permanece como objetivo do produto; o subconjunto de despesas/importação/consulta/edição/SQL read-only é o primeiro incremento. Os demais requisitos do MVP serão entregues depois, sem serem removidos. |
| Importação | PRD §2 registra Google Sheets como fonte atual e FR-01 descreve CSVs bancários; a decisão agêntica mencionava uma planilha Excel | Resolvido: a planilha financeira existente é a fonte histórica; os CSVs bancários são um fluxo separado. Formato de exportação e abas serão especificados em B4.2. |
| Framework | Todos os projetos atuais e a arquitetura apontam .NET 10; algumas instruções operacionais ainda citam .NET 8 | Não é conflito entre as três fontes arquiteturais, mas instruções desatualizadas precisam ser corrigidas separadamente, sem caracterizar isso como migração de framework. |

## Alternativas técnicas para o banco

### SQLite — alternativa considerada

Alinha-se ao cenário doméstico de uma única aplicação e reduz serviços para instalar e manter. Simplifica cópia e restauração do arquivo local. Requer que a aplicação hospede o arquivo e que nenhum cliente acesse o arquivo diretamente pela rede. A compatibilidade de migrations, constraints e consultas específicas deve ser verificada; consultas SQL read-only dependeriam de abertura do arquivo em modo somente leitura, permissões do sistema operacional e limites de execução/resultados.

### PostgreSQL — decisão aprovada

Selecionado pela responsável e registrado em `ADR-001-banco-postgresql.md`. Isso implica configurar e manter o serviço, usuário, credenciais e backup/restauração. EF Core/Npgsql e testes de integração contra PostgreSQL são a direção descrita na arquitetura, ainda a implementar.

## Decisões e tratamento das divergências

1. **Fontes canônicas:** PRD para requisitos/regras/escopo de produto; arquitetura para direção técnica; ADRs para decisões duradouras; decisão agêntica para prioridade do projeto e workflow; backlog para sequência/status; README para estado implementado. A lista está em `docs/architecture/architecture.md`, seção 7.1.
2. **Banco:** PostgreSQL, aprovado em ADR-001.
3. **Migrations:** EF Core Migrations versionadas no Git, SQL explícito permitido em consultas/operações específicas, aprovado em ADR-002.
4. **Hospedagem:** mantém-se o cenário-alvo doméstico existente; a arquitetura esclarece que detalhes de deployment e operação (segurança, firewall, backups/restauração) ficam para B2.6/B5.1.
5. **MVP e primeiro incremento:** o MVP completo da seção 5.1 do PRD permanece o objetivo. O primeiro incremento inclui fundação técnica, despesas, importação da planilha histórica, consulta/edição básica e SQL read-only. Os outros requisitos do MVP seguem em incrementos posteriores. A decisão está registrada no PRD §5.1 e na decisão agêntica §3.2.
6. **Importação:** a planilha financeira existente é a fonte histórica; CSV bancário permanece fluxo separado. O contrato concreto fica para B4.2.

## Pendências de implementação posteriores

- B4.1: critérios de aceite e sequência do primeiro incremento.
- B4.2: formato/exportação, abas, cabeçalhos e tratamento de inconsistências da planilha.
- B2.4–B2.6 e B5.1: provider PostgreSQL na API, inicialização/configuração e segurança operacional/backup.
- B2.5: geração, revisão e validação de migrations reais.

Essas pendências não reabrem B0.1: são itens de implementação e especificação com escopo próprio.
