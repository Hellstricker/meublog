
# **MeuBlog - Aplicação de Blog Simples com MVC e API RESTful**

## **1. Apresentação**

Bem-vindo ao repositório do projeto **MeuBlog**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo **Introdução ao Desenvolvimento ASP.NET Core**.
O objetivo principal desenvolver uma aplicação de blog que permite aos usuários criar, editar, visualizar e excluir posts e comentários, tanto através de uma interface web utilizando MVC quanto através de uma API RESTful.


### **Autor(es)**
- **Ozias Manoel costa Neto**
 
## **2. Proposta do Projeto**

O projeto consiste em:

- **Aplicação MVC:** Interface web para interação com o blog.
- **API RESTful:** Exposição dos recursos do blog para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Implementação de controle de acesso, diferenciando administradores e usuários comuns.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através de ORM.

## **3. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core MVC
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
- **Front-end:**
  - Razor Pages/Views
  - HTML/CSS para estilização básica
- **Documentação da API:** Swagger

## **4. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:


- src/
  - MeuBlog.Mvc/ - Projeto MVC
  - MeuBlog.Api/ - API RESTful
  - MeuBlog.Shared/ - Modelos de Dados e Configuração do EF Core
- README.md - Arquivo de Documentação do Projeto
- FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
- .gitignore - Arquivo de Ignoração do Git

## **5. Funcionalidades Implementadas**

- **CRUD para Posts e Comentários:** Permite criar, editar, visualizar e excluir posts e comentários.
- **Autenticação e Autorização:** Diferenciação entre usuários comuns e administradores.
- **API RESTful:** Exposição de endpoints para operações CRUD via API.
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.

## **6. Como Executar o Projeto**

### **Pré-requisitos**

- .NET SDK 8.0 ou superior
- SQL Server
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   - `git clone https://github.com/Hellstricker/meublog.git`
   - `cd meublog`

2. **Configuração do Banco de Dados:**
   - No arquivo `sharedsettings.json`, localizado na pasta **Data** do projeto **MeuBlog.Shared**, configure a string de conexão do SQL Server. Esta configuração é compartilhada por todos os projetos incluídos nesta solução.
   - Utilizando prompt de comando, acesse a pasta raiz do projeto **MeuBlog.Shared** e execute o comando **dotnet ef database update**
   - O seed configurará um usuário com perfil Admin. 
     - login: teste@teste.com
     - senha: Blog#1234

3. **Executar a Aplicação MVC:**
   - `cd src/MeuBlog.MVC/`
   - `dotnet run`
   - Acesse a aplicação em: http://localhost:5132

4. **Executar a API:**
   - `cd src/MeuBlog.API/`
   - `dotnet run`
   - Acesse a documentação da API em: http://localhost:5216/swagger

## **7. Instruções de Configuração**

- **JWT para API:** As chaves de configuração do JWT estão no `appsettings.json`.
- **Migrações do Banco de Dados:** As migrações são gerenciadas pelo Entity Framework Core. Há a opção de aplicar como descrito no item 2 de Passos para Execução ou executar inicialmente a aplicação MVC e clicar no botão apresentado em tela durante a primeira execução.

## **8. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

http://localhost:5216/swagger

## **9. Avaliação**

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas. 
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
