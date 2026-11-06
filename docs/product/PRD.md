# PRD — Sistema de Gestão Financeira Familiar

**Versão:** 0.1  
**Status:** Draft — primeira consolidação do Discovery  
**Tipo:** Produto pessoal / familiar  
**Idioma:** Português (Brasil)

---

## 1. Visão do produto

Construir um sistema centralizado de gestão financeira pessoal e familiar que permita registrar, importar, organizar, consultar e projetar receitas e despesas com confiabilidade.

O produto deverá substituir o controle financeiro atualmente realizado em planilhas, reduzindo atividades manuais e oferecendo maior capacidade de análise dos dados.

Mais do que disponibilizar dashboards prontos, o sistema deverá garantir que os dados financeiros estejam estruturados, íntegros e acessíveis para consultas personalizadas, inclusive por meio de SQL.

A solução deverá permitir que a usuária compreenda:

- Qual é a situação financeira atual da família.
- Quanto cada pessoa e a casa estão gastando.
- Como os gastos estão distribuídos por categoria.
- Quais compromissos financeiros existem nos próximos meses.
- Como o histórico financeiro evoluiu.
- Quanto dinheiro estará comprometido no futuro.
- Quais padrões podem ser identificados nos dados.

### 1.1. Visão de longo prazo

Evoluir para um sistema financeiro com alto grau de automação, capaz de:

1. Receber dados financeiros de diferentes fontes.
2. Normalizar e classificar os lançamentos.
3. Identificar inconsistências e situações que precisam de revisão.
4. Atualizar projeções e indicadores.
5. Permitir análises personalizadas.
6. Aprender com correções e decisões anteriores.

A automação deverá reduzir progressivamente a necessidade de intervenção manual, sem comprometer a confiabilidade dos dados.

---

## 2. Problema

Atualmente, o controle financeiro é realizado por meio de planilhas do Google Sheets.

O processo exige trabalho manual recorrente:

1. Exportar arquivos CSV dos bancos.
2. Inserir os lançamentos na planilha.
3. Classificar as transações, utilizando também um prompt de IA.
4. Revisar descrições de estabelecimentos que não são identificadas corretamente.
5. Adicionar informações complementares.
6. Atualizar controles e projeções.

Esse processo apresenta limitações:

- Alto esforço operacional para manter os dados atualizados.
- Histórico financeiro pouco padronizado.
- Dificuldade para projetar compromissos futuros.
- Dificuldade para analisar a evolução dos gastos.
- Dependência de estruturas e fórmulas de planilhas.
- Limitação para realizar consultas e análises personalizadas.
- Risco de inconsistências e perda de informações.

O problema central não é simplesmente a ausência de dashboards.

**O problema central é a ausência de uma base financeira estruturada, confiável e fácil de atualizar e consultar.**

---

## 3. Usuários e contexto

### 3.1. Usuária principal

A pessoa responsável pela administração do controle financeiro familiar.

### 3.2. Contexto de utilização

O sistema deverá contemplar:

- Finanças individuais.
- Finanças compartilhadas da casa.
- Despesas realizadas por diferentes pessoas.
- Despesas compartilhadas pagas por uma pessoa específica.
- Receitas.
- Compras realizadas com cartões de crédito.
- Despesas recorrentes.
- Compras parceladas.
- Despesas pontuais.

### 3.3. Grupos financeiros iniciais

Os grupos identificados atualmente são:

- Natalia
- Bernardo
- Casa

A estrutura deverá permitir a inclusão de novos grupos futuramente.

O grupo representa a quem pertence ou a quem deve ser atribuída a despesa. Não representa necessariamente quem realizou o pagamento ou qual cartão foi utilizado.

---

## 4. Objetivos do produto

### 4.1. Objetivos principais

1. Centralizar os dados financeiros em uma única estrutura.
2. Preservar e organizar o histórico existente nas planilhas.
3. Reduzir o trabalho manual de inclusão e classificação.
4. Controlar despesas recorrentes, parceladas e pontuais.
5. Projetar compromissos financeiros futuros.
6. Acompanhar receitas e despesas.
7. Controlar cartões de crédito e suas faturas.
8. Permitir consultas SQL personalizadas.
9. Disponibilizar visualizações e gráficos personalizáveis.

