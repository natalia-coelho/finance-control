Especificação de Arquitetura de Software
Sistema de Gestão Financeira Familiar
Versão: 0.1
Status: Proposta arquitetural inicial
Base: PRD --- Sistema de Gestão Financeira Familiar (v0.1, draft) e
decisões tomadas durante a discussão de arquitetura.

1. Objetivo deste documento
Definir a direção arquitetural inicial do Sistema de Gestão Financeira
Familiar, estabelecendo princípios, tecnologias, limites de escopo e
estratégia de evolução.

A arquitetura deve:

atender primeiro às necessidades de uma única família;
manter os dados financeiros consistentes, rastreáveis e consultáveis
por SQL;
permitir evolução incremental sem antecipar complexidade
desnecessária;
preservar a distinção entre eventos financeiros que possuem
significados diferentes;
apoiar o aprendizado e a construção de habilidades práticas em
engenharia de software e AI Engineering.
Este documento define a direção arquitetural. Não é ainda o modelo
físico definitivo do banco de dados. Entidades, relacionamentos,
constraints e tipos de dados deverão ser detalhados e validados antes da
implementação das tabelas.

2. Contexto do produto
O sistema substituirá gradualmente o uso de planilhas como ferramenta
central de gestão financeira familiar.

O produto deverá centralizar receitas, despesas, cartões, faturas,
pagamentos, parcelamentos, recorrências, projeções e importações de
dados. Os dados deverão ser estruturados de forma que possam ser
consultados diretamente por SQL e utilizados futuramente por relatórios
e recursos inteligentes.

2.1 Escopo inicial
A primeira implantação atenderá somente uma família.

A possibilidade de disponibilizar o produto para outras famílias no
futuro é desejável, mas não justifica implementar multi-tenancy no MVP.

Consequências arquiteturais:

não implementar agora autenticação, isolamento ou particionamento
por família;
não codificar nomes de pessoas ou grupos como regras fixas da
aplicação;
manter pessoas e grupos como dados cadastráveis;
reavaliar a estratégia de multi-tenancy quando existir uma
necessidade concreta.
Princípio: considerar a evolução futura sem pagar antecipadamente o
custo de implementá-la.

2.2 Grupos iniciais
Os grupos iniciais definidos são:

Natalia;
Bernardo;
Casa.
O grupo representa a quem a movimentação é atribuída. Não representa
necessariamente quem pagou, qual conta foi utilizada ou qual cartão foi
utilizado.

3. Decisões arquiteturais
Tema Decisão inicial Justificativa

Estilo arquitetural Monólito modular Simplicidade
operacional e evolução
por módulos, sem
distribuir
prematuramente o
sistema.

Banco de dados PostgreSQL Banco relacional
robusto, com
integridade referencial
e suporte a SQL.

Linguagem/plataforma C# com .NET 10 LTS Plataforma escolhida
para a implementação.

Acesso a dados Entity Framework Core e Integração com
Npgsql PostgreSQL e suporte a
migrations. SQL
explícito poderá ser
usado quando trouxer
clareza ou melhor
adequação.

Fonte de verdade Banco de dados O estado financeiro
relacional persistido deve ser
consistente e
rastreável.

Evolução do banco Migrations versionadas Alterações de schema
devem ser revisáveis,
reproduzíveis e
aplicáveis em ordem.

Implantação inicial Uma aplicação e um Reduzir infraestrutura
banco e custo operacional no
MVP.

Consultas analíticas SQL read-only Permitir exploração sem
conceder capacidade de
alteração dos dados
financeiros.
As versões exatas dos pacotes .NET, EF Core e Npgsql deverão ser fixadas
no projeto e verificadas quanto à compatibilidade entre si no momento da
implementação.

4. Estilo arquitetural
4.1 Monólito modular
O sistema será inicialmente uma única aplicação implantável, organizada
em módulos com responsabilidades claras.

Um monólito modular não significa concentrar tudo em uma única camada ou
arquivo. Significa manter uma unidade de implantação enquanto separam-se
os conceitos e responsabilidades internamente.

Benefícios esperados:

menor complexidade de desenvolvimento e operação;
transações locais mais simples;
facilidade para depurar e testar;
possibilidade de extrair componentes no futuro se houver necessidade
real.
Não serão adotados microsserviços no MVP.

