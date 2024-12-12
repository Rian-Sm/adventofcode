# Day 6: Guard Gallivant

##  Environment Variables

Antes de executar o código é necessário atualizar as variáveis de ambiente do projeto.

| Variavel | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `URL` | `string` | **Required**. URL do input do teste |
| `COOKIE` | `string` | **Required**. Parametros de sessão do seu usuário no teste |

O arquivo com as informações de variáveis de ambiente esta no path `  Properties\launchsettings.json.exemple`


## Configuração para teste de requisição direta

É necessário um arquivo `  StaticFiles\mapTest.txt` com o input do AOC do dia 6 

## Execution

Para teste das classes

```bash
  dotnet test
```