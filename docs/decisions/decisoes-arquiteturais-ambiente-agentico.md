# Decisões arquiteturais — Ambiente Agêntico de Engenharia de Software

**Versão:** 1.1  
**Status:** Direção arquitetural definida; detalhes operacionais serão validados incrementalmente  
**Data:** 03/11/2026

## 1. Direção do projeto

O objetivo principal deste projeto **não é construir um aplicativo financeiro sofisticado**. O aplicativo financeiro familiar será o projeto de referência usado para desenvolver, testar e evoluir um **ambiente agêntico de engenharia de software**.

O foco é aprender e construir um fluxo no qual agentes de IA consigam executar etapas de desenvolvimento com autonomia crescente, mantendo qualidade, rastreabilidade e segurança.

Objetivo de longo prazo:

> Receber uma melhoria ou problema, compreender o contexto do repositório, propor uma solução, implementar, testar, revisar e entregar a alteração com o mínimo de supervisão humana necessário.

O sistema financeiro é o domínio real que dará contexto e critérios concretos para avaliar esse ambiente. Não devemos deixar que funcionalidades do aplicativo desviem o esforço do objetivo principal.

## 2. Princípios orientadores

1. **Aprender construindo:** cada capacidade do ambiente deve ser implementada e compreendida, não apenas configurada por copiar instruções.
2. **Autonomia gradual:** começar com tarefas pequenas e supervisão explícita; aumentar autonomia com evidências de confiabilidade.
3. **Simplicidade:** escolher a menor solução que resolva o problema atual. Não antecipar infraestrutura ou abstrações sem necessidade.
4. **Rastreabilidade:** decisões, tarefas, alterações, testes e resultados devem deixar evidências consultáveis.
5. **Qualidade verificável:** agentes não devem declarar uma tarefa concluída sem executar as verificações pertinentes e apresentar seus resultados.
6. **Separação de responsabilidades:** contexto, planejamento, implementação, validação e aprovação são etapas distintas, mesmo que inicialmente sejam executadas pelo mesmo agente.
7. **Portabilidade:** priorizar práticas, contratos e ferramentas que possam ser reaproveitados em outros repositórios e empresas.
8. **Segurança por padrão:** agentes recebem apenas permissões necessárias; operações destrutivas ou externas exigem controles explícitos.
9. **Humano no controle:** autonomia não significa ausência de limites. Aprovações humanas serão mantidas nos pontos de risco.

## 3. Escopo e prioridades

### 3.1 Prioridade principal: ambiente agêntico

O trabalho deve priorizar capacidades reutilizáveis de engenharia assistida por agentes:

- Entender instruções e contexto do repositório.
- Consultar documentação e decisões arquiteturais.
- Transformar solicitações em tarefas pequenas e verificáveis.
- Planejar alterações antes de editar código.
- Implementar mudanças dentro do escopo autorizado.
- Executar build, testes, lint e outras verificações disponíveis.
- Analisar falhas e corrigir problemas.
- Revisar diffs e identificar riscos.
- Produzir resumo da alteração e evidências de validação.
- Solicitar aprovação quando a ação ultrapassar os limites definidos.
- Registrar aprendizados e atualizar documentação quando necessário.

### 3.2 Projeto de referência: sistema financeiro familiar

O sistema financeiro será mantido deliberadamente simples. Seu papel é fornecer um domínio real para exercitar o ambiente agêntico.

O MVP completo permanece o definido em `docs/product/PRD.md`. O primeiro incremento aprovado, que não substitui nem reduz esse MVP, inclui:

- Fundação técnica reproduzível.
- Cadastro, consulta e edição básica de despesas.
- Importar o histórico de despesas da planilha financeira existente; definir o formato de exportação e as abas suportadas em B4.2.
- Consultar lançamentos por período, grupo, categoria e descrição.
- Disponibilizar consultas SQL somente leitura.
- Preservar a origem dos dados importados.

Receitas, cartões/faturas, parcelamentos, recorrências, projeções, pagamentos completos, visualizações e importação recorrente de CSV bancário continuam no MVP descrito pelo PRD e serão entregues em incrementos posteriores. Os CSVs bancários são um fluxo separado da importação histórica da planilha.

Decisões de domínio já tomadas:

