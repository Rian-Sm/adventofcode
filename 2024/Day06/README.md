# Day 5: Print Queue

##  Environment Variables

Antes de executar o código é necessário atualizar as variáveis de ambiente do projeto.

| Variavel | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `URL` | `string` | **Required**. URL do input do teste |
| `COOKIE` | `string` | **Required**. Parametros de sessão do seu usuário no teste |

O arquivo com as informações de variáveis de ambiente esta no path `  Properties\launchsettings.json.exemple  `

## Execution

Para inciar a execução do projeto:

```bash
  dotnet run
```

Diagrama de cardinalidade do movimento 
```c#
                     // up 1
            //  [-1,-1][-1,0][-1,1]
    //left 4    [0, -1][ 0,0][ 0,1] right2
            //  [1, -1][ 1,0][ 1,1]
                    // down 3
```