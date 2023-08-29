# Microsservicos-Macoratti

 - Estudo e pesquisa sobre micros serviços com dot.net core!

# Criando o projeto web api na pasta DemoMicrosservice

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

        docker build -t demomicroservice .

</blockquete>

 - -t demomicroservice: Informa para marcar(ou nomear) a imagem como demomicroservice.

 - O parêmetro final(.): Informa qual diretorio usar para localizar o dockerfile(. define o diretorio atual).

 








