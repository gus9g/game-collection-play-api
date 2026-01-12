setlocal enabledelayedexpansion
@echo off
chcp 65001 >nul

:MENU
echo ==========================
echo Migração de Banco de Dados MySQL - porta 3306:
echo 1 - Fazer nova migração(MIGRATION)
echo 2 - Fazer Build
echo 3 - Limpar projeto
echo 4 - Instalar Dotnet ef 8.0.4
echo 5 - Sair
echo ==========================
set /p comando=Escolha uma opcao: 

if "%comando%"=="1" (
    :: pede ao usuario o nome da migracao
    set /p nomeMigracao=Digite o nome da migracao: 

    echo Criando migracao: !nomeMigracao!
    dotnet ef migrations add !nomeMigracao! --output-dir Data/Migrations

    echo Aplicando migracao
    dotnet ef database update

    pause
    goto MENU
) else if "%comando%"=="2" (
    echo Executando Build...
    dotnet build
    goto MENU
) else if "%comando%"=="3" (
    echo Limpando projeto...
    dotnet clean
    rmdir /s /q bin
    rmdir /s /q obj
    goto MENU
) else if "%comando%"=="4" (
    dotnet tool uninstall --global dotnet-ef
    dotnet tool list -g
    dotnet tool install --global dotnet-ef --version 8.0.4
    goto MENU
) else if "%comando%"=="5" (
    echo Saindo...
    exit
) else (
    echo Comando nao reconhecido!
    pause
    goto MENU
)