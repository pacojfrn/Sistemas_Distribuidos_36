FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:80
WORKDIR /tmp
RUN echo "Jorge Francisco Acosta Alcalá" > /tmp/numeroAlumno.txt
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG configuration=Release
WORKDIR /src
COPY ["FileDownload.csproj","./"]
RUN dotnet restore "FileDownload.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FileDownload.csproj" -c $configuration -o /app/build


FROM build as publish
ARG configuration=Release
RUN dotnet publish "FileDownload.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
USER app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","FileDownload.dll" ]