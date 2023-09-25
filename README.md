# Microsservicos-Macoratti

 - Estudo e pesquisa sobre micros serviços com ASP.NET 7 Core e Docker!

 - "Instalando o Linux no windown"

<blockquete>

                wsl --install

</blockquete>

# Criando o projeto web api na pasta DemoMicrosservice

 - Para evitar erro, cria uma solução em branco, depois cria um projeto webapi como exemplo.

 - Quando for cria o projeto WebApi, seleciona a opção Dcoker para gerar o dockerfile sozinho.

<blockquete>

        dotnet new webapi -o DemoMicroservice --no-https

        cd DemoMicroservice

        code.

        dotnet run

        http://localhost:5000/weatherforecast

</blockquete>

# Docker
 
 - É uma plataforma que permite "criar, enviar e executar qualquer aplicativo, em qualquer lugar".

 - O objetivo do Docker é criar, testar e implementar aplicações em um ambiente separado da máquina original, chamado de contêiner, onde o desenvolvedor consegue empacotar sua aplicação de forma padrão com níveis de isolamento.

 ### Registry:

  - É um repositório de imagens Docker a partir de onde podemos obter imagens prontas para criar os nossos contêineres. https://hub.docker.com

 ### Host:

  - No Host temos a imagem que foi baixada do repositorio, ou criada por você, A partir dela criamos o processo que é o Contêiner Docker.

 ### Client:

  - O Client permite acessar o contêiner via linha de comando ou via API Remota. 

 ### Contêiner:

  - Um contêiner é uma unidade padrão de software que empacote o código e todas as suas dependências para que o aplicativo seja executado de maneira rápida e confiável de um ambiente de computação para outro.

 ### Imagens:

  - Imagens são modelos que são usados para criar contêineres e que contêm um sistema de arquivos com todos os arquivos que a aplicação no contêiner requer. Assim um contêiner é uma instância de uma imagem.

<blockquete>

        docker container run  

</blockquete>

 - Cria uma conta no site : https://hub.docker.com

 - Depois baixa o docker: https://www.docker.com/products/docker-desktop/

 - Instala o Docker e faz o login.

 ### Comandos docker

  - docker --version: informa a versão.
 
  - docker hellow-word: cria uma imagem para teste.

  - docker image ls : lista as imagens que você tem.

  - docker image rm "id da imagen": remove a imagem.

  - docker container rm "id da imagen": remove a imagem, (pode por um -f no final do comando para forçar).

  - docker container ls: lista os containes.

  - docker run: procura a imagem na maquina local -> não achando -> procura a imagem no docker Hub ->
 achando -> faz download da imagem -> instala na maquina local -> cira um novo container e inicia.

 ### Criando imagem docker

  - Criando um arquivo dockerfile: echo . > Dockerfile

  - O Docker cria imagens automaticamente lendo as instruções de um Dockerfile - um arquivo de texto que contém todos os comandos, em ordem, necessários para construir uma determinada imagem.

  - Exemplo de comandos que fica dentro do arquivo "dockerfile" que cria a imagem.

<blockquete>

        FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
        WORKDIR /src
        COPY DemoMicroservice.csproj .
        RUN dotnet restore
        COPY . .
        RUN dotnet publish -c release -o /app

        FROM mcr.microsoft.com/dotnet/aspnet:7.0
        WORKDIR /app
        COPY --from=build /app .
        ENTRYPOINT ["dotnet","DemoMicroservice.dll"]       

</blockquete>

 - FROM: Cria uma camada a partir da imagem do .net core sdk 7.0
 - WORKDIR: Define o diretório de trabalho de um contêiner do Docker a qualquer momento.
 - COPY: Adiciona arquivos do diretório atual do cliente do Docker.
 - RUN: Constrói sua aplicação com make.
 - CMD: Especifica qual comando deve ser executado no contêiner.
 - ENTRYPOINT: Informa ao Docker para configurar o contêiner para ser executado como um executável.

 ### Comando que executa o arquivo dockerfile

  - O comando docker build constroi uma imagem a partir de um Dockerfile e de um contexto.

<blockquete>

        docker build -t DemoMicroservice:0.1 -f DemoMicroservice/Dockerfile

</blockquete>

 - -t demomicroservice: Informa para marcar(ou nomear) a imagem como demomicroservice.

 - O parêmetro final(.): Informa qual diretorio usar para localizar o dockerfile(. define o diretorio atual).

 ### Criando um container

 - digita o comando "docker run", cria um nome para o container, e informa a porta, depois informa o nome da imagem.

