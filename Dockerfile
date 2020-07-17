FROM  mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
# Create an /app directory as a root folder
WORKDIR /app 
LABEL Renan Rosa

# copy csproj and restore as distinct layers
COPY ./Fiado/Fiado.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
#Build the project and then exporti to ./web/out 
RUN dotnet publish "./Fiado/Fiado.csproj" -c Release -o out 

#Generate runtime image. We just need the runtime.
FROM  mcr.microsoft.com/dotnet/core/sdk:2.2 
WORKDIR /app
COPY --from=build-env /app/Fiado/out .
EXPOSE 80
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Fiado.dll