- Grupos iniciais: Natalia, Bernardo e Casa.
- Cada lançamento pertence a exatamente um grupo.
- Não haverá rateio entre grupos no MVP.
- Categorias existentes serão preservadas; uma categoria por lançamento, opcional.
- Investimentos ficam fora do MVP e permanecem separados.
- Cada ocorrência mensal será preservada como lançamento da competência correspondente.
- Parcelas de uma mesma compra poderão ser relacionadas quando houver evidência suficiente; não agrupar apenas por descrição.
- Valores como `Fixo` e `AFixo` serão preservados como referências de origem, sem mecanismo automático de recorrência.
- O status `Pago` não será central no domínio, mas seu valor bruto relevante será preservado na importação.
- Dívidas, empréstimos, transferências, contas bancárias e pagadores não fazem parte do escopo atual do MVP do PRD e requerem Discovery antes de eventual inclusão.

O aplicativo não deve receber funcionalidades apenas porque são interessantes para um sistema financeiro. Cada incremento deve também servir como oportunidade de exercitar uma capacidade do ambiente agêntico.

Esta seção registra a prioridade do projeto e decisões de domínio discutidas. Para requisitos, fronteira do MVP e critérios de aceite do produto, `docs/product/PRD.md` é a fonte canônica; divergências de escopo entre este documento e o PRD devem ser reconciliadas no PRD, com a decisão duradoura registrada em ADR quando aplicável.

## 4. Arquitetura do ambiente agêntico

### 4.1 Modelo de execução

Começar com um fluxo simples, orquestrado por um agente principal, que utiliza ferramentas para inspecionar o repositório, editar arquivos, executar comandos e validar resultados.

Não começar com uma equipe de múltiplos agentes especializados, filas distribuídas ou uma plataforma própria de orquestração. Essas opções só serão consideradas quando um gargalo concreto justificar a complexidade.

### 4.2 Fluxo-alvo

```text
Solicitação / issue
       |
       v
Entender contexto e instruções
       |
       v
Analisar e planejar a mudança
       |
       v
Definir critérios de aceitação
       |
       v
Implementar em escopo controlado
       |
       v
Executar build e testes
       |
       v
Revisar diff e riscos
       |
       v
Evidências e relatório
       |
       v
Aprovação humana quando necessária
       |
       v
Entrega / integração
```

O fluxo deve permitir interromper, retomar e inspecionar o trabalho. O agente não deve esconder decisões relevantes em uma sequência opaca de ações.

### 4.3 Autonomia por níveis

A autonomia será ampliada gradualmente:

| Nível | Comportamento |
|---|---|
| 0 — Assistido | Agente explica e propõe; humano executa |
| 1 — Execução supervisionada | Agente implementa e testa; humano revisa cada alteração |
| 2 — Entrega supervisionada | Agente conclui tarefas delimitadas e prepara a entrega; humano aprova integração |
| 3 — Autonomia limitada | Agente pode integrar mudanças de baixo risco que atendam a critérios objetivos |
| 4 — Fluxo autônomo controlado | Agente conduz o ciclo completo dentro de políticas, limites e monitoramento |

O objetivo não é atingir o nível máximo rapidamente. Cada avanço depende de resultados observáveis, testes e capacidade de recuperação.

## 5. Contratos e contexto do repositório

O repositório deve conter instruções e documentação duradouras que qualquer agente consiga consultar.

Estrutura inicial recomendada:

```text
/
├── AGENTS.md
├── README.md
├── docs/
│   ├── product/
│   ├── architecture/
│   ├── decisions/
│   └── agent-workflow/
├── src/
└── tests/
```

Responsabilidades:

- `AGENTS.md`: instruções operacionais para agentes, comandos, limites e convenções.
- `README.md`: propósito do projeto e instruções para pessoas.
- `docs/product/`: escopo e requisitos do sistema financeiro.
- `docs/architecture/`: arquitetura e modelo de domínio.
- `docs/decisions/`: decisões arquiteturais e seus motivos.
- `docs/agent-workflow/`: fluxo de trabalho, critérios de qualidade, políticas e evolução do ambiente.

Evitar duplicar instruções em vários arquivos. Cada informação deve ter uma fonte principal e ser referenciada quando necessário.

