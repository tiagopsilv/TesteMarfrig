# Sistema de Compra de Gado

Avaliação Técnica - Desenvolvedor .NET - Marfrig

Sistema de Compra de Gado é um sistema que possíbilita a manuteção dessa operação.

Funções:
Pesquisar Compras
Imprimir
Adicionar
Alterar
Excluir

O sitema é dividido em 5 camadas

0 - Presentation - WPF
1 - Services - WEB API
2 - Application - Class Library
3 - Domain - Class Library
4 - Infra - Class Library
5 - Test - XUnit

## Installation

Antes de iniciar é necessário executar os scripts do arquivo dbo.Base.sql, alterar os endereços de Endpoint e ConnectionStrings

Arquivo dbo.Base.sql: Executar as querys desse arquivo no Banco SQL Server.

Endpoint: A informação do Endpoint para acessar a WEB API está no arquivo App.config na camada "0 - Presentation", Tag configuration -> appSettings a Key é Endpoint_WebApi. Para alterar o Endpoint é o campo value

ConnectionStrings: A informação do ConnectionStrings com as configurações de acesso ao Banco SQL está no arquivo appsettings.json na camada "4 - Infra / 4.1 Data", campo ConnectionStrings.

## Usage

A Camada "0 - Presentation" é WPF, podenado ser executar no Windows.
A Camada "1 - Services" é um WebService, sendo necessário a sua configuração no ISS, juntamento com as biblioteca necessário para o projeto.

## Contributing

Criação do projeto Tiago Pereira da Silva - https://www.linkedin.com/in/tiagopsilvatec/

## License
Tiago Pereira da Silva - https://www.linkedin.com/in/tiagopsilvatec/
