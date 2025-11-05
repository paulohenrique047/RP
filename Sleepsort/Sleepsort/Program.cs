using System;
using System.Collections.Generic;
using System.Threading;

class SleepSortProgram
{
    static List<int> resultado = new List<int>(); // Cria uma lista vazia para armazenar o resultado final

    static void Main()
    { 
        Console.WriteLine("=== SLEEP SORT SIMPLES ==="); // Menu
        Console.WriteLine("Digite numeros ex: (5 7 12 3):"); 
        Console.Write("\nSua lista: "); 

        string texto = Console.ReadLine(); // Lê a lista em formato de texto
        string[] numerosTexto = texto.Split(' '); // Divide os números da lista ainda em formato de texto

        int[] numeros = new int[numerosTexto.Length]; // Cria um array de números com o mesmo tamanho do array de textos

        for (int i = 0; i < numerosTexto.Length; i++) // Loop para percorrer todos os elementos
        {
            numeros[i] = int.Parse(numerosTexto[i]); // Converte cada texto para número e armazena no array
        }

        Console.WriteLine("\nIniciando..."); 
        Console.Write("Original: "); 
        MostrarLista(numeros); // Chama função para exibir a lista original

        OrdenarComSleep(numeros); // Chama a função principal do Sleep Sort

        // Espera o maior numero + 2 segundos extra
        int maior = EncontrarMaior(numeros); // Encontra o maior número da lista
        Thread.Sleep((maior + 2) * 1000); // Espera tempo suficiente para todas as threads terminarem

        Console.Write("Ordenada: "); // Mostra label da lista ordenada
        MostrarLista(resultado.ToArray()); // Converte a List para Array e exibe a lista ordenada

        Console.WriteLine("Fim!"); // Mensagem final do programa
    }

    static void OrdenarComSleep(int[] nums) // Função que inicia o processo de ordenação
    {
        resultado.Clear(); // Limpa a lista resultado para nova execução

        foreach (int num in nums) // Para cada número no array de entrada
        {
            Thread novaThread = new Thread(() => AdicionarComSleep(num)); // Cria uma nova thread para o número
            novaThread.Start(); // Inicia a execução da thread
        }
    }

    static void AdicionarComSleep(int numero) // Função executada por cada thread
    {
        Console.WriteLine("Numero " + numero + " dormindo..."); // Mostra que o número começou a "dormir"
        Thread.Sleep(numero * 1000); // Faz a thread esperar (número * 1000) milissegundos
        resultado.Add(numero); // Adiciona o número na lista resultado (quando "acorda")
        Console.WriteLine("Numero " + numero + " pronto!"); // Mostra que o número terminou
    }

    static int EncontrarMaior(int[] nums) // Função para encontrar o maior número
    {
        int maior = nums[0]; // Assume que o primeiro número é o maior
        for (int i = 1; i < nums.Length; i++) // Percorre o array a partir do segundo elemento
        {
            if (nums[i] > maior) maior = nums[i]; // Se encontrar número maior, atualiza a variável
        }
        return maior; // Retorna o maior número encontrado
    }

    static void MostrarLista(int[] lista) // Função para exibir uma lista de números
    {
        foreach (int num in lista) // Para cada número na lista
        {
            Console.Write(num + " "); // Exibe o número seguido de espaço
        }
        Console.WriteLine(); // Pula linha após exibir todos os números
    }
}