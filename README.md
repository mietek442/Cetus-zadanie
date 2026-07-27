![Cetus API Logo](your-image-path.png)
Zadanie Rekrutacyjne


# Wersja API na serwerze (v1.5)

[Przejdź do dokumentacji aplikacji](https://cetuspro.jakubchrzastek.pl/swagger/index.html)



Aplikacja zarządzania stanowiskami biurowymi oraz procesem ich rezerwacji. System umożliwia pełną obsługę stanowisk pracy, zarządzanie rezerwacjami oraz wykorzystuje agenta AI do inteligentnego dopasowania stanowiska na podstawie preferencji użytkownika.

Celem projektu jest stworzenie kompletnego systemu rezerwacji stanowisk biurowych posiadającego wszystkie najważniejsze funkcjonalności wymagane do codziennego zarządzania przestrzenią pracy.


## Technologies Used

- CQRS ✔️
- Vertical Architecture ✔️
- Dotnet Entity Framework Core ✔️
- ASP.NET Core Identity in .NET 8 ✔️
- Fluent Validator ✔️
- Docker ✔️
- AI Agent for workstation recommendation ✔️


# Main Functionalities


## Workstations (Stanowiska biurowe)

System umożliwia pełne zarządzanie stanowiskami biurowymi:

- Dodawanie nowych stanowisk
- Pobieranie listy stanowisk
- Pobieranie stanowiska po ID
- Edycja danych stanowiska
- Usuwanie stanowiska


## Reservations (Rezerwacje)

System obsługuje proces rezerwacji stanowisk:

- Dodawanie rezerwacji
- Edycja rezerwacji
- Usuwanie rezerwacji
- Aktualizacja statusu rezerwacji
- Pobieranie informacji o rezerwacjach


## AI Agent

Aplikacja posiada agenta AI odpowiedzialnego za dobór stanowiska zgodnie z wymaganiami użytkownika.

Funkcjonalność umożliwia:

- Przyjęcie preferencji użytkownika dotyczących stanowiska
- Analizę wymagań użytkownika
- Dopasowanie najlepszego dostępnego stanowiska
- Zwrócenie identyfikatora stanowiska spełniającego wymagania


# Endpoints Overview

- **Workstations**: Create, Get All, Get by ID, Update, Delete
- **Reservations**: Create, Edit, Delete, Update Status, Get All
- **Users**: Register, Login, Logout, Get Logged-in User
- **AI Agent**: Find workstation based on user preferences


# How to Run


```bash
dotnet ef migrations add Init
dotnet ef database drop
dotnet ef database update
```


Przed wykonaniem migracji należy upewnić się, że connection string w pliku `appsettings.json` wskazuje na odpowiednią bazę danych.

Po zakończeniu procesu migracji należy przywrócić właściwą konfigurację połączenia z bazą danych.


# Docker Guid in English:

# Docker Poradnik po polsku:


Logowanie dockera za pomocą komendy:

```docker command
docker login -u uzytkownik -p haslo
```


Wylogowanie się z dockera za pomocą komendy:

```docker command
docker logout
```


## Budowanie dockera:


```docker command
docker build -t mietek442/cetus:1.0 .
```


Opis:

- `docker build` - służy do budowania obrazu Docker.
- `-t` - pozwala nadać nazwę oraz wersję obrazu.
- `mietek442/cetus` - nazwa repozytorium według konwencji Docker Hub (`nazwa_użytkownika/nazwa_aplikacji`).
- `1.0` - wersja obrazu.


# Opcjonalne kroki

Do wykonania poniższych operacji wymagane jest konto Docker Hub.

Tworzymy repozytorium Docker Hub.

Przykładowa nazwa:

```
mietek442/cetus
```


## Push dockera:


```docker command
docker push mietek442/cetus:1.0
```


Opis:

- `docker push` - wysyła obraz Docker do repozytorium.
- `mietek442/cetus` - nazwa repozytorium.
- `1.0` - wersja obrazu.


## Pull dockera:


```docker command
docker pull mietek442/cetus:1.0
```


Opis:

- Pobiera obraz Docker z repozytorium Docker Hub.


# Uruchomienie dockera


Pokazanie listy obrazów:

```docker command
docker images
```


- Wyświetla listę dostępnych obrazów Docker wraz z nazwą, tagiem oraz identyfikatorem.


## Uruchomienie dockera:


```docker command
docker run -d -p 8808:8080 c429c59dae79
```


Opis:

- `docker run` - uruchamia kontener Docker.
- `-d` - uruchamia kontener w tle.
- `-p` - odpowiada za mapowanie portów pomiędzy komputerem a kontenerem.
- `8808` - port dostępny lokalnie na komputerze użytkownika.
- `8080` - port aplikacji działającej wewnątrz kontenera.
- `c429c59dae79` - identyfikator obrazu Docker.


Pokazanie listy uruchomionych kontenerów:


```docker command
docker ps
```


- Wyświetla listę aktywnych kontenerów wraz z ich identyfikatorem, nazwą obrazu oraz statusem działania.


# Zaawansowane techniki Dockera


Automatyczne usunięcie kontenera:


```docker command
docker run --rm
```


- Parametr `--rm` powoduje automatyczne usunięcie kontenera po jego zatrzymaniu.


Uruchomienie kontenera w trybie tylko do odczytu:


```docker command
docker run --read-only my_image
```


- Parametr `--read-only` blokuje możliwość modyfikowania systemu plików kontenera.


# Ograniczenie zasobów kontenera:


```docker command
docker run --memory="150m" --cpus="0.2"
```


Opis:

- `--memory="150m"` - ogranicza wykorzystanie pamięci RAM do 150 MB.
- `--cpus="0.2"` - ogranicza wykorzystanie procesora do 20% jednego rdzenia.


# DockerFile


Przykład wykorzystania użytkownika aplikacji:


```docker file command
USER app
```


Instrukcja `USER app` powoduje uruchomienie aplikacji z wykorzystaniem ograniczonego użytkownika zamiast konta root.

Pozwala to zwiększyć bezpieczeństwo aplikacji poprzez ograniczenie możliwości wykonywania nieautoryzowanych operacji.




RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
```
