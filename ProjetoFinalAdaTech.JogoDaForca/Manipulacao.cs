using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAdaTech.JogoDaForca
{
    internal class Manipulacao
    {
        #region Método para inicializar a palavra

        internal static char[] InicializarPalavraEscondida(string palavraSorteada)
        {
            try
            {
                char[] palavraEscondida = new char[palavraSorteada.Length];
                return AlterarArray(palavraEscondida, palavraSorteada);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao inicializar a palavra escondida: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para atualizar a saída
        internal static void AtualizarPalavraEscondida(string palavraSorteada, char letra, char[] palavra)
        {
            try
            {
                List<int> posicoes = PosicoesLetra(palavraSorteada, letra);
                SubstituirLetra(posicoes, letra, palavra);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao atualizar a palavra escondida: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para alterar array

        private static char[] AlterarArray(char[] palavra, string palavraSorteada)
        {
            try
            {
                for (int i = 0; i < palavra.Length; i++)
                {
                    palavra[i] = (palavraSorteada[i] != ' ') ? '_' : ' ';
                }
                return palavra;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao alterar o array: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para substituir letra
        private static void SubstituirLetra(List<int> posicoes, char letra, char[] palavra)
        {
            try
            {
                posicoes.ForEach(i => palavra[i] = letra);
                Console.WriteLine($"{string.Join("", palavra)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao substituir a letra na palavra: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para retornar posição
        private static List<int> PosicoesLetra(string palavraSorteada, char letra)
        {
            try
            {
                return palavraSorteada
                    .Select((c, i) => c == letra ? i : -1)
                    .Where(i => i != -1)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao obter as posições da letra na palavra sorteada: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para atualizar a matriz de letras digitadas
        private static char[,] AtualizarMatrizLetras(char letra, char[,] matrizLetras)
        {
            for (int linha = 0; linha < matrizLetras.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matrizLetras.GetLength(1); coluna++)
                {
                    if (matrizLetras[linha, coluna] == char.ToUpper(letra))
                    {
                        matrizLetras[linha, coluna] = '_';
                    }
                }
            }
            return matrizLetras;
        }
        #endregion

        #region Imprimir Matriz alterada
        internal static void ImprimirMatrizLetras(char[,] matrizLetras)
        {
            Console.WriteLine("Acompanhe abaixo as letras possíveis para uso:\n\n");

            for (int linha = 0; linha < matrizLetras.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matrizLetras.GetLength(1); coluna++)
                {
                    Console.Write(matrizLetras[linha, coluna] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}