### 4.2. Critérios de sucesso

Os indicadores abaixo são propostas iniciais. As metas quantitativas serão definidas após termos uma linha de base.

| Indicador | Resultado esperado |
|---|---|
| Tempo de atualização | Redução significativa do trabalho manual semanal |
| Integridade dos dados | Nenhuma perda silenciosa de lançamentos |
| Duplicidade | Importações repetidas não devem duplicar transações |
| Classificação | Redução progressiva dos lançamentos que exigem classificação manual |
| Projeções | Visualização dos compromissos financeiros futuros |
| Consultas | Possibilidade de responder perguntas financeiras usando SQL |
| Histórico | Dados antigos preservados e consultáveis |

---

## 5. Escopo

### 5.1. MVP — incluído

| Área | Escopo |
|---|---|
| Despesas | Cadastro, importação, classificação e consulta |
| Receitas | Cadastro, importação e consulta |
| Grupos | Natalia, Bernardo e Casa |
| Categorias | Classificação das despesas e receitas |
| Cartões de crédito | Cadastro e associação de despesas |
| Faturas | Organização e acompanhamento de faturas |
| Parcelamentos | Controle de parcelas e compromissos futuros |
| Recorrências | Controle de despesas recorrentes |
| Projeções | Previsão de despesas futuras |
| Pagamentos | Acompanhamento por lançamento e por fatura |
| Histórico | Importação e preservação dos dados existentes |
| SQL | Consultas personalizadas sobre os dados |
| Visualizações | Gráficos e análises personalizáveis |

O escopo acima representa o MVP completo do produto e será entregue em incrementos. O primeiro incremento aprovado inclui fundação técnica reproduzível, despesas, importação histórica da planilha financeira existente, consulta/edição básica e consultas SQL somente leitura. As demais capacidades desta tabela continuam no MVP e serão implementadas em incrementos posteriores; não são removidas do escopo. A ingestão de CSVs bancários (FR-01) também permanece no MVP, em fluxo separado da importação histórica e fora do primeiro incremento. O arquivo/exportação e as abas da planilha histórica serão definidos no contrato de importação (B4.2).

### 5.2. Fora do MVP

Os seguintes itens não fazem parte da primeira versão:

- Gestão de investimentos.
- Controle de carteira de ações, fundos e outros ativos.
- Gestão patrimonial.
- Recomendações de investimentos.
- Automação bancária por APIs ou Open Finance, inicialmente.
- Automação financeira totalmente autônoma.

Esses itens poderão ser considerados em versões futuras.

---

## 6. Conceitos fundamentais do domínio

Esta seção estabelece uma linguagem comum para o produto. Os conceitos precisam ser tratados separadamente para evitar inconsistências na implementação.

### 6.1. Grupo

Identifica a quem pertence ou a quem deve ser atribuída uma movimentação financeira.

Exemplos:

- Natalia
- Bernardo
- Casa

Uma despesa da Casa pode ser paga com o cartão da Natalia.

Portanto, grupo e meio de pagamento são informações independentes.

### 6.2. Categoria

Representa a natureza ou classificação de uma movimentação.

Exemplos:

- Moradia
- Mercado
- Saúde/Farmácia
- Viagem
- Vestuário
- Educação
- Lazer

A categoria não determina o comportamento financeiro da despesa.

Uma compra de mercado, por exemplo, pode ser pontual, recorrente ou parcelada.

### 6.3. Despesa pontual

Despesa realizada uma única vez, sem compromisso futuro associado.

Exemplo: uma compra à vista.

### 6.4. Despesa parcelada

Despesa originada por uma compra dividida em um número determinado de parcelas.

Exemplo:

- Compra: R$ 1.200,00.
- Parcelamento: 12 vezes.
- Valor de cada parcela: R$ 100,00.

A análise mensal deve considerar R$ 100,00 em cada mês de competência, e não R$ 1.200,00 no mês da compra.

### 6.5. Despesa recorrente

Despesa que acontece periodicamente e não possui, no modelo atual, uma data final previamente definida.

Exemplos:

- Internet.
- Assinaturas.
- Contas de serviços.
- Despesas periódicas com animais de estimação.

