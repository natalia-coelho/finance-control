# Backlog de adaptação às novas especificações

**Status:** proposta inicial baseada no repositório e na documentação disponíveis em 03/11/2026.  
**Objetivo:** preparar o projeto legado para evoluir segundo as especificações e estabelecer o workflow agêntico antes de ampliar o produto financeiro.

Este backlog registra lacunas observáveis, não decisões já aprovadas. Itens de produto e arquitetura ainda indefinidos devem ser esclarecidos antes de mudanças irreversíveis.

## Prioridade e dependências

### B0 — Contexto e decisões

- [ ] **B0.1 — Revisar divergências entre as especificações e estabelecer fontes canônicas.** Resolver a diferença entre a decisão agêntica (SQLite e hospedagem doméstica) e a arquitetura recente (PostgreSQL), confirmar a estratégia de migrations e reconciliar diferenças de escopo entre PRD e decisão arquitetural. Registrar decisões em documentos/ADRs; não codificar suposições.
- [ ] **B0.2 — Inventariar o legado e atualizar o README.** Documentar o que existe de fato: solução e projetos, versão .NET, persistência InMemory, endpoints e testes disponíveis. Remover afirmações que não correspondam ao código, como banco relacional ou recursos de produção ainda não implementados.
- [ ] **B0.3 — Definir convenções mínimas de contribuição.** Registrar requisitos para branch/commits se aplicável, revisão de diff, tratamento de configuração, documentação e evidências de conclusão, alinhados ao `AGENTS.md`.

### B1 — Fundação do workflow agêntico

- [ ] **B1.1 — Definir contrato de entrada para tarefas.** Criar um modelo curto para solicitação, contexto, critérios de aceitação, restrições, risco e definição de pronto.
- [ ] **B1.2 — Definir fluxo operacional supervisionado.** Documentar etapas de entendimento, plano, implementação, verificações, revisão e entrega, incluindo pontos de aprovação humana e limites de ações externas/destrutivas.
- [ ] **B1.3 — Definir evidências e relatório de execução.** Padronizar registro de arquivos alterados, comandos executados, resultados, falhas, limitações e decisões pendentes; não introduzir plataforma de métricas antes de haver volume de uso.
- [ ] **B1.4 — Criar tarefas de referência para exercitar o fluxo.** Selecionar uma tarefa documental e uma pequena tarefa técnica sem impacto financeiro; avaliar se um agente consegue concluí-las com escopo controlado e validação reproduzível.
- [ ] **B1.5 — Revisar AGENTS.md após as primeiras execuções.** Ajustar instruções com base em dificuldades reais; manter requisito e arquitetura nas respectivas fontes documentais.

### B2 — Base técnica reproduzível

- [ ] **B2.1 — Verificar ambiente e comandos de build/teste.** Confirmar SDK disponível, compilar a solução e executar os testes existentes; registrar falhas preexistentes e comandos confiáveis.
- [ ] **B2.2 — Decidir e executar a estratégia de atualização do framework.** Comparar estado atual (.NET 8) com alvo arquitetural (.NET 10), validar disponibilidade do SDK e compatibilidade dos pacotes, então atualizar de forma isolada e reproduzível.
- [ ] **B2.3 — Fixar versões e centralizar configuração de dependências.** Depois da decisão de framework, alinhar versões de EF Core, provider do banco, MediatR e demais pacotes; evitar atualização incidental de dependências sem compatibilidade verificada.
- [ ] **B2.4 — Tornar a persistência configurável por ambiente.** Substituir banco InMemory usado pela API por persistência durável conforme decisão B0.1; manter configurações locais seguras e não versionar credenciais.
- [ ] **B2.5 — Versionar e validar migrations.** Escolher abordagem, gerar migrations revisáveis e demonstrar criação/reconstrução do schema num ambiente local reproduzível.
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

- [ ] **B4.1 — Delimitar o primeiro incremento e seus critérios de aceite.** Priorizar a fundação e importação histórica conforme decisões consolidadas, mantendo o escopo pequeno e verificável.
- [ ] **B4.2 — Especificar contrato da planilha de origem.** Identificar tabelas/cabeçalhos suportados, dados brutos preservados, fórmulas sem valor calculado, tabelas excluídas e tratamento de inconsistências.
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
