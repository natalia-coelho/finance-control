# Backlog de adaptação às novas especificações

**Status:** acompanhamento atualizado em 05/11/2026, com base no repositório e na documentação disponíveis.
**Objetivo:** preparar o projeto legado para evoluir segundo as especificações e estabelecer o workflow agêntico antes de ampliar o produto financeiro.

**Legenda:** `[x]` concluído com evidência no repositório; `[ ]` pendente, parcial ou bloqueado por decisão/evidência. A conclusão de um item não aprova automaticamente itens dependentes.

Este backlog registra lacunas observáveis, não decisões já aprovadas. Itens de produto e arquitetura ainda indefinidos devem ser esclarecidos antes de mudanças irreversíveis.

## Prioridade e dependências

### B0 — Contexto e decisões

- [x] **B0.1 — Revisar divergências entre as especificações e estabelecer fontes canônicas.** Fontes canônicas explicitadas; PostgreSQL e EF Core Migrations registrados em ADR-001/002; MVP completo preservado conforme PRD e primeiro incremento delimitado; planilha existente definida como origem histórica, com CSV bancário separado. Evidências em `docs/product/PRD.md` §5.1, `docs/architecture/architecture.md` §7.1/§8 e `docs/decisions/reconciliacao-especificacoes.md`.
- [x] **B0.2 — Inventariar o legado e atualizar o README.** Evidência: `README.md` descreve a solução/projetos, alvo .NET 10, endpoints GET/POST, provider InMemory, testes existentes e ausência de persistência relacional, migrations, importador e SQL. Confirmado nos `.csproj`, `Program.cs`, controller e testes em 05/11/2026.
- [ ] **B0.3 — Definir convenções mínimas de contribuição.** Parcial: `AGENTS.md` e regras em `.cursor/rules/` cobrem revisão de diff, configuração segura, documentação e evidências; convenções de branch/commits ainda não estão definidas (e podem ser dispensáveis para o fluxo atual).

### B1 — Fundação do workflow agêntico

- [x] **B1.1 — Definir contrato de entrada para tarefas.** Evidência: seção “Modelo de solicitação ao agente” em `docs/agent-workflow/fluxo-implementacao-backlog.md` inclui objetivo, critérios de aceite, restrições/decisões e saída esperada. Risco não é campo explícito no modelo e permanece ponto de melhoria.
- [x] **B1.2 — Definir fluxo operacional supervisionado.** Evidência: `docs/agent-workflow/fluxo-implementacao-backlog.md` documenta seleção, entendimento, aprovação, implementação, validação, revisão, dependências e limites; alinhado a `AGENTS.md` e à decisão agêntica.
- [x] **B1.3 — Definir evidências e relatório de execução.** Evidência: o fluxo exige registrar arquivos/documentos, comandos e resultados, falhas, limitações e decisões pendentes; sem plataforma de métricas.
- [ ] **B1.4 — Criar tarefas de referência para exercitar o fluxo.** Selecionar uma tarefa documental e uma pequena tarefa técnica sem impacto financeiro; avaliar se um agente consegue concluí-las com escopo controlado e validação reproduzível.
- [ ] **B1.5 — Revisar AGENTS.md após as primeiras execuções.** Aguardando evidências de execuções de referência; instruções operacionais já existem em `AGENTS.md` e nas regras do Cursor, mas ainda não há revisão baseada em resultados de B1.4.

### B2 — Base técnica reproduzível

- [ ] **B2.1 — Verificar ambiente e comandos de build/teste.** Confirmar SDK disponível, compilar a solução e executar os testes existentes; registrar falhas preexistentes e comandos confiáveis.
- [ ] **B2.2 — Confirmar e reproduzir a base de framework.** Os projetos atuais já têm alvo .NET 10, igual à arquitetura; corrigir instruções desatualizadas que dizem .NET 8 e verificar SDK/build/testes em B2.1. Qualquer atualização futura de framework deve ser uma tarefa isolada, com compatibilidade validada.
- [ ] **B2.3 — Fixar versões e centralizar configuração de dependências.** Depois da decisão de framework, alinhar versões de EF Core, provider do banco, MediatR e demais pacotes; evitar atualização incidental de dependências sem compatibilidade verificada.
- [ ] **B2.4 — Tornar a persistência configurável por ambiente.** Substituir banco InMemory usado pela API por persistência durável conforme decisão B0.1; manter configurações locais seguras e não versionar credenciais.
- [ ] **B2.5 — Versionar e validar migrations.** A abordagem foi definida em ADR-002; gerar migrations revisáveis e demonstrar criação/reconstrução do schema num ambiente local reproduzível.
- [ ] **B2.6 — Definir fluxo local para banco e backup.** Documentar inicialização, configuração, backup e restauração do banco escolhido sem adicionar infraestrutura além do necessário.
- [ ] **B2.7 — Corrigir a política CORS permissiva.** Restringir origens ao contexto de desenvolvimento/operação definido e documentar configuração; não manter `AllowAnyOrigin` como padrão para uma aplicação com dados financeiros.

### B3 — Modelo e qualidade do domínio