Uma despesa recorrente pode ter valor fixo ou variável.

### 6.6. Despesa recorrente variável

Despesa recorrente cujo valor muda ao longo do tempo.

Exemplo: energia elétrica.

O sistema deverá utilizar a média histórica para projetar os próximos valores e permitir que a projeção seja alterada manualmente quando houver informação mais precisa.

### 6.7. Cartão de crédito

Representa o instrumento de pagamento utilizado para realizar uma compra.

O cartão não representa o grupo financeiro responsável pela despesa.

### 6.8. Fatura

Representa o conjunto de lançamentos associados a um ciclo de cobrança do cartão.

O pagamento da fatura não deve ser registrado como uma nova despesa, pois isso duplicaria o valor já contabilizado nos lançamentos individuais.

### 6.9. Competência

Representa o mês em que a despesa deve ser considerada nas análises financeiras.

Para compras parceladas, a competência corresponde ao mês em que cada parcela é cobrada.

### 6.10. Datas financeiras

O sistema deverá distinguir:

- **Data da compra:** quando a compra aconteceu.
- **Data de competência/cobrança:** mês em que o lançamento deve ser considerado financeiramente.
- **Data do pagamento:** quando o valor foi efetivamente pago.

Essas datas não devem ser tratadas como equivalentes.

### 6.11. Projeção

Representa uma estimativa de movimentações financeiras futuras.

Uma projeção não deve ser confundida com uma transação efetivamente realizada.

---

## 7. Requisitos funcionais

Os requisitos estão identificados por prioridade:

- **Must:** indispensável para o MVP.
- **Should:** importante, mas pode ser implementado depois dos requisitos essenciais.
- **Could:** melhoria desejável.

### 7.1. Importação e gestão de dados

**FR-01 — Importação de CSV**  
O sistema deve permitir importar arquivos CSV provenientes de instituições financeiras.

Prioridade: Must.

**FR-02 — Pré-visualização da importação**  
Antes de confirmar a importação, o sistema deve permitir visualizar os registros identificados.

Prioridade: Must.

**FR-03 — Validação dos registros**  
O sistema deve identificar registros com informações ausentes, formatos inválidos ou inconsistências.

Prioridade: Must.

**FR-04 — Prevenção de duplicidade**  
O sistema deve evitar que a importação repetida de um mesmo arquivo gere lançamentos duplicados.

Prioridade: Must.

**FR-05 — Preservação dos dados originais**  
O sistema deve preservar os dados brutos importados, permitindo rastrear a origem das informações e corrigir problemas de normalização.

Prioridade: Must.

**FR-06 — Histórico financeiro**  
O sistema deve permitir importar os dados históricos atualmente armazenados na planilha financeira existente. Cada ocorrência mensal histórica deve permanecer como registro da competência correspondente, sem ser substituída por uma regra de recorrência. A definição do arquivo/exportação e das abas suportadas será feita no contrato de importação (B4.2). Esse fluxo é distinto da ingestão recorrente dos CSVs bancários previstos em FR-01.

Prioridade: Must.

**FR-07 — Rastreabilidade da importação**  
Os registros devem manter informações que permitam identificar sua origem e o processo de importação.

Prioridade: Should.

### 7.2. Classificação e organização

**FR-08 — Categorias**  
O sistema deve permitir classificar receitas e despesas por categorias.

Prioridade: Must.

**FR-09 — Grupos financeiros**  
O sistema deve permitir associar cada movimentação a um grupo financeiro.

Prioridade: Must.

**FR-10 — Separação de dimensões**  
Grupo, categoria, cartão, conta e responsável pelo pagamento devem ser informações independentes.

Prioridade: Must.

**FR-11 — Preservação da classificação original**  
Durante a migração, o sistema deve preservar a categoria original da planilha, mesmo quando ela for mapeada para uma categoria normalizada.

Prioridade: Must.

**FR-12 — Classificação assistida por IA**  
O sistema deverá utilizar IA para sugerir categorias com base nas descrições das transações.

Prioridade: Should.

**FR-13 — Revisão de classificações**  
A usuária deverá conseguir revisar e corrigir classificações sugeridas.

Prioridade: Must.