## 6. Ferramentas e tecnologias

### 6.1 Projeto de referência

As decisões atuais para o aplicativo são:

- Linguagem: C#.
- Plataforma: .NET 10.
- Aplicação: ASP.NET Core.
- Banco inicial: PostgreSQL.
- Acesso a dados: Entity Framework Core.
- Migrações: EF Core Migrations versionadas no Git.
- Testes: xUnit, com testes unitários e de integração.

PostgreSQL foi escolhido para a persistência durável inicial. A pessoa responsável aceita configurar e manter o serviço de banco. O acesso dos clientes aos dados financeiros deverá ocorrer pela aplicação, não por acesso direto ao banco. A estratégia operacional detalhada e a hospedagem serão especificadas antes da implantação.

### 6.2 Hospedagem do aplicativo

- Execução em um computador da rede doméstica.
- Acesso pelo navegador a partir de outros dispositivos da rede.
- Somente o proprietário utilizará a aplicação.
- Sem hospedagem em nuvem no MVP.
- Sem exposição de portas à internet.
- Firewall limitado à rede doméstica.
- Rotina de backup e restauração do PostgreSQL a definir antes da implantação.

A máquina hospedeira precisa estar ligada e com a aplicação em execução para permitir o acesso.

### 6.3 Ferramentas do ambiente agêntico

Não há decisão fechada sobre fornecedor de modelo, framework de agentes ou plataforma de orquestração. A escolha deve ser feita com base nas capacidades necessárias e na experiência prática, evitando dependência prematura de uma ferramenta específica.

Critérios para avaliar ferramentas:

- Acesso controlado ao repositório e terminal.
- Capacidade de ler e atualizar arquivos.
- Execução de comandos e testes.
- Uso de contexto e instruções persistentes.
- Registro de ações e resultados.
- Integração com Git e, quando necessário, gestão de tarefas.
- Permissões configuráveis e possibilidade de aprovação humana.
- Portabilidade de práticas e artefatos.

## 7. Segurança e limites operacionais

O agente deve operar com o menor conjunto de permissões necessário.

Políticas iniciais:

- Não publicar segredos, tokens ou dados financeiros em logs.
- Não executar comandos destrutivos sem autorização explícita.
- Não alterar configurações de infraestrutura ou segurança fora do escopo da tarefa.
- Não fazer deploy, publicar pacotes ou enviar dados para serviços externos sem autorização.
- Não realizar merge ou integração definitiva sem aprovação humana no estágio inicial.
- Não declarar sucesso sem apresentar os comandos executados e seus resultados.
- Não contornar testes que falharam apenas para concluir a tarefa.
- Inspecionar o diff antes de considerar uma mudança pronta.

As políticas devem ser aplicadas por permissões e mecanismos técnicos sempre que possível, não apenas por instruções em linguagem natural.

## 8. Qualidade, testes e avaliação dos agentes

A qualidade do ambiente será medida pelo resultado do trabalho dos agentes, e não pela quantidade de agentes ou prompts.

Toda tarefa de implementação deve, quando aplicável:

1. Ter objetivo e critérios de aceitação claros.
2. Identificar os arquivos e componentes afetados.
3. Ter um plano proporcional ao tamanho do problema.
4. Executar build e testes pertinentes.
5. Revisar o diff.
6. Informar verificações executadas, resultados e limitações.
7. Atualizar documentação quando uma decisão ou contrato mudar.

Indicadores iniciais úteis:

- Percentual de tarefas concluídas sem intervenção corretiva.
- Percentual de alterações que passam nos testes.
- Quantidade de regressões introduzidas.
- Frequência de alterações fora do escopo.
- Tempo de execução por tarefa.
- Quantidade de aprovações ou intervenções humanas necessárias.

No início, os indicadores serão observados qualitativamente. Não criar um sistema de métricas sofisticado antes de existir volume de tarefas.

## 9. Consultas SQL da aplicação financeira

A interface SQL do aplicativo de referência será somente leitura no MVP:

- Conexão configurada como read-only.
- Consultas de leitura apenas.
- Limite inicial de 1.000 linhas.
- Timeout inicial de 5 segundos.
- Edições feitas pelos fluxos normais da aplicação.

