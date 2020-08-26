# MyGitHubLibrary

Api feita em .Net core 3.1 usando Dapper como Micro ORM, Swagger para documentação da Api, PostgreeSQl como SGBD.

A Api se encontra dentro de um conteiner do Docker e sua arquitetura foi baseada na Onion.

## Pré requisitos
1. [Docker](https://www.docker.com/)
2. [ASP.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Como rodar
git clone https://github.com/RogerioTostes/MyGitHubLibrary.git

cd MyGitHubLibrary

docker-compose build

docker-compose up

Digitar o link https://localhost:5001/swagger/index.html