**FR-14 — Reutilização de correções**  
O sistema deverá permitir reaproveitar classificações corrigidas em lançamentos futuros semelhantes.

Prioridade: Should.

### 7.3. Gestão de despesas

**FR-15 — Despesas pontuais**  
O sistema deve permitir cadastrar despesas que acontecem uma única vez.

Prioridade: Must.

**FR-16 — Despesas parceladas**  
O sistema deve permitir cadastrar compras parceladas, contendo pelo menos:

- Valor total da compra.
- Quantidade de parcelas.
- Valor da parcela.
- Data da compra.
- Competência de cada parcela.
- Cartão utilizado, quando aplicável.

Prioridade: Must.

**FR-17 — Despesas recorrentes**  
O sistema deve permitir cadastrar despesas recorrentes e suas respectivas regras de recorrência.

Prioridade: Must.

**FR-18 — Despesas recorrentes variáveis**  
O sistema deve permitir projetar valores variáveis com base no histórico.

Prioridade: Must.

**FR-19 — Ajuste de projeções**  
A usuária deve conseguir alterar manualmente o valor projetado de um mês específico.

Prioridade: Must.

**FR-20 — Separação entre previsto e realizado**  
O sistema deve distinguir valores previstos, valores efetivamente cobrados e valores efetivamente pagos.

Prioridade: Must.

**FR-21 — Observações**  
O sistema deve permitir armazenar observações associadas às movimentações.

Prioridade: Must.

As observações históricas deverão ser preservadas durante a migração, mesmo quando contiverem informações que ainda não possuam um campo estruturado correspondente.

### 7.4. Receitas

**FR-22 — Registro de receitas**  
O sistema deve permitir registrar receitas financeiras.

Prioridade: Must.

**FR-23 — Classificação de receitas**  
As receitas devem poder ser classificadas e associadas a grupos financeiros.

Prioridade: Must.

O detalhamento das regras de receitas será aprofundado no segundo Discovery.

### 7.5. Cartões e faturas

**FR-24 — Cadastro de cartões**  
O sistema deve permitir cadastrar cartões de crédito.

Prioridade: Must.

**FR-25 — Associação de compras**  
Uma despesa realizada com cartão deve poder ser associada ao cartão utilizado.

Prioridade: Must.

**FR-26 — Organização por fatura**  
Os lançamentos de cartão devem poder ser associados às respectivas faturas.

Prioridade: Must.

**FR-27 — Acompanhamento de faturas**  
O sistema deve permitir acompanhar o status de pagamento das faturas.

Prioridade: Must.

**FR-28 — Separação entre compra e pagamento da fatura**  
O pagamento da fatura não deve gerar uma segunda contabilização das despesas que já foram registradas individualmente.

Prioridade: Must.

### 7.6. Pagamentos

**FR-29 — Status individual**  
Cada lançamento deve possuir um status de pagamento.

Prioridade: Must.

**FR-30 — Status da fatura**  
Cada fatura deve possuir um status de pagamento.

Prioridade: Must.

**FR-31 — Sincronização de status**  
O pagamento de uma fatura deve atualizar o status dos lançamentos vinculados a ela, respeitando as regras de pagamento estabelecidas pelo produto.

Prioridade: Must.

### 7.7. Projeções financeiras

**FR-32 — Projeção de compromissos futuros**  
O sistema deve projetar despesas futuras com base em recorrências e parcelamentos.

Prioridade: Must.

**FR-33 — Projeção mensal**  
A usuária deve conseguir visualizar os compromissos financeiros organizados por mês de competência.

Prioridade: Must.

**FR-34 — Projeção de despesas variáveis**  
O sistema deve utilizar a média histórica para estimar despesas recorrentes variáveis.

Prioridade: Must.

**FR-35 — Ajuste manual da projeção**  
A usuária deve conseguir substituir a estimativa por um valor conhecido para determinado mês.

Prioridade: Must.

### 7.8. Consultas e visualizações

**FR-36 — Consultas SQL livres**  
O sistema deve disponibilizar uma interface para executar consultas SQL personalizadas sobre os dados financeiros.

Prioridade: Must.

**FR-37 — Filtros de consulta**  
As informações devem permitir análises por diferentes dimensões, incluindo:

