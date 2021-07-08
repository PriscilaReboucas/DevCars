Bootcamp aspnet.core

Http é o protocolo base de comunicação na web incluindo a comunicação a recursos de Apis.


EntityFrameworCore.SqlServer
EntityFrameworkCore.Design
EntityFrameworkCore.InMemory.

Passos migrations - codigo que e gerado que faz mapeamento das classes para banco de dados:

dotnet ef migrations add InitialMigration  -o  Persistence/Migrations
-s

dotnet ef database update -- para criar a base de dados. DevCars ou atualizar o banco de dados
-s 
dotnet ef migrations script 0 -o Persistence/Scripts/FirstMigration.sql

-Atualizando nova propriedades
dotnet ef migrations add IsAutomatic
dotnet ef migrations remove

Uso do FluentApi(forma de configurar tabela, propriedades sem precisar adicionar anotações) no lugar do anotation
Principais configurações do banco de dados com EF core
Totable
HasKey
Property

Dapper usado para conectar backend com banco. parecido com o entity framework
Dapper mais rapido que aspnet.core
App Service - MicrosoftAzure - Não esquecer recursos e testes ativos.

$ dotnet ef migrations add InitialMigration -o Persistence/Migrations

-----------------------------------------------------------------------
4 dias
Baixar o Dapper do Nuget manager
Documentação do Swagger
<PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>