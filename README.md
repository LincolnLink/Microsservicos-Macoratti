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

<blockquete>

                MongoDB.Driver
 
</blockquete>

 ### Iniciando o projeto

 - Inciando a classe Product, criando configuração de conexao, inciaindo interface do contexto
 e implementando.

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


# NET - Criando Microsserviços : API Catalogo com MongoDB - II

 - Cria uma pasta chamada "Repositories", e um arquivo chamado "IProductRepository".

 - Task representa uma operação asyncrona.

<blockquete>

                public interface IProductRepository
                {

                Task<IEnumerable<Product>> GetProducts();
                        
                Task<Product> GetProduct(string id);

                Task<IEnumerable<Product>> GetProductByName(string name);

                Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

                Task CreateProduct(Product product);
                Task<bool> UpdateProduct(Product product);
                Task<bool> DeleteProduct(string id);

                }
 
</blockquete>

 - Cria uma classe chamada "ProductRepository" para implementara interface "IProductRepository"

 - No construtor faz uma injeção dedependencia do contexto.

 - bota todos os metodos com o async.

 - faz a implementação usando await, e usando metodos async.

 - 

<blockquete>

                public class ProductRepository : IProductRepository
                {
                private readonly ICatalogContext _context;
                public ProductRepository(ICatalogContext context)
                {
                        _context = context;
                }

                public async Task CreateProduct(Product product)
                {
                        await _context.Products.InsertOneAsync(product);
                }

                public async Task<bool> DeleteProduct(string id)
                {
                        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

                        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

                        return deleteResult.IsAcknowledged
                        && deleteResult.DeletedCount > 0;
                }

                public async Task<Product> GetProduct(string id)
                {
                        return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
                }

                public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
                {
                        FilterDefinition<Product> filter = Builders<Product>.Filter
                        .Eq(p => p.Category, categoryName);

                        return await _context.Products.Find(filter).ToListAsync();
                }

                public async Task<IEnumerable<Product>> GetProductByName(string name)
                {
                        FilterDefinition<Product> filter = Builders<Product>.Filter
                        .ElemMatch(p => p.Name, name);

                        return await _context.Products.Find(filter).ToListAsync();
                }

                public async Task<IEnumerable<Product>> GetProducts()
                {
                        return await _context.Products.Find(p => true).ToListAsync();
                }

                public async Task<bool> UpdateProduct(Product product)
                {
                        var updateResult = await _context.Products.ReplaceOneAsync(
                        filter: g => g.Id == product.Id, replacement: product);

                        return updateResult.IsAcknowledged
                        && updateResult.ModifiedCount > 0;
                }
        }
 
</blockquete>

 - No arquivo "appsettings", cria uma definição para a string de conexão para o MongoDB.

<blockquete>

                "DatabaseSettings": {
                "ConnectionString": "mongodb://localhost:27017",
                "DatabaseName": "CatalogDb",
                "CollectionName": "Products"    
                },

</blockquete>

 - No asp.net core 7 não tem a classe startup, então é usado a classe program.cs para por a configuração da injeção de dependencia.

 - No entanto criei um arquivo isolado para as configurações de injeção de dependencia.

<blockquete>

        namespace Catalogo.API.Configuration
        {
                public static class DependencyInjectionConfig
                {
                        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
                        {

                        services.AddScoped<ICatalogContext, CatalogContext>();
                        services.AddScoped<IProductRepository, ProductRepository>();

                        return services;
                        }
                }
        }

</blockquete>

# NET - Criando Microsserviços : API Catalogo com MongoDB - III

 - Criando o CatalogController, um CRUD no controller.

 - Aplica a injeção de dependencia.

<blockquete>

        private readonly IProductRepository _repository;

        public CatalogController(IProductRepository repository)
        {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository)); 
        }

</blockquete>

 - A classe "ControllerBase", fornece varios recursos para requisições HTTP:
  - BadRequest()
  - NotFound()
  - Ok()
  - TryUpdateModelAsync()
  - TryValidateModel()

 - O atributo "ApiController" fornece outros recursos como:
  - Valida o modelstate de modo automatico.
  - Faz a inferencia de parametros bind source.
  - Aciona automaticamente os erros de validação para o HTTP-400.
  - Não é obrigado a definir atributos como frombody, fromroot, fromforne, from service no corpo dos metodos action.


 - O atributo "[ ApiConventionTypeMatch(Type(DefaultApiConventions)) ] ":
   - Define os tipos de retornos e código status.

 - O atributo " [ ProducesResponseType ]" 
  - Define tipos de valor e código de status.
  - Ele fala que isso ja vem automatico mas mesmo assim usa. 


