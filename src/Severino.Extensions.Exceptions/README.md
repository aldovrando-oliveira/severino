# Severino.Extensions.Exceptions
Biblioteca com exceções customizadas e extensões para auxiliar na utilização.

## Instalação
O pacote está disponível no Nuget: `Severino.Extensions.Exceptions`

Para instalar a última basta utilizar o comando abaixo.
```bash
dotnet add package Severino.Extensions.Exceptions
```

## Como utilizar

### Criando novas exceções
Todas as exceções possuem diversos construtores, basta utilizar o construtor que atende à necessidade do cenário. Por Exemplo

```c#
using System;
using Severino.Extensions.Extensions;

namespsace AppTest
{
    public static class Program
    {
        public static void Main()
        {
            var exception = new EntityNotFoundException("Product", "#ABC500");
            
            // throw exception;
            
            Console.WriteLine($"Entity....: {exception.Entity}");
            Console.WriteLine($"ErrorCode.: {exception.ErrorCode}");
            Console.WriteLine($"Message...: {exception.Message}";
            
            // Saida:
            // ========================= 
            // Entity....: Product
            // ErrorCode.: #ABC500
            // Message...: #ABC500 - Product not found
        }
    }
}
```

### Convertendo exceções
Está disponível extensões para o tipo `Exception`. Elas podem ser utilizadas para facilitar a trativa e conversões das excessões.

```c#
using System;
using Severino.Extensions.Extensions;

namespsace AppTest
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                /* qualquer código aqui */
            }
            catch(Exception ex)
            {
                /* validações e tratativas */
                
                var notFoundEx = ex.ToEntityNotFoundException("Product", "#ABC500");
                

                // throw notFoundEx;
                
                Console.WriteLine($"Entity....: {notFoundEx.Entity}");
                Console.WriteLine($"ErrorCode.: {notFoundEx.ErrorCode}");
                Console.WriteLine($"Message...: {notFoundEx.Message}";
                
                // Saida:
                // ========================= 
                // Entity....: Product
                // ErrorCode.: #ABC500
                // Message...: #ABC500 - Product not found
            }
        }
    }
}
```

## Lista de Exceções

| Exceção                   | Descrição                                                                     |  
| ------------------------- | ----------------------------------------------------------------------------- |
| EntityNotFoundException   | Quando a entidade pesquisada não é encontrada                                 |
| ConflictException         | Alguma operação não pode ser executada devido a conflitos nas validações      |
| GatewayTimeoutException   | Quando ocorre timeout na integração com algum serviço                         |
| BadGatewayException       | Quando ocorrem erros na integrçaão com algum serviço                          |

## Funcionalidades

- [x] Exceções 
    - [x] Entidades não encontradas
    - [x] Conflito
    - [x] Erro no consumo de serviços
- [ ] Handler para trataiva de exceções    