4.2 Limites conceituais dos módulos
Os seguintes módulos representam áreas do domínio. Não implicam
necessariamente projetos, schemas ou serviços separados nesta primeira
versão.

Módulo Responsabilidade

Cadastros Pessoas, grupos, categorias e
demais referências necessárias às
movimentações.

Movimentações financeiras Receitas, despesas e seus atributos
e classificações.

Cartões e crédito Cartões, compras parceladas,
parcelas e faturas.

Pagamentos Liquidação de obrigações e
pagamentos de faturas, sem duplicar
despesas.

Planejamento Recorrências, projeções e distinção
entre previsto e realizado.

Importação Entrada de CSV e dados históricos,
validação, deduplicação e
rastreabilidade.

Auditoria e histórico Registro de alterações e
preservação de informações
relevantes para rastrear a origem
dos dados.

Consultas e análises Consultas SQL somente leitura e,
futuramente, visualizações.
Os limites deverão ser refinados conforme o modelo conceitual e as
regras de negócio forem validados.

5. Princípios de modelagem de dados
A modelagem do banco é uma parte central do projeto. O objetivo não é
tentar prever todas as mudanças futuras, mas tornar as mudanças
necessárias seguras, explícitas e rastreáveis.

5.1 Separar conceitos que possuem significados diferentes
O modelo deverá preservar, no mínimo, as seguintes distinções
conceituais identificadas no PRD:

compra;
lançamento ou movimentação financeira;
parcela;
fatura;
pagamento;
estorno ou reembolso;
recorrência;
projeção.
Esses conceitos não devem ser tratados como sinônimos nem fundidos
apenas para reduzir a quantidade de tabelas.

Em particular:

a compra parcelada e suas parcelas não podem gerar dupla
contabilização;
o pagamento da fatura não deve gerar uma segunda despesa;
previsão e realizado devem permanecer distinguíveis;
datas da compra, competência e pagamento devem ser tratadas
separadamente quando aplicável.
A representação física exata desses conceitos ainda será definida na
modelagem.

5.2 Integridade e precisão
O banco deverá proteger a integridade dos dados por meio de:

chaves primárias e estrangeiras;
constraints para regras que possam ser garantidas no banco;
tipos de dados adequados ao significado de cada campo;
transações para operações que precisem ocorrer em conjunto;
migrations versionadas.
Valores monetários não devem utilizar tipos de ponto flutuante binário
(FLOAT/`DOUBLE`). A precisão e escala definitivas deverão ser
escolhidas após definir as regras de moeda, arredondamento, juros e
divisão de parcelas.

5.3 Rastreabilidade e preservação
A importação deverá preservar os dados de origem e permitir rastrear
como um registro foi incorporado e classificado.

A deduplicação deverá ser idempotente: repetir a importação do mesmo
conteúdo não deve criar duplicações indevidas.

O sistema deverá evitar exclusões destrutivas de histórico financeiro.
As regras para correção, cancelamento, estorno e exclusão lógica ainda
precisam ser especificadas.

5.4 Dimensões independentes
O modelo não deverá confundir:

grupo ao qual a movimentação é atribuída;
pessoa que realizou o pagamento;
conta ou cartão utilizado;
categoria da movimentação;
natureza e comportamento financeiro da movimentação.
Categoria não deve determinar, por si só, se uma movimentação é
recorrente, parcelada ou pontual.

6. Estratégia de implementação
6.1 Banco como fonte de verdade
O PostgreSQL será a fonte persistente de verdade do sistema.

As regras de negócio deverão ser protegidas pela aplicação e, quando
possível e apropriado, também por constraints e transações no banco. Não
se deve depender exclusivamente da interface para manter a integridade.

6.2 Entity Framework Core
O EF Core será utilizado como ferramenta de persistência e evolução do
schema.

Diretrizes:

manter o modelo de domínio compreensível, sem deixar que detalhes do
ORM definam automaticamente o domínio;
revisar migrations antes de aplicá-las;
não tratar migrations geradas automaticamente como corretas sem
inspeção;
utilizar SQL explícito quando isso tornar a consulta mais clara ou
adequada;
testar operações críticas de persistência contra PostgreSQL.
EF Core Migrations versionadas no Git serão a fonte canônica do schema.
Cada migration deverá ser revisada antes de ser aplicada. SQL explícito
poderá ser usado em consultas e operações específicas quando trouxer
clareza, sem criar uma segunda trilha de migrations concorrente. Esta
decisão está registrada em `docs/decisions/ADR-002-ef-core-migrations.md`.

