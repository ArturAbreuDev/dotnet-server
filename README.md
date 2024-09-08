# Market Voting System API
Este é o projeto de uma API para um sistema de votação de mercados, desenvolvida em .NET 8. A API permite que os clientes votem em seus mercados favoritos e obtenham os resultados em tempo real. O Swagger foi configurado para facilitar a exploração dos endpoints.

### Requisitos
- .NET 8 SDK
- Pacote Swashbuckle.AspNetCore para documentação com Swagger
- Ferramenta de linha de comando dotnet
## Como executar o projeto
#### Passos para executar a API:
- Clone o repositório ou baixe o projeto:

```
git clone https://github.com/ArturAbreuDev/dotnet-server
```
- Navegue até a pasta do projeto:

```
cd MarketVotingSystem
```
- Restaure os pacotes do projeto:

```
dotnet restore
```
- Execute a aplicação:

```
dotnet run
```
- Acesse a documentação do Swagger:
```
A API estará rodando em http://localhost:5000 junto com o Swagger
```


### Endpoints da API
#### POST /api/voting/vote
Este endpoint permite que um cliente vote em seu mercado favorito. Um cliente só pode votar uma vez por dia, e um mercado não pode ser eleito mais de uma vez no mesmo mês.

Exemplo de request (JSON):

```
{
  "marketId": "Zanela",
  "clientId": "Cliente123"
}
```
Respostas possíveis:

200 OK: Voto registrado com sucesso.
400 Bad Request: O cliente já votou hoje ou o mercado já foi eleito este mês.

#### GET /api/voting/results
Retorna os resultados da votação, agrupados por mercado e com o número de votos.

Exemplo de resposta (JSON):

```
[
  {
    "marketId": "Wallmart",
    "votes": 10
  },
  {
    "marketId": "Carrefour",
    "votes": 5
  }
]
```
## Destaques do código
- Validação de regras de negócios: A API implementa regras que impedem que um cliente vote mais de uma vez no mesmo dia e que o mesmo mercado seja eleito mais de uma vez por mês.
- Documentação com Swagger: O Swagger facilita a exploração dos endpoints, permitindo que você teste os métodos diretamente da interface web.
## O que poderia ser melhorado?
- Autenticação e Autorização: Implementar um sistema de autenticação para garantir que apenas usuários autorizados possam votar.
- Banco de Dados: Substituir os dados em memória por uma solução de banco de dados real (como SQL Server, PostgreSQL ou MongoDB) para persistir as informações de mercados e votos.
- Testes automatizados: Implementar testes unitários e de integração para garantir a correta funcionalidade das regras de negócio.
