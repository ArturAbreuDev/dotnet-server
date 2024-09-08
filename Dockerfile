# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie o arquivo .csproj e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o restante do código e faça o build
COPY . ./
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Defina o comando de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "MarketVotingSystem.dll"]
