# ProjMovies
* Tela de Filmes
<img src="./Movies.png" />

Para rodar o projeto é necessário:
-----------
* .net core 3.0
* Node
* Sql Server Express
* Ajustar a connectionstring no arquivo app.settings do projeto Web (banco rordando local)

* Executar os comando a seguir no terminal dentro da pasta raíz do projeto.

* Restaura os pacotes NPM e dar Build nos projetos, executando o comando abaixo:
```
dotnet build
```
* Criar a Base de Dados executando o comando abaico:
```
dotnet ef database update -p src/Infrastructure/ -s src/Web/ -v
```
* Rodar projeto executando o comando abaixo:
```
dotnet run -p src/Web/
```
* Após isso, abrir a url [http://localhost:5000](http://localhost:5000) no navegador de sua preferência.
