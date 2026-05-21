# Ejecutar Shopping en local con Docker

Stack: **SQL Server** (contenedor `db`) + **aplicación ASP.NET** (contenedor `web`).

Las imágenes se guardan en disco dentro del contenedor web (`wwwroot/blob`), sin Azure.

## Requisitos

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) en Windows

## Arrancar

Desde la raíz del repositorio (recomendado):

```powershell
.\run-docker.ps1
```

O manualmente:

```powershell
dotnet publish Shopping/Shopping/Shopping.csproj -c Release -r linux-x64 --self-contained true -o Shopping/Shopping/publish
docker compose up --build -d
```

La primera vez puede tardar varios minutos (descarga de imágenes + seed de datos).

## Usar la aplicación

- URL: http://localhost:8081
- SQL Server (desde el host): `localhost,1433` — usuario `sa`, contraseña `Shopping@Local123`

### Usuarios de prueba (seed)

| Email | Contraseña | Rol |
|-------|------------|-----|
| zulu@yopmail.com | 123456 | Admin |
| ledys@yopmail.com | 123456 | User |

## Comandos útiles

```powershell
# Detener
docker compose down

# Detener y borrar la base de datos
docker compose down -v

# Ver logs de la app
docker compose logs -f web
```

## Notas

- El correo no está configurado para envío real en Docker; el registro con confirmación por email está deshabilitado en ese entorno.
- Si cambias el puerto, actualiza `Blob__PublicBaseUrl` en `docker-compose.yml`.
