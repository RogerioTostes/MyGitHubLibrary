# MyGitHubLibrary

Api feita em .Net core 3.1 usando Dapper como Micro ORM, Swagger para documentação da Api, PostgreeSQl como SGBD.

A Api se encontra dentro de um conteiner do Docker e sua arquitetura foi baseada na Onion.

## Pré requisitos
1. [Docker](https://www.docker.com/)
2. [ASP.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Como rodar
1. git clone https://github.com/RogerioTostes/MyGitHubLibrary.git

2. cd MyGitHubLibrary

3. docker-compose build

3. docker-compose up

4. Digitar o link https://localhost:5001/swagger/index.html

**OBS: Para realizar operações com o crud, aguardar alguns minutos até o banco iniciar.**
