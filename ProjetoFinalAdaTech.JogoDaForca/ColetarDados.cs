
namespace ProjetoFinalAdaTech.JogoDaForca
{
    internal class ColetarDados
    {
        #region Método Principal
        internal static void MetodoPrincipal()
        {
            string caminhoArquivo = "C:\\Users\\tauan\\Desktop\\Tauany\\DiverseDEV\\Aulas - ME\\ProjetoFinalAdaTech\\ProjetoFinalAdaTech.JogoDaForca\\jogodaforca.txt";

            try
            {
                Dictionary<string, List<string>> categoriasPalavras = LerArquivo(caminhoArquivo);

                string categoriaSorteada = SortearCategoria(categoriasPalavras);
                string palavraSorteada = SortearPalavra(categoriasPalavras, categoriaSorteada);

                InteracaoUsuario.MetodoPrincipal(categoriaSorteada, palavraSorteada);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                // Aqui você pode adicionar mais tratamento ou log, se necessário.
            }
        }
        #endregion

        #region Método para ler o Arquivo de Texto - Banco de Palavras
        private static Dictionary<string, List<string>> LerArquivo(string caminhoArquivo)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                Dictionary<string, List<string>> categoriasPalavras = new Dictionary<string, List<string>>();

                foreach (string linha in linhas)
                {
                    AdicionarLinhaAoDicionario(categoriasPalavras, linha);
                }

                return categoriasPalavras;
            }
            catch (IOException ex)
            {
                // Trate a exceção de leitura do arquivo
                Console.WriteLine($"Erro na leitura do arquivo: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Trate outras exceções inesperadas
                Console.WriteLine($"Ocorreu uma exceção ao processar o arquivo: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para adicionar arquivo ao dicionário

        private static void AdicionarLinhaAoDicionario(Dictionary<string, List<string>> categoriasPalavras, string linha)
        {
            try
            {
                string[] partes = linha.Split(',');
                string categoria = partes[0].Trim();
                string palavra = partes[1].Trim();

                if (categoriasPalavras.ContainsKey(categoria))
                {
                    categoriasPalavras[categoria].Add(palavra);
                }
                else
                {
                    categoriasPalavras.Add(categoria, new List<string> { palavra });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao processar uma linha do arquivo: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para sortear categoria
        private static string SortearCategoria(Dictionary<string, List<string>> categoriasPalavras)
        {
            try
            {
                Random random = new Random();
                List<string> categorias = new List<string>(categoriasPalavras.Keys);
                return categorias[random.Next(categorias.Count)];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao sortear a categoria: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Método para sortear palavra
        private static string SortearPalavra(Dictionary<string, List<string>> categoriasPalavras, string categoria)
        {
            try
            {
                Random random = new Random();
                List<string> palavrasNaCategoria = categoriasPalavras[categoria];
                return palavrasNaCategoria[random.Next(palavrasNaCategoria.Count)];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao sortear a palavra: {ex.Message}");
                throw;
            }
        } 
        #endregion
    }
}