- Ano.
- Mês.
- Competência.
- Categoria.
- Grupo.
- Cartão.
- Tipo de despesa.
- Status de pagamento.

Prioridade: Must.

**FR-38 — Visualizações personalizadas**  
O sistema deve permitir transformar resultados de consultas em gráficos.

Prioridade: Should.

**FR-39 — Histórico consultável**  
Os dados históricos devem estar disponíveis para consultas e comparações ao longo do tempo.

Prioridade: Must.

---

## 8. Regras de negócio

As regras abaixo representam decisões e necessidades identificadas durante o Discovery.

**BR-01 — Grupo não é meio de pagamento**

Uma despesa pertence a um grupo, independentemente do cartão ou da pessoa que realizou o pagamento.

**BR-02 — Categoria não determina o tipo de despesa**

Uma categoria pode conter despesas pontuais, parceladas ou recorrentes.

**BR-03 — Parcelas são contabilizadas por competência**

Uma compra parcelada deve impactar as análises mensais conforme o valor de cada parcela no mês em que ela é cobrada.

**BR-04 — Datas devem permanecer independentes**

Data da compra, competência e data do pagamento representam eventos diferentes.

**BR-05 — Previsão não é realização**

Um valor projetado não pode ser confundido com uma despesa efetivamente cobrada ou paga.

**BR-06 — Despesas variáveis utilizam histórico**

A projeção inicial de uma despesa recorrente variável deve utilizar a média histórica disponível.

**BR-07 — Projeções podem ser ajustadas**

A usuária pode substituir manualmente uma projeção quando tiver uma informação mais precisa.

**BR-08 — Fatura não é uma nova despesa**

O pagamento da fatura não pode duplicar os lançamentos que compõem seu valor.

**BR-09 — Pagamento possui dois níveis de acompanhamento**

O produto deve acompanhar o status dos lançamentos individuais e o status agregado da fatura.

**BR-10 — Dados históricos não podem ser descartados silenciosamente**

Informações originais, inclusive observações e classificações antigas, devem ser preservadas durante a migração.

**BR-11 — Ausência de informação não significa resposta negativa**

Um campo vazio ou desconhecido não deve ser automaticamente interpretado como falso, não pago ou não aplicável.

**BR-12 — Um lançamento pertence a um único grupo no MVP**

Cada lançamento pertence a exatamente um grupo. Não haverá rateio de um mesmo lançamento entre grupos no MVP.

**BR-13 — Categoria é opcional e única por lançamento**

Um lançamento pode não ter categoria ou ter uma única categoria. A categoria não determina o grupo nem o comportamento financeiro.

**BR-14 — Relação entre parcelas exige evidência**

Parcelas de uma mesma compra só devem ser relacionadas quando houver evidência suficiente; descrições iguais, por si só, não provam que pertencem à mesma compra.

**BR-15 — Rótulos de origem não criam recorrências automaticamente**

Valores de origem como `Fixo` e `AFixo` devem ser preservados como dados de referência na importação histórica e não devem, por si só, gerar ocorrências futuras.

**BR-16 — Estado bruto de pagamento importado deve ser preservado**

O valor bruto de origem, inclusive `Pago` quando presente, deve ser preservado. No primeiro incremento ele não será convertido, sem regra aprovada, em uma interpretação completa de pagamentos; o acompanhamento de pagamentos permanece no escopo do MVP conforme FR-29 a FR-31.

---

## 9. Fluxos principais do produto

### 9.1. Importação de movimentações

1. A usuária seleciona um arquivo CSV.
2. O sistema interpreta a estrutura do arquivo.
3. O sistema apresenta uma prévia dos lançamentos.
4. O sistema valida os dados.
5. O sistema identifica possíveis duplicidades.
6. O sistema sugere classificações.
7. A usuária revisa os casos que exigem intervenção.
8. Os dados são registrados e ficam disponíveis para consulta.

### 9.2. Migração do histórico

1. A usuária fornece a planilha atual.
2. O sistema identifica as abas e estruturas existentes.
3. Os campos antigos são relacionados aos conceitos do novo sistema.
4. Categorias e grupos são mapeados.
5. Informações ambíguas são sinalizadas.
6. Os dados são importados preservando sua origem.
7. A usuária consegue validar os resultados da migração.

