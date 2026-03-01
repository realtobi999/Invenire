# Invenire

>⚠️ **Důležité:** Tento repositář je **frontend** část aplikace Invenire. Repositář **backendu** je přístupný přes prokliknutí [zde](https://github.com/realtobi999/InvenireServer).

## Obsah

- [1. O aplikaci](#1-o-aplikaci)  
- [2. Spuštění aplikace](#2-spuštění-aplikace)  
  - [2.1 Rychlý start](#21-rychlý-start)  
    - [2.1.1 Frontend](#211-frontend)  
    - [2.1.2 Backend](#212-backend)  
  - [2.2 Manuální start](#22-manualní-start)  
    - [2.2.1 Frontend](#221-frontend)  
    - [2.2.2 Backend](#222-backend)  

## 1. O aplikaci

Invenire je webová aplikace navržená pro správu majetku organizace, její zaměstnance a inventarizační procesy. Je koncipována jako modulární systém, který propojuje evidenci majetku s uživatelskými rolemi a umožňuje správci (adminovi) řídit všechny klíčové procesy od založení organizace až po archivaci inventur. Zaměstnanci mají přístup ke konkrétním položkám, které spravují, a aktivně se podílejí na inventurách pomocí skenování QR kódů.

Aplikace pracuje s dvěma hlavními rolemi. Administrátor je vlastníkem organizace a zodpovídá za vedení evidence. V systému zakládá organizaci, zve zaměstnance, vytváří majetek a nastavuje pravidla jeho správy. Zaměstnanec je uživatel, který se do organizace připojuje na základě pozvánky a může pracovat s položkami, které mu byly přiděleny, případně s inventurami, které organizace provádí.

Základní entitou systému je organizace. Organizace představuje kontejner, který sdružuje správce, zaměstnance a majetek. Každá organizace má jednoho správce a může mít více zaměstnanců. Správce je odpovědný za to, že data organizace jsou kompletní a aktuální. Zaměstnanci jsou pak přiřazováni k majetku a mohou navrhovat změny nebo potvrzovat inventury.

Dalším klíčovým prvkem je majetek. V Invenire je majetek definován jako celek, který obsahuje položky. Každá položka je konkrétní fyzická věc s identifikátory (inventární a registrační číslo), názvem, cenou, daty nákupu a prodeje, umístěním a dalšími doplňujícími údaji. Důležitou součástí modelu je i možnost přiřazení položky konkrétnímu zaměstnanci, čímž se zajišťuje odpovědnost.

S majetkem úzce souvisí návrhy změn (suggestions). Zaměstnanci mohou podávat návrhy na úpravu položek – například když zjistí, že se změnilo umístění nebo stav majetku. Administrátor má možnost tyto návrhy schválit, zamítnout nebo upravit. Tím je zajištěna kontrola a zároveň zapojení zaměstnanců do aktualizace dat.

Inventarizace je samostatný proces, který umožňuje ověřit aktuální stav majetku. Administrátor může inventuru založit, pojmenovat a definovat její popis. Inventura má stav „probíhá“ nebo „dokončeno“ a obsahuje seznam položek, které mají být zkontrolovány. Zaměstnanci pak skenují QR kódy položek, čímž se systémově zaznamená, že položka byla ověřena. Po dokončení inventury se stav uzavře a data se archivují, což umožňuje zpětné vyhodnocení.

Z hlediska použitelnosti je aplikace postavena na dashboardu, který se liší podle role. Administrátor vidí sekce pro správu organizace, majetku, návrhů a inventur. Zaměstnanec má přehled o své organizaci a o majetku, který mu byl přiřazen, případně o aktivních inventurách. Tento rozdílný pohled zajišťuje, že každý uživatel pracuje pouze s relevantními funkcemi a není zahlcen zbytečnými informacemi.

## 2. Spuštění aplikace

> ⚠️ **Důležité:** Jak nastavit jednotlivé proměnné prostředí najdete prokliknutím [zde](./doc/config.md).

### 2.1 Rychlý start

Invenire je rozdělena na dvě části: frontend (tento repozitář) a backend (repozitář `InvenireServer`, prokliknutí [zde](https://github.com/realtobi999/InvenireServer)). Každá část má vlastní konfiguraci i vlastní `docker-compose.dev.yml`, proto se spouští nezávisle v příslušném repozitáři.

> ⚠️ **Důležité:** V prohlížeči používejte lokální adresy `http://127.0.0.1:{PORT}` nebo `http://localhost:{PORT}`. Adresa `0.0.0.0` slouží pouze k naslouchání v Dockeru.

#### 2.1.1 Frontend

1. Upravte konfiguraci v `src/Properties/launchSettings.json` a `src/wwwroot/appsettings.json`.
2. Spusťte příkaz:

    ```bash
    docker compose -f docker-compose.dev.yml up --build
    ```

Frontend se spouští v tomto repozitáři. Blazor WebAssembly běží standardně na portu 5170. Frontend nepoužívá `.env` soubor, protože konfigurace se načítá z `appsettings.json` na straně klienta.

#### 2.1.2 Backend

1. Zkopírujte `.env.example` do `.env` a vyplňte hodnoty.
2. Aplikační konfigurace je v `src/InvenireServer.Presentation/appsettings.json`.
3. Spusťte příkaz:

    ```bash
    docker compose -f docker-compose.dev.yml up --build
    ```

Backend se spouští pomocí Dockeru v repozitáři `InvenireServer`, prokliknutí [zde](https://github.com/realtobi999/InvenireServer). Compose soubor definuje dvě služby: API server a databázi PostgreSQL. API běží standardně na portu 5071. PostgreSQL běží v kontejneru na portu 5432 a je přesměrována na hostitelský port 5433.

### 2.2 Manualní start

Invenire je rozdělena na dvě části: frontend (tento repozitář) a backend (repozitář `InvenireServer`, prokliknutí [zde](https://github.com/realtobi999/InvenireServer)). Každá část se i zde spouští nezávisle, ale tentokrát bez Dockeru přímo přes `dotnet`.

> ⚠️ **Důležité:** V prohlížeči používejte lokální adresy `http://127.0.0.1:{PORT}` nebo `http://localhost:{PORT}`.

#### 2.2.1 Frontend

1. Upravte konfiguraci v `src/Properties/launchSettings.json` a `src/wwwroot/appsettings.json`.
2. Spusťte frontend:

    ```bash
    cd src
    dotnet run
    ```

Frontend běží standardně na portu 5170.

#### 2.2.2 Backend

1. Backend v režimu `Development` načítá citlivé hodnoty přes `dotnet user-secrets` (ne přes `.env`).

   Nejprve inicializujte User Secrets pro projekt:

   ```bash
   dotnet user-secrets init --project src/InvenireServer.Presentation/InvenireServer.Presentation.csproj
   ```

   Tento příkaz přidá do `src/InvenireServer.Presentation/InvenireServer.Presentation.csproj` souboru  element `<UserSecretsId>`.

   Secrets lze upravit ručně v souboru `secrets.json`, který se nachází:

   - **Linux / macOS:**  
     `~/.microsoft/usersecrets/<UserSecretsId>/secrets.json`

   - **Windows:**  
     `%APPDATA%/Microsoft/UserSecrets/<UserSecretsId>/secrets.json`

   > Soubor `secrets.json` není součástí repozitáře.

2. Spusťte backend:

   ```bash
   ASPNETCORE_ENVIRONMENT=Development dotnet run --project src/InvenireServer.Presentation/InvenireServer.Presentation.csproj --urls http://127.0.0.1:5071
   ```