<blockquete>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
        var products = await _repository.GetProducts();
        return Ok(products);
        }

</blockquete>

 - Buscando pelo id

<blockquete>

                [HttpGet("{id:length(24)}", Name = "GetProduct")]
                [ProducesResponseType(StatusCodes.Status404NotFound)]
                [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
                public async Task<ActionResult<Product>> GetProductById(string id)
                {
                var product = await _repository.GetProduct(id);
                if(product is null)
                {
                        return NotFound();
                }
                return Ok(product);
                }

</blockquete>

 - Buscando pela categoria

<blockquete>

                [Route("[action]/{category}", Name = "GetProductByCategory")]
                [HttpGet]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                [ProducesResponseType(StatusCodes.Status200OK, Type =  typeof(IEnumerable<Product>))]
                public async Task<ActionResult<Product>> GetProductByCategory(string category)
                {
                if (category is null)
                        return BadRequest("Invalid category");

                var product = await _repository.GetProductByCategory(category);
                
                return Ok(product);
                }

</blockquete>

 - Método que cria

<blockquete>

                [HttpPost]
                [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]        
                public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
                {
                if (product is null)
                        return BadRequest("Invalid product");

                await _repository.CreateProduct(product);

                return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
                }

</blockquete>

 - Atualiza o valor, pode usar o "ProducesResponseType" ou o "ApiConventionMethod".

<blockquete>

                [HttpPut]
                [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
                public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
                {
                if (product is null)
                        return BadRequest("Invalid product");            

                return Ok(await _repository.UpdateProduct(product));
                }

</blockquete>

 - Metodo que deleta.

<blockquete>

                [HttpDelete("{id:lengeth(24)}", Name = "DeleteProduct")]
                [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
                public async Task<IActionResult> DeleteProductById(string id)
                {
                return Ok(await _repository.DeleteProduct(id));
                }

</blockquete>

# NET - Criando Microsserviços : API Catalogo com MongoDB - IV

 ### Configurando Docker

  - Verificar o ambiente do Docker Desktop
  - Dashboard
  - Docker CLI (PowerShell)

<blockquete>

                docker --version
                docker images
                docker ps
                docker container ks -a
                docker volume ls
                docker network ls
                
</blockquete>

 ### Baixar imagem do mongo no Docker Hub.

<blockquete>

                docker pull mongo

</blockquete>

 ### Criar e executar o contêiner mongo. 
  - run: faz o download das imagens, cria, inicializa e executa o contêiner.
  - -d: indica o modo detached, que executa o contêiner em segundo plano.
  - -p 27017:27017 - compartilha a porta 27017 do contêiner com a mesma porta do host
  - name catalogo-mongo - define o nome do contêiner.
  - mongo -nome da imagem usada para criar o contêiner.

 OBS: poderia ter o nome container, mas ele ja entende que já é um container.
 
<blockquete>

                docker run -d -p 27017:27017 --name catalog-mongo mongo

</blockquete>

 - Alternativa

<blockquete>

                docker run -v ~/docker --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=expertostech -e MONGO_INITDB_ROOT_PASSWORD=@mongo123 mongo

</blockquete>

 ### Entra no contêiner Mongo e executa alguns comandos.

  - exec -executa um comando em um contêniner em execução.
  - -it: aciona o modo iterativo e adiciona um terminal.
  - catalogo-mongo - define o nome do contêiner
  - /bin/bash - obtém um shell bash.

<blockquete>

                docker exec -it catalog-mongo /bin/bash

                mongo
                show dbs
                use ProductDb
                db.createCollection('Products')
                db.Products.insert ou db.Products.insertmany
                db.Products.remove({})

</blockquete>

 ### OBS: Deve se usado o "mongosh" é a forma mais atualizada.

 - https://www.mongodb.com/docs/mongodb-shell/install/

 - Baixar e configurar a variavel de ambiente.

<blockquete>

                docker exec -it catalog-mongo mongosh

</blockquete>

 - Comandos

<blockquete>
                 show dbs

                 // Cria banco
                 db.createCollection('Products')

                 //Cria tabela com valores.
                 db.Products.insert({"Name":"Caderno", "Category":"Material Escolar", "Image":"caderno.jpg", "Prince":7})

                 //Busca
                 db.Products.find({}).pretty()

                 // Remove
                 db.Products.remove({})

</blockquete>

 ### Adicionando docker na aplicação

 - Clica com botão direito no projeto, e escolhe, Add, depois dcoker support.

  - "Docker support" para gerar arquivo "Dockerfile".
  - "Container Orchesttrator support" para gerar o "Docker-Compose".

 ### Dockerfile
  
  - O Docker cria imagens automaticamente lendo as instruções de um Dockerfile - um arquivo de texto que contém todos os comandos, em ordem, necessários para construir uma determinada imagem. 

  - Criar imagem da aplicação ASP.NET Core Web, o ponto no final define o diretorio atual. 
 
<blockquete>

                docker build -t <nome_imagem> .

</blockquete>

 - Cria o container a partir da imagem

<blockquete>

                dcoker run <nome_container> <nome_image>

</blockquete>


# .NET - Criando Microsserviços : API Catalogo com MongoDB - V

 - Orquestração com docker-compose.

 ### Docker compose

 - É uma ferramenta usada para descrever aplicações complexas e gerenciar contêineres, redes e volumes que essa aplicações exigem para funcionar.

 - Usa um arquivo no formato YAML(extensão.yml) para configurar os serviços das aplicações.

 - Com um único comando podemos criar e inicializar todos os serviços a partir desta configuração.

 - Simplifica o processo de configuração e execução de aplicativos para que não tenhamos que digitar comandos complexos, o que pode levar a erros de configuração.

 - docker-compose.yml

<blockquete>

                version:  "3.4"
                services: Indica os serviços que serão criados Aqui definimos os contêineres usados e suasconfigurações.
                volumes: Define os recrusos usados pelos serviços.
                networks: Define os recrusos usados pelos serviços.

</blockquete>

 - docker-compose: processa o arquivo de composição.
 - -f : especifica o nome do arquivo de composição.
 - build : informa ao Docker para processar o arquivo.

<blockquete>

                docker-compose -f docker-compose.yml build

</blockquete>

 - Outros comandos do docker compose.

<blockquete>4:54

                docker-compose up -d : cria as imagens e executa os contêineres.
                docker-compose build : cria as imagens.
                docker-compose images : lista as imagens.
                docker-compose stop : para os contêineres.
                docker-compose run : executa os contêineres.
                docker-compose down : para os serviços, e limpa os contêineres, redes e imagens.

</blockquete>

 - Gerar de forma automatica, usando o  visual studio 2019

 - Opcao `Container Orchestrator Support`

  - Criar o arquivo DockerFile no projeto.
  - Criar o projeto docker-compose (docker-compose.dcproj)
   - dockerignore
   - docker-compose.yml
   - docker-compose.override.yml(complementa os substitui as configuracoes.)

- arquivo do `docker-compose.ylm`, foi adicionado informacoes do mongo e volumes

<blockquete>

                version: '3.4'

                services:
                  catalogdb:
                    image: mongo

                  catalogo.api:
                    image: ${DOCKER_REGISTRY-}catalogoapi
                    build:
                      context: .
                      dockerfile: Catalogo.API/Dockerfile

                volumes:
                  mongo_data:

</blockquete>

 - docker-compose.override.yml

 - Cria um container pro catalogodb.
 - Sempre restart.
 - Define o mapeamento das portas.
 - Mapea o volume.
 - Na Api, define o ambiente que está trabalhando.
 - Sobreescreva a DatabaseSettings!

<blockquete>

version: '3.4'

services:  
  catalogdb:
    container_name: catalogdb
    restart: always
    ports:
      - "27017:27017"
    volumes:
      - mongo_data:/data/db 

  catalogo.api:
    container_name: catalog.api
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - "DatabaseSettings:ConnectionString=mongodb://catalogdb:27017"
      - "DatabaseSettings__ConnectionString=mongodb://catalogdb:27017"
    depends_on:
     - catalogdb
    ports:
      - "8000:80"

</blockquete>

 - É importante sobreescrever, porq não existe mais o localhost, e sim a DatabaseSettings do docker.

 ### Executando manualmente

<blockquete>

                docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

</blockquete>

 - Antes de usar é sempre bom limpar primeiro o ambiente usando o comando o dashborard, pausa e deleta os container, depois seleciona todas as imagens e deleta.

 - limpa também os volumes

<blockquete>

                docker volume rm $(docker volume ls q)

</blockquete>

 # .NET - Criando Microsserviços : API Basket com Redis - VI

 # Criando outro projeto de API

  - Basket.API, usando .NET core e docker.
  - Redis e Docker na parte do Banco.

  

<blockquete>

</blockquete>


 - 

<blockquete>

</blockquete>

 -

<blockquete>

</blockquete>


 - 

<blockquete>

</blockquete>

 -

<blockquete>

</blockquete>


 - 

<blockquete>

</blockquete>

 -

<blockquete>

</blockquete>