### 9.3. Cadastro de despesa parcelada

1. A usuária registra uma compra.
2. Informa o valor total e a quantidade de parcelas.
3. Informa a data da compra.
4. O sistema organiza as parcelas por competência.
5. As parcelas passam a compor as projeções dos meses correspondentes.
6. Cada parcela pode ser associada à sua fatura e ter seu pagamento acompanhado.

### 9.4. Projeção de despesa variável

1. O sistema identifica uma despesa recorrente variável.
2. Calcula a média histórica disponível.
3. Utiliza essa média para estimar os meses futuros.
4. A usuária pode ajustar uma previsão específica.
5. Quando o valor real é conhecido, o sistema passa a apresentar o valor efetivo.

### 9.5. Acompanhamento de fatura

1. Os lançamentos são associados a uma fatura.
2. O sistema calcula o total dos lançamentos.
3. A fatura apresenta seu status de pagamento.
4. Ao registrar o pagamento da fatura, os lançamentos associados têm seus status atualizados.
5. O pagamento da fatura não é contabilizado como uma nova despesa.

### 9.6. Análise personalizada

1. A usuária acessa a interface SQL.
2. Escreve uma consulta sobre os dados financeiros.
3. Visualiza os resultados.
4. Pode transformar os resultados em uma visualização gráfica.

---

## 10. Modelo conceitual de dados

Esta seção descreve os conceitos que deverão existir no domínio. Não representa ainda o schema definitivo do banco de dados.

| Entidade | Responsabilidade |
|---|---|
| Grupo | Identificar a quem pertence uma movimentação |
| Categoria | Classificar a natureza da movimentação |
| Conta | Representar uma conta financeira |
| Cartão | Representar um cartão de crédito |
| Fatura | Representar um ciclo de cobrança do cartão |
| Transação | Representar uma movimentação financeira |
| Despesa | Representar informações específicas de uma despesa |
| Receita | Representar informações específicas de uma receita |
| Parcelamento | Representar uma compra dividida em parcelas |
| Parcela | Representar cada compromisso mensal do parcelamento |
| Recorrência | Representar a regra de repetição de uma despesa |
| Projeção | Representar valores financeiros estimados |
| Importação | Registrar a origem e o processamento de dados |
| Classificação | Registrar a categoria atribuída a uma movimentação |

### 10.1. Princípios para o futuro modelo

1. Separar dados originais de dados normalizados.
2. Não misturar grupo, categoria e meio de pagamento.
3. Não misturar compra, parcela, fatura e pagamento.
4. Preservar as datas financeiras individualmente.
5. Distinguir valores previstos de valores realizados.
6. Permitir rastrear a origem de cada registro.
7. Evitar que um mesmo evento financeiro seja contabilizado duas vezes.

O modelo físico e os relacionamentos definitivos serão definidos durante a etapa de arquitetura e modelagem técnica.

---

## 11. Requisitos não funcionais

### 11.1. Integridade e confiabilidade

A integridade dos dados é um requisito central do produto.

O sistema deverá:

- Evitar duplicidades.
- Validar informações importadas.
- Preservar registros originais.
- Permitir identificar a origem dos dados.
- Evitar contabilizações duplicadas.
- Sinalizar inconsistências.

### 11.2. Auditabilidade

Deverá ser possível entender como um registro chegou ao estado atual, incluindo sua origem e alterações relevantes.

### 11.3. Segurança

Os dados financeiros são sensíveis.

A solução deverá considerar:

- Controle de acesso.
- Proteção dos dados armazenados.
- Proteção de credenciais.
- Backups.
- Possibilidade de recuperação dos dados.

### 11.4. Portabilidade

Os dados devem permanecer acessíveis e exportáveis, evitando dependência desnecessária de uma ferramenta específica.

### 11.5. Consultas SQL seguras

A interface SQL deverá ser planejada com restrições de segurança.

**Recomendação para o MVP:** permitir apenas consultas de leitura, como `SELECT`, utilizando uma conexão ou permissão de banco sem autorização para alterar os dados.