6.3 Consultas SQL
O PRD prevê consultas SQL para exploração dos dados.

Essas consultas deverão operar com permissões somente leitura, limites
de execução e limites de volume de resultados. Não se deve permitir que
uma interface de consulta analítica tenha acesso irrestrito para
modificar ou apagar dados.

7. Organização inicial do repositório
A estrutura abaixo é uma proposta evolutiva. Não é necessário criar
diretórios vazios ou projetos sem responsabilidade implementada.

/
├── AGENTS.md
├── README.md
├── docs/
│   ├── product/
│   │   └── PRD.md
│   ├── architecture/
│   │   ├── architecture.md
│   │   ├── domain-glossary.md
│   │   ├── business-rules.md
│   │   ├── conceptual-model.md
│   │   ├── data-model.md
│   │   ├── database-design.md
│   │   ├── data-dictionary.md
│   │   └── decisions/
│   └── planning/
│       └── epics.md
├── src/
├── tests/
├── database/
│   ├── migrations/
│   ├── seeds/
│   └── queries/
└── scripts/
A estrutura poderá ser ajustada quando a solução .NET for criada. A
documentação deve refletir decisões reais, não funcionar como uma
coleção de arquivos vazios.

7.1 Documentação como parte do produto
As decisões arquiteturais relevantes deverão ser registradas e
versionadas junto ao código.

Quando uma decisão importante mudar, deve-se atualizar a documentação
correspondente e, quando útil, registrar o motivo em um Architecture
Decision Record (ADR).

O PRD continuará sendo a referência de requisitos de produto; este
documento define a direção arquitetural e não substitui o PRD.

As fontes canônicas do repositório são:

- `docs/product/PRD.md`: requisitos, regras de negócio e escopo de produto/MVP.
- `docs/architecture/architecture.md`: decisões e restrições técnicas da solução.
- `docs/decisions/`: ADRs aprovados, com contexto, decisão e consequências; esta especificação referencia as decisões vigentes.
- `docs/decisions/decisoes-arquiteturais-ambiente-agentico.md`: prioridade do projeto e operação do workflow agêntico. Trechos sobre escopo financeiro registram a direção do projeto de referência e devem ser reconciliados com o PRD; não substituem o catálogo de requisitos.
- `docs/planning/backlog-adaptacao.md`: sequência, estado e evidências de execução, sem aprovar requisitos ou decisões.
- `README.md`: estado implementado e comandos reproduzíveis.

8. Estratégia de evolução por épicos
A implementação deverá avançar em incrementos pequenos, cada um
terminando em uma capacidade verificável.

Épico Objetivo Resultado verificável

E0 --- Fundação Preparar solução, Banco reproduzível a
PostgreSQL, migrations, partir de migrations e
configuração e rotina ambiente executável.
básica de
desenvolvimento.

E1 --- Núcleo Implementar cadastros Registrar e consultar
financeiro essenciais e operações receitas e despesas com
financeiras mínimas. integridade.

E2 --- Importação Implementar importação Importar um arquivo de
inicial, validação, forma controlada e
preservação de origem e repetir a operação sem
deduplicação. duplicar dados.

E3 --- Cartões e Modelar compras, Registrar uma compra
parcelamentos parcelas, faturas e parcelada e acompanhar
relações com suas parcelas sem dupla
pagamentos. contabilização.

E4 --- Recorrências e Representar Consultar projeções sem
projeções recorrências e separar misturá-las aos
previsto de realizado. lançamentos realizados.

E5 --- Consultas e Disponibilizar Consultar dados com
visualizações consultas e acesso somente leitura
visualizações sobre e limites definidos.
dados consistentes.

E6 --- Automação Introduzir automações e Fluxos automatizados
inteligente recursos inteligentes com validação,
de forma gradual. rastreabilidade e
mecanismos de
segurança.
A ordem e o conteúdo dos épicos deverão ser refinados conforme o PRD for
detalhado. A lista não significa que todos os requisitos Must do PRD
devam entrar no primeiro incremento.

