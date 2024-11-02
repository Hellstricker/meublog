# Feedback do Instrutor

#### 23/10/24 - Revisão Inicial - Eduardo Pires

## Pontos Positivos:

- Separação de responsabilidades
- Demonstrou conhecimento em Identity e JWT.
- Boa validação de permissões e roles
- Bom uso e domínio de diversos recursos do ASP.NET
- Mostrou entendimento do ecossistema de desenvolvimento em .NET
- Arquitetura simples e objetiva de acordo com a complexidade

## Pontos Negativos:

- A unificação entre Autor e User (identity) poderia ser muito mais simples sem a necessidade de abstração e acoplamento utilizada.

## Sugestões:

- Unificar a criação do user + autor no mesmo processo. Utilize o ID do registro do Identity como o ID da PK do Autor, assim você mantém um link lógico entre os elementos sem criar acoplamento.

## Problemas:

- Não consegui executar a aplicação de imediato na máquina. É necessário que o Seed esteja configurado corretamente, com uma connection string apontando para o SQLite.

  **P.S.** As migrations precisam ser geradas com uma conexão apontando para o SQLite; caso contrário, a aplicação não roda.
