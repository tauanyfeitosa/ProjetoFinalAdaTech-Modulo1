
namespace ProjetoFinalAdaTech.JogoDaForca
{
    internal class InteracaoUsuario
    {
        internal static void MetodoPrincipal(string categoriaSorteada, string palavraSorteada)
        {
            try
            {
                ApresentarMensagemSaudacao();
                ApresentarCategoria(categoriaSorteada, palavraSorteada);

                char[] palavraEscondida = InicializarPalavraEscondida(palavraSorteada);

                bool vencedor = false;
                int contadorErros = 0;

                while (!vencedor)
                {
                    Console.WriteLine($"Palavra Atual: {string.Join("", palavraEscondida)}");

                    bool entradaUsuario = LerEntradaDoUsuario(palavraEscondida);

                    Console.WriteLine($"\n\nQuantidade de vidas: {6 - contadorErros}\n");

                    if (entradaUsuario) // Se a entrada é uma letra
                    {
                        char letra = LerLetraDoUsuario();

                        if (PalavraSorteadaContemLetra(palavraSorteada, letra) && !PalavraEscondidaContemLetra(palavraEscondida, letra))
                        {
                            Console.WriteLine("\nLetra correta!");
                            AtualizarPalavraEscondida(palavraSorteada, letra, palavraEscondida);
                            vencedor = VerificarVencedor(palavraEscondida);
                        }
                        else
                        {
                            contadorErros++;
                            if (!VerificarErros(contadorErros, palavraSorteada))
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
                        vencedor = VerificarPalavra(palavraSorteada, palavraUsuario);
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

        private static void ApresentarCategoria(string categoria, string palavraSorteada)
        {
            try
            {
                Console.WriteLine($"A categoria é: {categoria}\nA palavra sorteada possui: {palavraSorteada.Length} letras.");
                Aguardar(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao apresentar a categoria: {ex.Message}");
                throw;
            }
        }

        private static char[] InicializarPalavraEscondida(string palavraSorteada)
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

        private static char LerLetraDoUsuario()
        {
            try
            {
                return Console.ReadKey().KeyChar;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao ler a letra do usuário: {ex.Message}");
                throw;
            }
        }

        private static string LerPalavraDoUsuario()
        {
            try
            {
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao ler a palavra do usuário: {ex.Message}");
                throw;
            }
        }

        private static bool PalavraSorteadaContemLetra(string palavraSorteada, char letra)
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

        private static bool PalavraEscondidaContemLetra(char[] palavra, char letra)
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

        private static void AtualizarPalavraEscondida(string palavraSorteada, char letra, char[] palavra)
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

        private static bool VerificarErros(int contadorErros, string palavraSorteada)
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

        private static bool VerificarVencedor(char[] palavra)
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

        private static bool VerificarPalavra(string palavra, string palavraUsuario)
        {
            try
            {
                Console.WriteLine(palavra);
                return palavra == palavraUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao verificar a palavra completa: {ex.Message}");
                throw;
            }
        }
    }
}
