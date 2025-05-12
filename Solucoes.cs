using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace TargetSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Questão 1 - Soma = {CalculateSum(13)}");

            int numero = 21;
            Console.WriteLine($"Questão 2 - O número {numero} {(IsFibonacci(numero) ? "pertence" : "não pertence")} à sequência de Fibonacci.");

            var faturamento = LoadFaturamentoFromJson("faturamento.json");
            var stats = AnalyzeFaturamento(faturamento);
            Console.WriteLine($"Questão 3 - Menor faturamento: {stats.Min}");
            Console.WriteLine($"Questão 3 - Maior faturamento: {stats.Max}");
            Console.WriteLine($"Questão 3 - Dias acima da média: {stats.DaysAboveAverage}");

            var distribuicao = new Dictionary<string, double>
            {
                {"SP", 67836.43},
                {"RJ", 36678.66},
                {"MG", 29229.88},
                {"ES", 27165.48},
                {"Outros", 19849.53}
            };
            Console.WriteLine("Questão 4 - Percentual por estado:");
            foreach (var kvp in CalculatePercentage(distribuicao))
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value:F2}%");
            }

            string texto = "Exemplo de string";
            Console.WriteLine($"Questão 5 - Invertido: {ReverseString(texto)}");
        }

        static int CalculateSum(int indice)
        {
            int soma = 0, k = 0;
            while (k < indice)
            {
                k++;
                soma += k;
            }
            return soma;
        }

        static bool IsFibonacci(int n)
        {
            if (n < 0) return false;
            int a = 0, b = 1;
            while (a < n)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return a == n;
        }

        class Faturamento
        {
            public int dia { get; set; }
            public double valor { get; set; }
        }

        static List<double> LoadFaturamentoFromJson(string path)
        {
            var content = File.ReadAllText(path);
            var lista = JsonSerializer.Deserialize<List<Faturamento>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return lista.Where(x => x.valor > 0).Select(x => x.valor).ToList();
        }

        static (double Min, double Max, int DaysAboveAverage) AnalyzeFaturamento(List<double> faturamento)
        {
            double min = faturamento.Min();
            double max = faturamento.Max();
            double avg = faturamento.Average();
            int diasAcima = faturamento.Count(v => v > avg);
            return (min, max, diasAcima);
        }

        static Dictionary<string, double> CalculatePercentage(Dictionary<string, double> values)
        {
            double total = values.Values.Sum();
            return values.ToDictionary(kvp => kvp.Key, kvp => kvp.Value / total * 100);
        }

        static string ReverseString(string s)
        {
            char[] arr = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = s[s.Length - 1 - i];
            }
            return new string(arr);
        }
    }
}
