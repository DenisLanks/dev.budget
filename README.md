# dev.budget

Este projeto é para atender um desafio de desenvolvimento. O projeto está subdivido em 3 projetos .NET Core o **dev.budget.api** é a aplicação propriamente dita. O **dev.budget.business** contem as regras de negócio da aplicação, assim ela pode ser reaproveitada em outra aplicação que não seja ASP .NET Core. E por fim o projeto **dev.budget.test** onde estão localizados os testes unitários da camada de negócio.

## Como rodar a aplicação
Clone este repositório executando o seguinte comando:

**git clone https://github.com/DenisLanks/dev.budget.git**

Agora vá até a pasta `dev.budget.api/ClientApp` com o comando **cd dev.budget.api/ClientApp** 

Observe que tem um projeto do angular dentro desta pasta. Por isso será necessário rodar o comando `npm i` para instalar as dependências de forma correta.

Em seguida mova para dentro da pasta **dev.budget.api**  executando o seguinte comando:

**cd ../**

Por fim rode a aplicação pelo comando **run** do dotnet

**dotnet run**

## Rodando testes unitários
Este projeto vem equipado com testes unitários. Não cobre 100% do código mas já garante as principais regras de negócio. Para incluir novos cenários, basta ir nos respectivos **"ModelTest"** do projeto **dev.budget.test**.
Rode `dotnet test` dentro da pasta `dev.budget.test` para checar os cenários cobertos e possíveis regras não atendidas.

