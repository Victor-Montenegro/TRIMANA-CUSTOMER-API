# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY TRIMANA.Customer.sln .
COPY TRIMANA.Customer.Api/*.csproj ./TRIMANA.Customer.Api/
COPY TRIMANA.Customer.Domain/*.csproj ./TRIMANA.Customer.Domain/
COPY TRIMANA.Customer.Application/*.csproj ./TRIMANA.Customer.Application/
RUN dotnet restore

# copy everything else and build app
COPY TRIMANA.Customer.Api/. ./TRIMANA.Customer.Api/
COPY TRIMANA.Customer.Domain/. ./TRIMANA.Customer.Domain/
WORKDIR /source/TRIMANA.Customer.Api
RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /source/TRIMANA.Customer.Api/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "TRIMANA.Customer.Api.dll"]