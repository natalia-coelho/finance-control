# Instruções para agentes

## Objetivo e prioridade

Este repositório serve прежде de tudo para construir e avaliar um workflow agêntico de engenharia de software. O sistema financeiro é o domínio de referência. Priorize capacidades reutilizáveis de manutenção — compreensão do contexto, planejamento, execução controlada, validação, revisão e rastreabilidade — antes de ampliar funcionalidades do produto.

Trabalhe inicialmente em execução supervisionada: apresente um plano proporcional à tarefa, implemente apenas o escopo autorizado e deixe a revisão/integração final com a pessoa responsável. Não introduza orquestração multiagente ou infraestrutura adicional sem uma necessidade concreta.

## Fontes de contexto

Antes de propor mudanças, consulte os documentos pertinentes:

- `docs/decisions/decisoes-arquiteturais-ambiente-agentico.md`: prioridade do ambiente, níveis de autonomia, limites operacionais e evolução do workflow.
- `docs/product/PRD.md`: necessidades, escopo funcional, regras e questões de produto em aberto.
- `docs/architecture/architecture.md`: direção técnica e conceitos arquiteturais do sistema financeiro.
- `README.md` e a solução/projetos existentes: estado real do legado e comandos disponíveis.

Os documentos descrevem direção e propostas; não provam que algo já esteja implementado. Ao encontrar divergências entre documentação e código, reporte-as e evite escolher silenciosamente uma interpretação que afete arquitetura, dados ou segurança. Registre decisões relevantes na documentação correspondente. Evite duplicar regras neste arquivo: mantenha aqui instruções operacionais e referencie a fonte de produto/arquitetura.

## Procedimento de trabalho

Para cada tarefa de engenharia:

1. Entenda o pedido, os critérios de aceitação e as instruções aplicáveis.
2. Inspecione o código e a documentação relevantes; confirme o estado do Git antes de editar e preserve alterações preexistentes.
3. Identifique incertezas, riscos, arquivos afetados e verificações disponíveis. Se uma decisão de produto ou arquitetura for necessária e não estiver documentada, explicite-a antes de codificar a suposição.
4. Faça um plano curto para mudanças não triviais. Mantenha o diff focado e evite refatorações ou dependências sem relação direta com o pedido.
5. Execute as verificações pertinentes ao escopo e revise o diff final.
6. Na entrega, resuma o que mudou, os comandos de validação executados e resultados, além de limitações ou decisões pendentes.

Se uma verificação falhar, investigue e relate a falha. Não esconda, contorne ou declare sucesso sem evidência. Se não houver comando confiável ou o ambiente impedir sua execução, informe isso claramente.

## Estado legado e compatibilidade

O repositório contém atualmente uma solução `FinanceControl.sln`, projetos em `src/` e testes em `tests/`, todos direcionados a .NET 10. O código ainda usa Entity Framework Core InMemory; as especificações descrevem uma direção de evolução para persistência relacional, mas essa mudança permanece fora do escopo de uma migração de framework.

Antes de atualizar framework, dependências, banco, estrutura de projetos ou estratégia de migrations:

- confirme o estado efetivo dos arquivos de projeto, SDKs e dependências;
- consulte as decisões documentadas e identifique contradições;
- proponha a mudança como tarefa delimitada, com impacto e validações claros;
- não misture migração técnica ampla com uma feature de domínio sem necessidade.

Não assuma que exemplos ou comandos antigos do README continuam corretos; confirme-os nos arquivos atuais e reporte documentação desatualizada quando isso afetar a tarefa.

## Qualidade e dados financeiros

- Preserve a distinção entre compra, movimentação, parcela, fatura, pagamento, estorno/reembolso, recorrência e projeção.
- Não introduza dupla contabilização nem confunda competência, compra e pagamento.
- Preserve origem e rastreabilidade de dados importados; importações devem ser idempotentes e não sobrescrever silenciosamente edições feitas na aplicação.
- Valores monetários não devem usar ponto flutuante binário.
- Mudanças de persistência devem considerar integridade referencial, transações e migrations versionadas; revise migrations geradas antes de aplicá-las.
- Consultas analíticas devem respeitar o acesso somente leitura e limites definidos quando esse recurso for implementado.
- Quando regras ainda estiverem em aberto no PRD ou na arquitetura, não invente comportamento financeiro: peça a definição necessária ou mantenha a incerteza explícita.

## Segurança e limites de ação

- Não exponha nem versione segredos, tokens, credenciais ou dados financeiros desnecessários.
- Não execute comandos destrutivos, altere configurações de segurança/infraestrutura, publique/deploye, envie dados a serviços externos ou integre mudanças sem autorização explícita aplicável.
- Use o menor acesso necessário e mantenha consultas de exploração de dados sem capacidade de escrita.
- Inspecione o diff antes de concluir e sinalize qualquer efeito fora do escopo solicitado.

## Verificação

Descubra os comandos de build, testes e lint a partir da solução, projetos, scripts e documentação vigentes. Execute somente verificações pertinentes à tarefa e relate exatamente o que foi executado e seu resultado. Não invente comandos nem afirme que testes passaram sem executá-los.

## Atualização destas instruções

Atualize este arquivo quando o workflow operacional ou os limites dos agentes mudarem. Requisitos de produto pertencem a `docs/product/`; decisões e direção arquitetural pertencem a `docs/architecture/` ou `docs/decisions/`. Prefira uma fonte canônica por informação e links/referências em vez de cópias divergentes.
