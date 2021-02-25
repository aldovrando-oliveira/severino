# Severino.Extensions.Serialization

Biblioteca com Helpers para auxiliar na serialização de objetos.

## Instalação
O pacote está disponível no Nuget: `Severino.Extensions.Serialization`

Para instalar a última basta utilizar o comando abaixo.
```bash
dotnet add package Severino.Extensions.Serialization
```

## Como utilizar

### Objeto para texto

Para serializar um objeto para texto no formado JSON basta utilizar o comando `.ToJson()` em um objeto.

```c#
using Severino.Extensions.Serialization;

namespsace AppTest
{
    public class Cliente
    {
        public string Nome { get; set; }
    }
    
    public static class Program
    {
        public static void Main()
        {
            var cliente = new Cliente
            {
                Nome = "Lampião"
            };
            
            var texto = cliente.ToJson();
            
            Console.WrileLine(texto);
            // Saida: '{ "nome": "Lampião" }'
        }
    }
}
```

 É possível customer a serialização do objeto utilizando um `JsonSerializerSettings` customizado.

```c#
public static void Main()
{
    var cliente = new Cliente
    {
        Nome = "Lampião"
    };
    
    var settings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Include
    };
    var texto = cliente.ToJson(settings);

    // OU
    
    // var texto = cliente.ToJson(settings =>
    // {
    //     settings.NullValueHandling = NullValueHandling.Ignore
    // });
    
    Console.WrileLine(texto);
    // Saida: '{ "nome": "Lampião" }'
}
``` 

### Texto para objeto

Para converter texto para objeto é necessário utilizar o comando `.ToObject<T>()`, onde `T` é o tipo do objeto para o qual o texto será convertido.

```c#
using Severino.Extensions.Serialization;
using FluentAssertions; // para validação do exemplo

namespsace AppTest
{
    public class Cliente
    {
        public string Nome { get; set; }
    }
    
    public static class Program
    {
        public static void Main()
        {
            var texto = "{ \"nome\": \"Lampião\" }";
            
            var cliente = texto.ToObject<Cliente>();

            // usando FluentAssertions
            cliente.Nome.Should().Be("Lampião");            
        }
    }
}
```

Também é possível customizar as configurações de conversão utilizando um `JsonSerializerSettings`.

```c#
public static void Main()
{
    var texto = "{ \"nome\": \"Lampião\" }";

    var settings = new JsonSerializerSettings
    {
        MissingMemberHandling = MissingMemberHandling.Error
    };

    var cliente = cliente.ToObject<Cliente>(settings);
    
    // OU
    
    // var cliente = texto.ToObject<Cliente>(settings =>
    // {
    //     settings.MissingMemberHandling = MissingMemberHandling.Error
    // });

    // usando FluentAssertions
    cliente.Nome.Should().Be("Lampião");            
}
```
## Funcionalidades

- [x] Objeto para json (configuração padrão)
- [x] Objeto para json (configuração customizada)
- [x] Texto em json para objeto (configuração padrão)
- [x] Texto em json para objeto (configuração customizada)
- [ ] Objeto para XML 
- [ ] Texto em XML para objeto
- [ ] Arquivo json para objeto
- [ ] Arquivo XML para objeto

## Dependências

- [Newtonsoft](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3)    
