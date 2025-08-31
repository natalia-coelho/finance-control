FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
COPY . .
RUN dotnet restore "src/FinanceControl.Api/FinanceControl.Api.csproj"
RUN dotnet publish "src/FinanceControl.Api/FinanceControl.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "FinanceControl.Api.dll"]
