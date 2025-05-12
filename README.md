# Questionário Target - Soluções em C\#

Este repositório contém as soluções em C# para o questionário proposto, com cinco exercícios diferentes:

## Conteúdo

* **Solucoes.cs**: Arquivo principal (`Program.cs` no projeto) contendo as implementações das questões:

  1. Cálculo da soma de números de 1 a um índice dado.
  2. Verificação de pertencimento de um número à sequência de Fibonacci.
  3. Análise de faturamento diário de uma distribuidora (menor, maior e dias acima da média), a partir de um arquivo JSON.
  4. Cálculo de percentual de representação de faturamento por estado.
  5. Inversão de caracteres de uma string sem usar funções prontas.

* **faturamento.json**: Exemplo de dados de faturamento diário usado na Questão 3.

* **questionario-target.csproj**: Arquivo de projeto .NET para compilação e execução.

## Pré-requisitos

* [.NET SDK 6.0+](https://dotnet.microsoft.com/download) instalado na máquina.

## Como executar

1. Abra um terminal na raiz do projeto.

2. Restaure dependências e execute o programa com:

   ```bash
   dotnet run
   ```

3. A saída no console mostrará o resultado de cada questão.

> **Dica:** Para testar diferentes entradas, edite as variáveis *numero* (Questão 2), o caminho/arquivo JSON (Questão 3) ou a string definida (Questão 5) no método `Main` antes de rodar.

© 2025 Kamila Silva Pantoja
