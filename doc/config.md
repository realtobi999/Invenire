# Konfigurace aplikace

>⚠️ **Důležité:** Tento repositář je **frontend** část aplikace Invenire. Repositář **backendu** je přístupný přes prokliknutí [zde](https://github.com/realtobi999/InvenireServer).

## 1. Backend

### 1.1 Backend v Dockeru

Docker běh backendu používá soubor `.env`.

#### Povinné proměnné v `backend/.env`

| Proměnná | Účel | Příklad |
|---|---|---|
| `ASPNETCORE_ENVIRONMENT` | prostředí aplikace | `Development` |
| `API_PORT` | port API (host + kontejner) | `5071` |
| `POSTGRES_HOST_PORT` | port PostgreSQL na hostu | `5433` |
| `POSTGRES_PORT` | port PostgreSQL v kontejneru | `5432` |
| `POSTGRES_USER` | název uživatele databáze | `invenire` |
| `POSTGRES_PASSWORD` | heslo uživatele databáze | `change_me` |
| `POSTGRES_DB` | název databáze aplikace | `InvenireServerDatabase` |
| `ConnectionStrings__Connection` | connection string pro dotnet | `Host=postgres;Port=5432;...` |
| `Jwt__Issuer` | JWT issuer | `Invenire` |
| `Jwt__SigningKey` | JWT podpisový (privátní) klíč | `long_random_secret` |
| `Jwt__ExpirationTime` | JWT expirace (minuty) | `3000000` |
| `SMTP__Host` | SMTP server | `smtp.ethereal.email` |
| `SMTP__Port` | SMTP port | `587` |
| `SMTP__Username` | SMTP uživatel | `change_me` |
| `SMTP__Password` | SMTP heslo | `change_me` |

#### Volitelné override proměnné

Tyto hodnoty jsou defaultně nastaveny v `src/InvenireServer.Presentation/appsettings.json`,  ale doporučuje se je nastavit explicitně při změně domény nebo portů:

| Proměnná | Účel | Příklad |
|---|---|---|
| `Frontend__BaseAddress` | adresa frontendu pro odkazy v e-mailech | `http://127.0.0.1:5170` |
| `CORS__AllowedOrigins__0` | první povolený origin | `http://127.0.0.1:5170` |
| `CORS__AllowedOrigins__1` | druhý povolený origin | `http://localhost:5170` |

#### Vzor `.env`

```env
ASPNETCORE_ENVIRONMENT=Development

API_PORT=5071
POSTGRES_HOST_PORT=5433
POSTGRES_PORT=5432

POSTGRES_USER=invenire
POSTGRES_PASSWORD=change_me_to_strong_password
POSTGRES_DB=InvenireServerDatabase

ConnectionStrings__Connection=Host=postgres;Port=5432;Database=InvenireServerDatabase;Username=invenire;Password=change_me_to_strong_password

Jwt__Issuer=Invenire
Jwt__SigningKey=change_me_to_long_random_value
Jwt__ExpirationTime=3000000

SMTP__Host=smtp.ethereal.email
SMTP__Port=587
SMTP__Username=change_me
SMTP__Password=change_me
---
```

#### Vzor `appsettings.json`

```json
{
    "Frontend": {
        "BaseAddress": "http://127.0.0.1:5170"
    },
    "CORS": {
        "AllowedOrigins": [
            "http://127.0.0.1:5170",
            "http://localhost:5170"
        ]
    }
}
```

### 1.2 Backend manuálně (`dotnet run`)

Při manuálním běhu se povinné proměnné ukládají do **User Secrets**, ne do `.env`. Mimo to se nic, co se týče konfigurace nemění.

#### Důležité hodnoty z `backend/src/InvenireServer.Presentation/Properties/launchSettings.json`

Pro manuální běh backendu jsou důležité pouze tyto hodnoty:

| Proměnná | Hodnota (aktuálně v backendu) |
|---|---|
| `applicationUrl` | `http://localhost:5071` (profil `http`), `https://localhost:7086;http://localhost:5071` (profil `https`) |
| `ASPNETCORE_ENVIRONMENT` | `Development` |

#### vzor `secrets.json`

```json
{
  "ConnectionStrings": {
    "Connection": "Host=127.0.0.1;Port=5432;Database=InvenireServerDatabase;Username=YOUR_USER;Password=YOUR_PASSWORD"
  },
  "Jwt": {
    "Issuer": "Invenire",
    "SigningKey": "CHANGE_ME_TO_LONG_RANDOM_VALUE",
    "ExpirationTime": "3000000"
  },
  "SMTP": {
    "Host": "smtp.ethereal.email",
    "Port": "587",
    "Username": "YOUR_SMTP_USERNAME",
    "Password": "YOUR_SMTP_PASSWORD"
  }
}
```

## 2. Frontend

### 2.1 Frontend v Dockeru

Docker běh frontendu používá soubor `src/wwwroot/appsettings.json`.

#### Povinné proměnné v `appsettings.json`

| Klíč | Účel | Příklad |
|---|---|---|
| `ApiConfiguration:BaseAddress` | URL backend API | `http://127.0.0.1:5071/` |

#### vzor `appsettings.json`

```json
{
  "ApiConfiguration": {
    "BaseAddress": "http://127.0.0.1:5071/"
  }
}
```

---

### 2.2 Frontend manuálně (`dotnet run`)

Konfigurace povinných proměnných je stejná jako při běžení s Dockerem.

#### Volitelné override proměnné

Tyto hodnoty jsou defaultně nastaveny v `src/Properties/launchSettings.json`,  ale doporučuje se je nastavit explicitně při změně domény nebo portů:

| Proměnná | Účel | Příklad |
|---|---|---|
| `ASPNETCORE_ENVIRONMENT` | prostředí aplikace | `Development` |
| `applicationUrl` | adresa frontendu | `http://127.0.0.1:5170` |

#### vzor `launchSettings.json`

```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      "applicationUrl": "http://localhost:5170",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## 3. Kontrolní seznam funkční aplikace

1. Backend běží na stejné URL, jakou má frontend v `ApiConfiguration:BaseAddress`.
2. Backend CORS obsahuje frontend adresu (`http://127.0.0.1:5170` a/nebo `http://localhost:5170`).
3. `Frontend:BaseAddress` na backendu odpovídá adrese frontendu.
4. Databáze je dostupná podle `ConnectionStrings:Connection`.
5. `GET http://127.0.0.1:5071/api/server/health-check` vrací `200 OK`.