- [ ] **B3.1 — Consolidar glossário e regras de negócio.** Extrair termos e invariantes do PRD; marcar explicitamente questões abertas de receitas, categorias, datas, pagamentos, parcelas e recorrências.
- [ ] **B3.2 — Criar modelo conceitual antes do schema físico.** Representar relações e cenários para compra, movimentação, parcela, fatura, pagamento, estorno/reembolso, recorrência e projeção; validar ausência de dupla contabilização.
- [ ] **B3.3 — Separar cadastros e dimensões do lançamento.** Modelar pessoas, grupos e categorias como dados cadastráveis; manter grupo, pagador, conta/cartão, categoria e natureza financeira como conceitos distintos.
- [ ] **B3.4 — Definir representação de valor e datas.** Especificar precisão, escala, moeda/arredondamento e distinção entre data da compra, competência e pagamento antes do modelo relacional.
- [ ] **B3.5 — Definir política de correção e histórico.** Determinar como editar, cancelar, estornar e excluir logicamente sem apagar rastreabilidade financeira.
- [ ] **B3.6 — Substituir o modelo `Transaction` legado por conceitos validados.** Fazer após B3.1–B3.5; evitar migração direta dos campos atuais (`Amount`, `Category`, `Date`, `Description`) sem mapeamento aprovado.
- [ ] **B3.7 — Construir cobertura de testes por risco.** Acrescentar testes de domínio e integração com PostgreSQL para constraints e transações; cobrir cenários financeiros críticos definidos na arquitetura.

### B4 — Primeiro incremento do produto

- [ ] **B4.1 — Definir critérios de aceite do primeiro incremento.** O recorte funcional foi aprovado em B0.1 e está registrado no PRD §5.1; definir critérios de aceite e sequência de implementação.
- [ ] **B4.2 — Especificar contrato da planilha de origem.** A fonte histórica está definida como a planilha financeira existente. Identificar arquivo/exportação, abas/cabeçalhos suportados, dados brutos preservados, fórmulas sem valor calculado, tabelas excluídas e tratamento de inconsistências.
- [ ] **B4.3 — Definir idempotência e resolução de conflitos de importação.** Escolher chave/estratégia após inspecionar dados reais; garantir reimportação sem duplicação e sem sobrescrever silenciosamente edições da aplicação.
- [ ] **B4.4 — Implementar importação com rastreabilidade.** Importar somente as fontes aprovadas, preservar origem e valores brutos relevantes, oferecer relatório de validação e tornar reexecução segura.
- [ ] **B4.5 — Validar dados importados.** Comparar contagens e valores por competência/grupo com a fonte, revisar amostras e documentar exceções antes de tratar a migração como concluída.

### B5 — Operação e capacidades posteriores

- [ ] **B5.1 — Definir segurança e operação doméstica.** Confirmar rede de acesso, autenticação/autorização, firewall, usuário de banco com privilégio mínimo, backups e tratamento de logs.
- [ ] **B5.2 — Preparar consultas SQL somente leitura.** Definir credencial separada, restrições de leitura, limite de linhas e timeout; só implementar após persistência e modelo estabilizados.
- [ ] **B5.3 — Refinar automação e avaliar autonomia do agente.** Usar resultados das tarefas de referência para medir falhas, intervenções e desvios de escopo; só ampliar autonomia com critérios objetivos e aprovação humana para integração.
- [ ] **B5.4 — Reavaliar backlog conforme decisões e evidências.** Atualizar prioridades e critérios com resultados de cada incremento; não implementar itens futuros apenas por constarem nesta lista.

## Dependências principais

```text
B0.1 ──> B2.2–B2.6 ──> B3.2–B3.7 ──> B4.1–B4.5
  └────> B5.1–B5.2
B1.1–B1.4 podem avançar em paralelo com B0/B2 e orientam a execução dos demais itens.
```

## Fora do backlog imediato

- Construir um orquestrador próprio, arquitetura multiagente ou infraestrutura distribuída.
- Implementar dashboards, automações financeiras ou classificação por IA antes de consolidar dados e regras.
- Habilitar deploy, publicação ou integração autônoma sem histórico de confiabilidade e política aprovada.
- Resolver por implementação questões que o PRD e a arquitetura mantêm explicitamente abertas.

## Evidências e divergências verificadas em 05/11/2026

- Estado do Git no início da atualização: havia alterações preexistentes em `.cursor/rules/registro-de-decisoes.mdc`, `.cursor/rules/aprendizado-evolutivo.mdc`, `.cursor/agents/` e `docs/agent-workflow/`; foram preservadas.
- A solução e todos os projetos (`src/` e `tests/`) têm `TargetFramework` `net10.0`; os pacotes EF Core/InMemory estão em `10.0.14`. Isso contradiz o texto do agente `.cursor/agents/desenvolvedor-finance-control.md` e regras existentes que descrevem o legado como .NET 8.
- PostgreSQL foi confirmado pela responsável em 05/11/2026 e registrado no ADR-001; SQLite permanece documentado como alternativa considerada. A API ainda usa EF Core InMemory.
- A API usa EF Core InMemory e ainda define CORS com `AllowAnyOrigin`; não há projetos/arquivos de migrations, importador histórico ou consultas SQL read-only implementados.
- Não foi executado build/teste nesta atualização documental; a atualização de status não dependeu de validação de compilação.
- O cenário-alvo de hospedagem doméstica foi mantido; a arquitetura esclarece que apenas os procedimentos de deployment e detalhes operacionais estavam adiados.
- A responsável definiu a planilha financeira existente como origem da importação histórica e separou CSV bancário como fluxo distinto; formato de exportação e abas ficam para B4.2.
- O primeiro incremento foi aprovado em 05/11/2026: fundação, despesas, importação da planilha histórica, consulta/edição e SQL read-only; os demais requisitos do MVP permanecem em incrementos posteriores.
- B0.1 foi concluído em `docs/decisions/reconciliacao-especificacoes.md`; B4.1 ainda precisa definir critérios de aceite e B4.2 o contrato exato da planilha.
- Foi criado `compose.yaml` para PostgreSQL 18.6, com volume nomeado e porta publicada somente em loopback. `docker compose config --quiet`, YAML e regra de exclusão de `.env` foram verificados. O container não iniciou: o CLI/Compose existem, mas o acesso ao daemon é negado pelo socket do Docker neste ambiente, inclusive na tentativa elevada.
