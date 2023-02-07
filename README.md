# movie-api
Api Rest teórica para pratica de .Net - Curso Alura

# Sobre o projeto
Projeto de formação do Curso de ASP.NET Core da alura. Com utilização de ferramentas ASP.NET Core, AutoMapper, OpenApi e EntityFramework. E para percistencia das informações, foi utilizado o Banco de Dados MySQL.
Aplicação projetada para simular um ambiente de gerenciamento de Filmes.  

A aplicação segue configurada e documentada pela ferramenta Swagger, pelo qual podem ser acessadas suas funcionalidades, bastando clonar este repositorio para sua máquina, rodar a aplicação através de uma IDEA como o Visual Studio, a instalação local do MySQL, e acessar os endpoints de suas funcionalidades através do Swagger, apenas conectando no seu navegador pelo link: 

https://localhost:7051/swagger/index.html

Após acessar o link, percebera os endpoints separados pelas Controllers: Pessoa e Endereço.

# COMO UTILIZAR API:

Busca por lista de Filmes Registrados:
GET
https://localhost:7051/Movie

Este endpoint lhe oferece as opções de busca através dos operadores Skip e Take para navegação estatica, ou paginação dinamica, basta colocar a quantidade de objetos da coleção que deseja ignorar através do operador Skip, e a quantidade de itens que poderão ser dispostos por busca, através do operador Take.

Buscar por ID:
GET
https://localhost:7051/Movie/{id}

Este endpoint, lhe oferece as opções de busca pelo ID do filme que deseja pesquisar.

Cadastro do Filme:
POST
https://localhost:7051/Movie

Para cadastrar um filme, acesse o endpoint POST. Através desse você poderá registrar os dados do Filme.

Editar dados do Filme:
PUT
https://localhost:7051/Movie/{id}

Através deste endpoint é possivel a atualização de todos os dados do filme registrado. Pesquisando o filme que deseja atualizar através do seu ID.

Editar dados do Filme:
PATCH
https://localhost:7051/Movie/{id}

Através deste endpoint é possivel a atualização PARCIAL dos dados do filme registrado. Pesquisando o filme que deseja atualizar através do seu ID.

Deletar Filme:
DELETE
https://localhost:7051/Movie/{id}

Utilizando este endpoint, o usuario deve buscar o filme que ele deseja deletar através do ID. Considerando que esta é uma aplicação teórica, os deletes são físicos e não lógicos. Portanto os dados serão perdidos por completo.
