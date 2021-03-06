FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
# WORKDIR /src

# Copies the rest of our code
COPY . .
RUN echo $(ls -1 /app)
RUN dotnet restore "PdfConversion/PdfConversion.csproj"
RUN echo $(ls -1 )
RUN dotnet build "PdfConversion/PdfConversion.csproj" -c Release -o /app/build
RUN echo $(ls -1 /app/build)
RUN echo "PWD is: $PWD"

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
#WORKDIR /app
#RUN echo $(ls -1 /app)
#RUN echo $(ls -1 /app/build)
#COPY --from=build /app/build .