O primeiro incremento aprovado é um recorte transversal: E0 (fundação),
o subconjunto de despesas de E1 (cadastro/consulta/edição básica), E2
(importação histórica da planilha com validação e origem) e consultas SQL
somente leitura de E5. Os demais requisitos do MVP permanecem no escopo
do produto e serão distribuídos em incrementos posteriores. A definição
está registrada no PRD, seção 5.1; os critérios de aceite detalhados
serão elaborados em B4.1.

9. Qualidade, testes e segurança
9.1 Testes
A estratégia de testes deverá crescer junto com o sistema:

testes unitários para regras de domínio;
testes de integração para persistência, constraints e transações;
testes de aceitação para cenários financeiros completos;
testes de importação para validação, idempotência e rastreabilidade.
Os cenários de maior risco incluem:

despesa atribuída à Casa e paga por Natalia;
compra parcelada e geração de parcelas;
pagamento parcial de fatura;
estorno ou reembolso parcial;
cancelamento;
reimportação do mesmo arquivo;
importação de arquivo alterado;
despesa recorrente de valor variável;
pagamento de fatura sem duplicar a despesa.
9.2 Segurança
Mesmo sendo inicialmente um sistema familiar, dados financeiros exigem
cuidado.

Diretrizes iniciais:

não versionar senhas, tokens ou segredos;
utilizar configuração por ambiente;
limitar permissões do usuário de banco utilizado pela aplicação;
separar credenciais de consulta somente leitura;
manter backups e testar a restauração;
evitar expor dados financeiros em logs desnecessários.
Autenticação, autorização detalhada e estratégia de implantação ainda
precisam ser definidas conforme o ambiente de execução.

10. Decisões explicitamente adiadas
Os itens abaixo não estão suficientemente definidos para serem tratados
como decisões arquiteturais fechadas:

multi-tenancy e isolamento entre famílias;
autenticação e autorização;
procedimentos de deployment e detalhes operacionais de hospedagem (o cenário-alvo doméstico está descrito em `docs/decisions/decisoes-arquiteturais-ambiente-agentico.md`, seção 6.2);
precisão e arredondamento monetário;
pagamentos parciais, juros e encargos;
regras completas de estornos, reembolsos e cancelamentos;
antecipação de parcelas;
regras de recorrências com data final;
formatos e variações dos CSVs;
taxonomia definitiva de categorias;
dívidas e transferências;
desenho definitivo de contas, cartões e faturas;
política de retenção e auditoria.
Esses pontos devem ser resolvidos por descoberta de requisitos e
validação de cenários, não por suposições embutidas no schema.

11. Tecnologias e complexidade que não serão introduzidas no MVP
Não há justificativa atual para adicionar:

microsserviços;
Kubernetes;
Kafka ou outro broker de mensagens;
Redis;
banco vetorial;
arquitetura orientada a eventos distribuída;
agentes de IA autônomos;
frontend ou dashboard antes de validar o núcleo de dados.
Essas tecnologias poderão ser reconsideradas se requisitos concretos
justificarem seu custo.

12. Critérios para considerar a arquitetura saudável
A arquitetura estará cumprindo seu papel se:

os conceitos financeiros estiverem representados sem ambiguidades
relevantes;
regras críticas forem protegidas por testes e mecanismos de
integridade;
mudanças no banco forem versionadas e reproduzíveis;
os dados importados puderem ser rastreados até sua origem;
consultas analíticas não puderem alterar dados;
novos módulos puderem ser adicionados sem acoplamento desnecessário;
a solução continuar simples de desenvolver, executar e manter.
O objetivo não é criar um banco de dados que nunca mude. É criar um
sistema cuja evolução seja segura, compreensível e controlada.

13. Próximos passos recomendados
Revisar este documento contra o PRD e corrigir eventuais
divergências.
Consolidar o glossário do domínio usando os termos já presentes no
PRD.
Extrair e validar as regras de negócio e invariantes.
Construir o modelo conceitual e testá-lo com cenários reais.
Só então desenhar o modelo relacional e definir constraints, tipos e
índices.
Implementar a fundação técnica e as primeiras migrations.
Regra de trabalho: não criar tabelas apenas porque um conceito
apareceu no PRD. Primeiro precisamos entender o significado, as regras e
os relacionamentos desse conceito.

