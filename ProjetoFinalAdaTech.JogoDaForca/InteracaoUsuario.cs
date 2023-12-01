
namespace ProjetoFinalAdaTech.JogoDaForca
{
    internal class InteracaoUsuario
    {
        #region Método Principal
        internal static void MetodoPrincipal(string categoriaSorteada, string palavraSorteada)
        {
            try
            {
                ApresentarMensagemSaudacao();
                ApresentarCategoria(categoriaSorteada, palavraSorteada);

                char[] palavraEscondida = Manipulacao.InicializarPalavraEscondida(palavraSorteada);

                bool vencedor = false;
                int contadorErros = 0;

                char[,] matrizLetras = new char[,]
                {
                    {'A', 'B', 'C', 'D', 'E', 'F' },
                    {'G', 'H', 'I', 'J', 'K', 'L' },
                    {'M', 'N', 'O', 'P', 'Q', 'R' },
                    {'S', 'T', 'U', 'V', 'W', 'X' },
                    {'Y', 'Z', '_', '_', '_', '_' },
                };

                while (!vencedor)
                {
                    Console.WriteLine($"Palavra Atual: {string.Join("", palavraEscondida)}");

                    bool entradaUsuario = LerEntradaDoUsuario(palavraEscondida);

                    Console.WriteLine($"\n\nQuantidade de vidas: {6 - contadorErros}\nCategoria: {categoriaSorteada}");

                    if (entradaUsuario) // Se a entrada é uma letra
                    {
                        char letra = LerLetraDoUsuario();

                        Manipulacao.ImprimirMatrizLetras(AtualizarMatrizLetras(letra, matrizLetras));

                        if (Verificacao.PalavraSorteadaContemLetra(palavraSorteada, letra) && !Verificacao.PalavraEscondidaContemLetra(palavraEscondida, letra))
                        {
                            Console.WriteLine("\nLetra correta!");
                            Manipulacao.AtualizarPalavraEscondida(palavraSorteada, letra, palavraEscondida);
                            vencedor = Verificacao.VerificarVencedor(palavraEscondida);
                        }
                        else
                        {
                            contadorErros++;
                            if (!Verificacao.VerificarErros(contadorErros, palavraSorteada))
                            {
                                break;
                            }
                            Console.WriteLine("\nLetra incorreta. Tente novamente!");
                        }
                    }
                    else // Se a entrada é a palavra completa
                    {
                        Console.WriteLine("Digite a palavra completa:");
                        string palavraUsuario = Console.ReadLine();
                        vencedor = Verificacao.VerificarPalavra(palavraSorteada, palavraUsuario);
                        if (vencedor)
                        {
                            Console.WriteLine("\nParabéns! Você acertou a palavra completa. Você é o vencedor!");
                            break;
                        }
                        Console.WriteLine("\nPalavra incorreta! Você perdeu!");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção na interação do usuário: {ex.Message}");
                // Aqui você pode adicionar mais tratamento ou log, se necessário.
            }
        }
        #endregion

        #region Método para verificar a possibilidade de ler a entrada do usuário
        private static bool LerEntradaDoUsuario(char[] palavraEscondida)
        {
            try
            {
                int contaUnderline = palavraEscondida.Count(c => c == '_');
                return contaUnderline > 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao ler a entrada do usuário: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para fazer a apresentação do sistema ao usuário

        private static void ApresentarMensagemSaudacao()
        {
            try
            {
                Console.WriteLine("Regras do jogo:\n*Quando faltarem 2 letras, é obrigatório que se digite a palavra completa.\n" +
                    "*Cada letra errada diminui 1 vida e cada palavra errada, encerra o jogo instantaneamente.\n*Você receberá uma dica, referente à" +
                    " categoria da palavra e a quantidade de letras que ela possui." +
                    "*Você possui um total de 6 vidas, se atingir as seis vidas, será eliminado.\n\n");
                Aguardar(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao apresentar a mensagem de saudação: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para fazer a apresentação da dica/categoria

        private static void ApresentarCategoria(string categoria, string palavraSorteada)
        {
            try
            {
                Console.WriteLine($"A categoria é: {categoria}\nA palavra sorteada possui: {palavraSorteada.Length} letras.\n\n");
                Aguardar(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao apresentar a categoria: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para dar uma pausa no tempo de execução
        private static void Aguardar(int milissegundos)
        {
            try
            {
                Thread.Sleep(milissegundos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao aguardar: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para ler entrada char
        private static char LerLetraDoUsuario()
        {
            try
            {
                Console.WriteLine("\n\nDigite uma letra:\n");
                return char.ToLower(Console.ReadKey().KeyChar);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao ler a letra do usuário: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para ler a plavra completa

        private static string LerPalavraDoUsuario()
        {
            try
            {
                return Console.ReadLine().ToLower();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao ler a palavra do usuário: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para atualizar a matriz de letras digitadas
        private static char [,] AtualizarMatrizLetras(char letra, char[,] matrizLetras)
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
        private static void ImprimirMatrizLetras(char[,] matrizLetras)
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