Também deverão existir limites de execução e de volume de resultados.

Essa restrição protege a integridade financeira sem eliminar a liberdade de análise que é um requisito central do produto.

---

## 12. Taxonomia inicial de categorias

As planilhas atuais possuem categorias diferentes e, em alguns casos, conceitos aparentemente misturados.

Foram identificados, entre outros, os seguintes valores:

- Assinatura
- Estética
- Produtos de beleza
- Saúde/Farmácia
- Uber
- Lazer
- Mercado
- Ifood/comer fora
- Vestuário
- Presentes
- Viagem
- Extras/não planejados
- Contas moradia
- Casinha
- Dívida
- Gordas
- Celular
- Educação
- Moradia
- Sem categoria

Essa lista representa os valores encontrados no histórico, não uma taxonomia final aprovada.

Durante a migração:

1. Os valores originais deverão ser preservados.
2. Deverá ser possível mapear categorias antigas para categorias normalizadas.
3. Nenhuma informação deverá ser descartada por causa de uma mudança de nomenclatura.
4. Categorias e grupos financeiros deverão continuar sendo conceitos independentes.

A taxonomia definitiva será estabelecida no segundo Discovery.

---

## 13. Critérios gerais de aceite do MVP

O MVP poderá ser considerado funcional quando os seguintes cenários forem atendidos:

### Cenário 1 — Importação sem duplicidade

Dado um arquivo CSV válido, quando ele for importado duas vezes, o sistema não deverá duplicar os mesmos lançamentos.

### Cenário 2 — Preservação histórica

Dada uma planilha antiga, quando seus registros forem migrados, os dados originais e suas observações deverão continuar acessíveis.

### Cenário 3 — Separação entre grupo e cartão

Dada uma despesa pertencente à Casa e paga com o cartão da Natalia, o sistema deverá armazenar essas informações separadamente.

### Cenário 4 — Parcelamento

Dada uma compra de R$ 1.200,00 dividida em 12 parcelas de R$ 100,00, a análise de cada mês deverá considerar R$ 100,00 de competência, e não R$ 1.200,00.

### Cenário 5 — Projeção variável

Dada uma despesa recorrente variável, o sistema deverá projetar seu valor utilizando a média histórica e permitir ajuste manual da previsão.

### Cenário 6 — Pagamento de fatura

Dada uma fatura com lançamentos registrados, quando ela for marcada como paga, os lançamentos associados deverão ter seus status atualizados sem gerar uma nova despesa.

### Cenário 7 — Consulta SQL

Dada uma base com movimentações financeiras, a usuária deverá conseguir executar uma consulta SQL para filtrar despesas por categoria e ano.

### Cenário 8 — Análise histórica

Dada uma base com dados de diferentes anos, a usuária deverá conseguir consultar e comparar os valores por mês, ano, categoria e grupo.

---

## 14. Premissas e riscos

### Premissas

- O sistema será inicialmente utilizado pela responsável pelo controle financeiro familiar.
- A primeira fonte de dados será CSV.
- O histórico existente será migrado do Google Sheets.
- Os grupos iniciais serão Natalia, Bernardo e Casa.
- Cartões de crédito são um meio de pagamento relevante no contexto atual.
- A confiabilidade dos dados é mais importante do que a quantidade de dashboards disponíveis.
- Consultas SQL livres são uma capacidade essencial do produto.

### Riscos

| Risco | Impacto | Direcionamento |
|---|---|---|
| Histórico inconsistente | Alto | Preservar dados originais e validar migração |
| Duplicidade de importação | Alto | Criar mecanismo de identificação de duplicatas |
| Classificação incorreta por IA | Médio/alto | Permitir revisão e rastreabilidade |
| Confusão entre compra e fatura | Alto | Separar os eventos financeiros |
| Confusão entre previsão e realização | Alto | Manter estados e valores distintos |
| Escopo excessivo | Alto | Priorizar o MVP e postergar investimentos e automações avançadas |
| Modelo de dados inadequado | Alto | Validar domínio antes de escolher a arquitetura |

---

## 15. Segundo Discovery — definições pendentes

Os pontos abaixo ainda não estão suficientemente definidos para serem tratados como requisitos fechados.

