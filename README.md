# Projeto SenaTur  
  
Um sistema de cadastro de pacotes turísticos , não tem qualquer interface (é a penas um API que retorna e recebe JSON) feito para a empresa fantasma **SenaTur**.  
Atenção  : para que tudo funcione , por favor siga a ordem que está no sumário  
  
## Sumário  
- 1 [Informações](#Informações)
 - 1.1 [Programas utilizados](#Programas-utilizados)
 - 1.2 [Bibliotecas](#Bibliotecas)
- 2 [Banco de dados](#Banco-de-dados)  
 - 2.1 [Criação](#Criação)  
 - 2.2 [Valores Iniciais](#Valores-iniciais)  
- 3 [API](#API)  
 - 3.1 [Paginas](#Paginas)  
 - 3.2 [Autenticação](#Autenticação)  
  
## Informações  
Aqui ficará algums informações do projeto como os programas que utilizei para criar e testar a API e as bibliotecas que precisei importar.  
### Programas utilizados  

- VisualStudio (2017)  
- SQL Server 2014 Management Studio  
- Postman (Desktop Version)  
  
### Bibliotecas  
 
 - **Microsoft.EntityFrameworkCore** (2.1.1)  
 - **Microsoft.EntityFrameworkCore.SqlServer** (2.1.1)  
 - **Microsoft.EntityFrameworkCore.Design** (2.1.1)  
 - **Microsoft.EntityFrameworkCore.Tools** (2.1.1)  
 - **Swashbuckle.AspNetCore** (4.0.1)  
 
## Banco de dados  
Primeiramente você terá que alterar alguns valores em [SenaturContext.cs](#) : No metodo **OnConfiguring** :  
```csharp
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			 optionsBuilder.UseSqlServer(
                "Data Source =.\\[NOMESERVIDOR]; initial catalog = Senatur_Manha; user id = sa; pwd = 132"
            );
			// No lugar de [NOMESERVIDOR] coloque o nome da sua instancia do SQL Server 
			// initial catalog seria o banco de dados que ele irá iniciar usando
			// user id é o seu usuario administrador do banco de dados
			// pwd é a senha do usuario administrador 
			//  Caso seu banco não precise de login para abrir utilize -> Integrated Security=SSPI 
			// no lugar de user id = sa; pwd = 132
            base.OnConfiguring(optionsBuilder);
        }
```
### Criação  
Pra criar o banco de dados você só vai precisar utilizar 2 comandos , ja que os **Domains** já estão criados e o **Context** Tambem.  
  
**Primeiro Comando **   
Cria arquivos de migração do banco de dados
```shell
Add-Migration Senaitur_Manha
```  
**Segundo comando**  
Cria o banco de dados no SQL Server
```shell
Update-Database
```
Depois disso, verifique o banco de dados no SQL Server e o banco vai estar criado  
### Valores iniciais  

## API  

### Paginas  

### Autenticação  