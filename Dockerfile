FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

EXPOSE 80

WORKDIR /app

# Copy everything
COPY . ./

# Build and publish a release
RUN dotnet publish ./source/Web -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/source/Web

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Web.dll"]