FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
WORKDIR /src

# Copies the rest of our code
COPY . .
RUN dotnet restore "PdfConversion/PdfConversion.csproj"
RUN dotnet publish "PdfConversion/PdfConversion.csproj" -c Release -o /app/build

#WORKDIR /app
#COPY --from=build /app .