$ErrorActionPreference = "Stop"

$root = $PSScriptRoot
$project = Join-Path $root "Shopping\Shopping\Shopping.csproj"
$publishDir = Join-Path $root "Shopping\Shopping\publish"
$libsDir = Join-Path $root "Shopping\Shopping\docker-libs"

Write-Host "Preparando librerias nativas (OpenSSL/ICU)..."
if (-not (Test-Path "$libsDir\libssl.so.3")) {
    New-Item -ItemType Directory -Force -Path $libsDir | Out-Null
    $id = docker create mcr.microsoft.com/mssql/server:2022-latest
    $files = @(
        "libssl.so.3", "libcrypto.so.3",
        "libicudata.so.70.1", "libicui18n.so.70.1", "libicuuc.so.70.1",
        "libgssapi_krb5.so.2.2", "libstdc++.so.6.0.30", "libgcc_s.so.1", "libz.so.1.2.11"
    )
    foreach ($f in $files) {
        docker cp "${id}:/usr/lib/x86_64-linux-gnu/$f" "$libsDir\$f"
    }
    docker rm $id | Out-Null
}

Write-Host "Publicando aplicacion para Linux..."
if (Test-Path $publishDir) {
    Remove-Item $publishDir -Recurse -Force
}

dotnet publish $project `
    -c Release `
    -r linux-x64 `
    --self-contained true `
    -o $publishDir `
    /p:PublishTrimmed=false

Write-Host "Construyendo y levantando contenedores..."
Set-Location $root
docker compose up --build -d

Write-Host ""
Write-Host "Listo. Abre: http://localhost:8081"
Write-Host "SQL Server: localhost,1433 (sa / Shopping@Local123)"
