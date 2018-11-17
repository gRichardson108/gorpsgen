FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY gorpsgen/*.csproj ./gorpsgen/
#COPY utils/*.csproj ./utils/
WORKDIR /app/gorpsgen
RUN dotnet restore
RUN dotnet dev-certs https

# copy and publish app and libraries
WORKDIR /app/
COPY gorpsgen/. ./gorpsgen/
#COPY utils/. ./utils/
WORKDIR /app/gorpsgen
RUN ls -alh
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y build-essential nodejs
WORKDIR /app/gorpsgen
RUN dotnet dev-certs https
RUN dotnet publish -c Release -o out


# test application -- see: dotnet-docker-unit-testing.md
#FROM build AS testrunner
#WORKDIR /app/tests
#COPY tests/. .
#ENTRYPOINT ["dotnet", "test", "--logger:trx"]


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
ENV ASPNETCORE_URLS=https://localhost:5001
ENV ASPNETCORE_HTTPS_PORT=5001
ARG CERT_PATH_DEST=/app/cert/localhost-dev.pfx
ENV CertPath=$CERT_PATH_DEST
RUN echo "Env CertPath value is: $CertPath"
COPY localhost-dev.pfx $CertPath
WORKDIR /app
COPY --from=build /app/gorpsgen/out ./
ENTRYPOINT ["dotnet", "gorpsgen.dll"]
