# Veículos na Web

Projeto demonstrativo afim de estdos utilizando a plataforma .net core. Esse projeto é composto por:
 *Aplicação web MVC utilizando temple MVC
 *Aplicação de dominio com banco de dados MySQL
 *Projeto de teste com xUnit
 *Projeto de utilitarios.

# Configuração de Banco 
    usuario=dev01
    senha=D&senv963
    database=veiculo_web
Essas são as configuração padrão do banco de dados, podendo ser alterada no projeto de dominio na classe "ConfiguracaoDB"

# Compilando Projeto (dotnet CLI)
Na compilação via CLI todos os comandos executado está sendo basedo pela pasta raiz do projeto.

# Preparando a Aplicação
    dotnet clean

# Executando Migrations
    cd Veiculos.Web/
    dotnet ef database update -p "../Veiculos.Dominio/Veiculos.Dominio.csproj"
Lembrando que para a execução do segundo comando deve ter instalado a referencia de ferramentas do Entity Framework Core na CLI do .net.
Para realizar esse processo pode ser excutado o seguinte comando: dotnet tool install --global dotnet-ef   

# Executando Teste
    cd Veiculos.Teste.Dominio/
    dotnet test

# Executando Aplicação Web    
    cd Veiculos.Web/
    dotnet build
    dotnet run