<blockquete>

        docker run --name webcontainer -p 5000:80 demomicroservice:0.1
 
</blockquete>

# Docker sem o arquivo "dockerfile"

 - Cria a solução depois o projeto.

 - Digite o comando para instalar a extenção que vai fazer executar o docker sem arquivo dockerfile.

<blockquete>

                dotnet add package Microsoft.NET.Build.Containers
 
</blockquete>

 - No csproj, informa que foi adicionado o pacote.  

<blockquete>

                <ItemGroup>
                <PackageReference Include="Microsoft.NET.Build.Containers" Version="7.0.401" />
                </ItemGroup>
 
</blockquete>

 - Executa o comando que cria a imagem, usando esse pacote.

<blockquete>

                dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer
 
</blockquete>

 - Assim é criada a imagem.
 - Depois disso cria o container.

<blockquete>

                docker run --name testecontainer -p 5000:86 projeto01:1.0.0
 
</blockquete>

- Caminho do site: http://localhost:5000/weatherforecast

- No arquivo csproj, pode por a configuração dentro da tag "PropertyGroup", para reduzir o comando.

<blockquete>

                <PublishProfile>DefaultContainer</PublishProfile>
                <ContainerImageName>projeto01</ContainerImageName>
                <ContainerImageTag>1.0.0</ContainerImageTag>
 
</blockquete>

 - O comando que cria a imagem fica curto

<blockquete>

                dotnet publish --os linux --arch x64
 
</blockquete>

 - Pode definir a imagem base.

<blockquete>

                <ContainerBaseImage>mcr.microsoft.com/dotnet/aspnet:7.0-alpine</ContainerBaseImage>
 
</blockquete>

# NET - Criando Microsserviços : API Catalogo com MongoDB - I

 ### Objetivo:

 - Cria um API para um gerenciar produtos como um microsserviço

 ### Pré-requisitos: 
 
 - Noções de C#, ASP .NET Core e Docker

 ### Cenário:

 - Criar uma Asp.Net Core Web API.
 - Segindo o estilo REST(API REST).
 - Realizar consultas e operações CRUD em produtos.
 - Usar banco de dados NoSQL MongoDB em um contêiner Docker.
 - Usar o padrão repositório.
 - Conteinerizar a API com o MongoDB usando o Docker Compose.

 ### MongoDB

    SGBD relacional  | MongoDB 
 __________________________________ 
    Table            | Collection
    Row              | Document
    Column           | Field

 - Instala a extenção do mongoDB

 - 

<blockquete>

                MongoDB.Driver
 
</blockquete>

 - Cria a pasta "Entities" e a classe "Product".

<blockquete>

                public class Product
                {
                [BsonId]
                [BsonRepresentation(BsonType.ObjectId)]
                public string Id { get; set; }

                [BsonElement("Name")]
                public string Name { get; set; }
                public string Category { get; set; }
                public string Description { get; set; }
                public string Image { get; set; }
                public decimal Price { get; set; }

                }
 
</blockquete>

 - Cria uma pasta chamada "Data" e uma Interface chamada "ICatalogContext". 

<blockquete>

                public interface ICatalogContext
                {
                        IMongoCollection<Product> Products { get; }
                }
 
</blockquete>

 - Cria um classe chamada "CatalogContext" na pasta "Data" para implementar a interface.

 - Configurando a connection string, nome do banco, e nome da coleção(Tabela)

<blockquete>

        public class CatalogContext : ICatalogContext
        {
                public CatalogContext(IConfiguration configuration)
                {
                        // Configurando a conexionstring
                        var client = new MongoClient(configuration.GetValue<string>
                        ("DatabaseSettings:ConnectionString"));

                        // Nome do banco de dados
                        var database = client.GetDatabase(configuration.GetValue<string>
                        ("DatabaseSettings:DatabaseName"));

                        // Nome da coleção
                        Products = database.GetCollection<Product>(configuration.GetValue<string>
                        ("DatabaseSettings:CollectionName"));

                        //CatalogContextSeed.SeedData(Products);
                }

                public IMongoCollection<Product> Products { get; }
        }
 
</blockquete>

 - 

<blockquete>

 
</blockquete>

 - 

<blockquete>

 
</blockquete>








