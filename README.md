## Como Executar

Para executar este projeto localmente, siga as etapas abaixo:

### 1. Configuração inicial

Certifique-se de ter o Docker Desktop instalado em sua máquina.

### 2. Inicialização do ambiente Docker

Execute o seguinte comando na raiz do projeto para iniciar os contêineres Docker:

```bash
docker-compose up -d
```

Este comando irá criar e iniciar os contêineres necessários para o projeto, incluindo o banco de dados.

### 3. Aplicar migrações do banco de dados

Abra o Package Manager Console no Visual Studio e selecione o projeto `Infrastructure`.

Execute o seguinte comando para aplicar as migrações do banco de dados:

```bash
Add-Migration InitDatabase
Update-Database
```

### 4. Executar o projeto Web API

Inicie o projeto Web API selecionando-o como projeto de inicialização e pressionando F5 no Visual Studio.

Você também pode executar o projeto manualmente executando o seguinte comando no terminal:

```bash
dotnet run --project WebApi
```

O projeto Web API será executado e estará pronto para receber solicitações.

### 5. Acesso à API

Após seguir as etapas acima, a API estará disponível em `https://localhost:7253/swagger/index.html`.
