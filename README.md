# Projeto Jogo da Forca - AdaTech

Este é um projeto de implementação do jogo da forca desenvolvido no âmbito do curso AdaTech. O jogo é destinado a fins educativos e tem como objetivo praticar conceitos de programação em C#.

## Estrutura do Projeto

O projeto é dividido em dois namespaces principais:

1. **ProjetoFinalAdaTech.JogoDaForca**
   - **ColetarDados.cs**: Responsável por ler os dados do arquivo de palavras e categorias, organizando-os em um dicionário.
   - **InteracaoUsuario.cs**: Implementa a interação com o usuário durante o jogo, apresentando mensagens, recebendo entradas e controlando a lógica do jogo.

2. **ProjetoFinalAdaTech.JogoDaForca.Tests**
   - **ColetarDadosTests.cs**: Contém testes unitários para a classe `ColetarDados`.
   - **InteracaoUsuarioTests.cs**: Contém testes unitários para a classe `InteracaoUsuario`.

## Funcionamento do Jogo

O jogo é iniciado chamando o método `MetodoPrincipal` da classe `ColetarDados`, que por sua vez lê as palavras e categorias de um arquivo e inicia a interação com o usuário.

Durante a interação, o jogador recebe mensagens de saudação, informações sobre a categoria e a palavra a ser adivinhada. O jogador pode tentar adivinhar letras ou a palavra completa (sendo obrigatório advinhar a plavra completa faltando duas letras para encerrar.

O jogo continua até que o jogador acerte a palavra ou erre o número máximo permitido de vezes (6 erros).

## Como Jogar

1. Execute o projeto.
2. Siga as instruções apresentadas no console para tentar adivinhar a palavra.

## Requisitos

- .NET Core SDK instalado para compilar e executar o projeto.

## Execução dos Testes

1. Abra o terminal na pasta do projeto.
2. Navegue até a pasta do projeto de testes usando o comando `cd ProjetoFinalAdaTech.JogoDaForca.Tests`.
3. Execute os testes com o comando `dotnet test`.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para criar _issues_ para sugestões ou reportar problemas. Se desejar contribuir com código, crie um _fork_ do projeto, faça as alterações desejadas e envie um _pull request_.


**Divirta-se jogando o Jogo da Forca!**# ProjetoFinalAdaTech-Modulo1
