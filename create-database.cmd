
@echo off
chcp 65001 >nul

:MENU
echo ==========================
echo Migração de Banco de Dados MySQL - porta 33066:
echo 1 - Executar criação
echo 2 - Tratar erro de 'Não foi possível executar porque o comando ou arquivo especificado não foi encontrado.'
echo 3 - Sair
echo ==========================
set /p comando=Escolha uma opcao: 

if "%comando%"=="1" (
    echo Criando migração dotnet
    dotnet ef migrations add InitialCreate --output-dir Data/Migrations
    echo executando migração
    dotnet ef database update
    pause
    goto MENU
) else if "%comando%"=="2" (
    echo Instalando ferramenta
    dotnet tool install --global dotnet-ef
    pause
    goto MENU
) else if "%comando%"=="3" (
    echo Saindo...
    exit
) else (
    echo Comando nao reconhecido!
    pause
    goto MENU
)





dotnet tool install --global dotnet-ef
