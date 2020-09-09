FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
WORKDIR /src

# Copies the rest of our code
COPY . .
RUN dotnet restore "PdfConversion/PdfConversion.csproj"
RUN echo $(ls -1 )
RUN dotnet build "PdfConversion/PdfConversion.csproj" -c Release -o /app/build
RUN echo $(ls -1 /app/build)

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
WORKDIR /app
COPY --from=build /app/build .