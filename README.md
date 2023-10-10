# AvaliacaoUsabit

O projeto consiste em dois microserviços para cadastros e consultas de pessoas. O microserviço "PersonService" é responsável 
por criar, editar, deletar, utilizando o Entity Framework In-Memory, e o projeto "SearchService" consome os registros cadastrados 
e publicados no "PersonService" utilizando o MongoDb para salvar esses registros. No "SearchService" ainda é possível fazer a 
consulta desses registros com retorno paginado, por alguns termos como: nome, email, gênero e o número da página e a quantidade 
de registros retornados.

1-Rodar o comando "docker compose up -d" na pasta AvaliacaoUsabit onde está o arquivo docker-compose.yml, para caso necessário
  baixar as imagens do RabbitMq e MongoDb e iniciar elas.
  
2-Rodar o projeto "PersonService".

3-Rodar o Projeto "SearchService".

Obs: ao rodar os projetos serão adicionados três registros para teste nos dois bancos de dados.