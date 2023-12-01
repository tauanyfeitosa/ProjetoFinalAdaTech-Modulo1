using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAdaTech.JogoDaForca
{
    internal class Verificacao
    {
        #region Método para verificar se a letra informada existe na palavra
        internal static bool PalavraSorteadaContemLetra(string palavraSorteada, char letra)
        {
            try
            {
                return palavraSorteada.Contains(letra);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao verificar se a palavra sorteada contém a letra: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para evitar saídas repetidas
        internal static bool PalavraEscondidaContemLetra(char[] palavra, char letra)
        {
            try
            {
                return palavra.Contains(letra);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao verificar se a palavra escondida contém a letra: {ex.Message}");
                throw;
            }
        } 
        #endregion

        #region Método para verificar vencedor
        internal static bool VerificarVencedor(char[] palavra)
        {
            try
            {
                return !palavra.Contains('_');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao verificar o vencedor: {ex.Message}");
                throw;
            }
        } 
        #endregion

        #region Método para verificar palavra de entrada
        internal static bool VerificarPalavra(string palavra, string palavraUsuario)
        {
            try
            {
                return palavra == palavraUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao verificar a palavra completa: {ex.Message}");
                throw;
            }
        } 
        #endregion

        #region Método para verificar erros

        internal static bool VerificarErros(int contadorErros, string palavraSorteada)
        {
            try
            {
                bool verificador = true;
                if (contadorErros == 6)
                {
                    Console.WriteLine($"Você perdeu! A palavra correta é: {palavraSorteada}");
                    verificador = false;
                }
                return verificador;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao verificar os erros: {ex.Message}");
                throw;
            }
        }
        #endregion
    }
}