Eles deverão ser explorados antes da especificação técnica definitiva.

### 15.1. Receitas

- Quais são as fontes de receita?
- Existem receitas fixas, variáveis e eventuais?
- Como devem funcionar as projeções de receitas?
- Como são tratadas transferências entre contas?

### 15.2. Contas e cartões

- Quantas contas e cartões existem?
- Quais são os bancos e emissores?
- Cada cartão possui titular, fechamento e vencimento próprios?
- Como são importadas as faturas?
- Como tratar compras realizadas em um cartão adicional?
- Como associar automaticamente um lançamento à fatura correta?

### 15.3. Pagamentos e ajustes

- Como tratar pagamentos parciais de fatura?
- Como tratar juros, multas e encargos?
- Como registrar estornos e reembolsos?
- Como tratar uma compra cancelada?
- Como tratar diferenças entre o valor previsto e o valor cobrado?

### 15.4. Recorrências e parcelamentos

- Como representar recorrências com data final?
- Como tratar alterações no valor de uma despesa recorrente?
- Como tratar cancelamentos?
- Como tratar antecipação de parcelas?
- Como tratar compras parceladas que aparecem de forma diferente no CSV?
- As ocorrências futuras devem ser criadas antecipadamente ou calculadas dinamicamente nas projeções?

### 15.5. Classificação

- Qual será a taxonomia definitiva?
- Quais categorias terão subcategorias?
- Quais conceitos hoje misturados nas categorias deverão virar centros de custo ou outras dimensões?
- Como a usuária deseja revisar classificações sugeridas pela IA?
- Quais correções poderão ser reaproveitadas automaticamente?

### 15.6. Dívidas e empréstimos

As planilhas possuem registros de dívidas e valores emprestados, inclusive com juros e prazos.

Será necessário definir se esses registros serão tratados como:

- Despesas parceladas.
- Obrigações financeiras.
- Empréstimos.
- Reembolsos.
- Uma entidade específica de dívida.

Esse domínio não deve ser simplificado prematuramente, pois pode ter regras financeiras diferentes de uma compra parcelada comum.

### 15.7. Importação e integração

- Quais bancos e formatos CSV serão suportados inicialmente?
- Os arquivos possuem identificadores únicos de transação?
- Como reconhecer uma transação já importada?
- Como lidar com alterações em transações que já foram importadas?
- Como validar a conciliação entre CSV, fatura e registros internos?

### 15.8. Consultas e visualizações

- Qual nível de liberdade a interface SQL deverá oferecer?
- Quais gráficos são prioritários?
- Será necessário salvar consultas?
- Será necessário criar dashboards a partir de consultas?
- Como serão exportados os resultados?

### 15.9. Segurança e operação

- Onde o sistema será executado?
- Será acessado apenas localmente ou pela internet?
- Haverá mais de um usuário com acesso?
- Como serão feitos backups e recuperação?
- Quais dados poderão ser enviados a serviços externos de IA?

---

## 16. Próximas etapas recomendadas

A sequência recomendada é:

1. **Segundo Discovery:** detalhar receitas, contas, cartões, faturas, pagamentos, dívidas e taxonomia.
2. **Modelagem do domínio:** transformar os conceitos em entidades, relações e regras explícitas.
3. **Arquitetura técnica:** escolher tecnologias e definir a estrutura da solução.
4. **Planejamento do MVP:** dividir o produto em entregas pequenas e verificáveis.
5. **Implementação incremental:** construir e validar cada fluxo com dados reais.
6. **Migração histórica:** importar os dados existentes e conferir sua integridade.
7. **Automação:** evoluir progressivamente a importação, classificação e revisão.

---

## 17. Princípio orientador do produto

A prioridade não é construir o dashboard mais bonito nem adicionar IA a todas as etapas.

A prioridade é construir uma base financeira confiável, com um modelo de domínio correto e dados rastreáveis.

A partir dessa base, consultas, gráficos, projeções e automações poderão ser desenvolvidos sem comprometer a integridade das informações.

**Se os dados estiverem errados, a automação apenas produzirá erros mais rapidamente.**

Por isso, a qualidade dos dados e a clareza das regras de negócio devem orientar todas as decisões de produto e engenharia.