Esses limites são valores iniciais e poderão ser ajustados com base no uso real.

## 10. Importação de dados do Excel

A primeira fonte de dados será o arquivo Excel já utilizado.

Regras:

- Importar despesas das tabelas de Casa, Natalia, Bernardo e Cartão de Crédito.
- Não importar investimentos.
- Não importar a aba de projeção como fonte independente de lançamentos.
- Não importar rascunhos ou tabelas auxiliares como movimentações.
- Preservar competência, grupo, descrição, categoria, valor, referência de parcela e observação.
- Preservar dados brutos relevantes, inclusive `Pago`.
- Identificar tabelas pela estrutura/cabeçalhos, não apenas por posições fixas.
- Tratar fórmulas sem inventar valores quando o valor calculado não estiver disponível.
- Garantir que reimportar o mesmo arquivo não duplique registros.
- Não sobrescrever silenciosamente alterações feitas na aplicação.

O vínculo entre parcelas será criado apenas quando houver evidência confiável. A estratégia de chave de idempotência será validada durante a implementação do importador.

## 11. Fora do escopo atual

Não implementar antecipadamente:

- Arquitetura multiagente complexa.
- Framework próprio de agentes.
- Microsserviços ou infraestrutura distribuída.
- Kubernetes ou cloud para o aplicativo.
- Multi-tenancy.
- Integrações bancárias.
- Gestão completa de cartões e faturas.
- Recorrências automáticas.
- Regras completas de receitas, dívidas, empréstimos e transferências.
- Dashboards sofisticados.
- Sistema complexo de permissões.
- Deploy autônomo sem histórico de confiabilidade.

## 12. Sequência recomendada de evolução

A ordem de trabalho deve priorizar o aprendizado e a construção do ambiente agêntico.

### Etapa 1 — Base reproduzível

- Criar ou organizar o repositório.
- Registrar objetivo, instruções e decisões.
- Definir comandos reproduzíveis de build e testes.
- Criar uma tarefa pequena que possa ser executada e validada.

### Etapa 2 — Agente com execução supervisionada

- Inspecionar contexto do repositório.
- Planejar mudanças.
- Editar código.
- Executar build e testes.
- Apresentar diff e relatório.
- Exigir revisão humana.

### Etapa 3 — Ciclo de desenvolvimento rastreável

- Padronizar entrada de tarefas.
- Definir critérios de aceitação.
- Registrar plano, execução e resultados.
- Melhorar tratamento de falhas e retomada.

### Etapa 4 — Avaliação e autonomia limitada

- Criar tarefas de referência para avaliar o agente.
- Medir sucesso, regressões e intervenções.
- Permitir autonomia apenas em tarefas de baixo risco com critérios objetivos.
- Manter aprovação humana para integração e operações sensíveis.

### Etapa 5 — Aplicação de referência

Implementar o MVP financeiro usando o próprio ambiente agêntico, começando pelo modelo de dados e importação da planilha. O aplicativo será uma validação prática do fluxo, não o objetivo principal do projeto.

## 13. Decisões ainda abertas

As decisões abaixo não bloqueiam a construção da primeira versão do ambiente:

1. Fornecedor/modelo de IA e estratégia de seleção de modelos.
2. Ferramenta específica de execução do agente e orquestração.
3. Integração com ferramenta de gestão de tarefas.
4. Estratégia de branches e criação automática de pull requests.
5. Quais classes de tarefas poderão ser integradas sem aprovação humana.
6. Política definitiva de retenção de logs e artefatos de execução.

Essas escolhas devem ser tomadas quando houver um caso prático que permita comparar alternativas. Não devemos escolher ferramentas apenas para preencher uma arquitetura no papel.

## 14. Critério de sucesso do projeto

O sucesso não será medido pelo número de funcionalidades do aplicativo financeiro.

O critério principal será:

> Dada uma tarefa de engenharia delimitada, o ambiente consegue compreender o contexto, planejar, implementar, testar, revisar e apresentar uma entrega rastreável, respeitando limites de segurança e exigindo intervenção humana apenas nos pontos definidos.

O aplicativo financeiro será o primeiro domínio usado para demonstrar essa capacidade. O conhecimento, os contratos e o fluxo de trabalho deverão ser transferíveis para outros projetos e empresas.
