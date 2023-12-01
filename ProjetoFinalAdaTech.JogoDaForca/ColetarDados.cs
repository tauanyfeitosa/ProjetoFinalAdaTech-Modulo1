namespace ProjetoFinalAdaTech.JogoDaForca
{
    internal class ColetarDados
    {
        internal static void MetodoPrincipal()
        {
            string caminhoArquivo = "C:\\Users\\tauan\\Desktop\\Tauany\\DiverseDEV\\Aulas - ME\\ProjetoFinalAdaTech\\ProjetoFinalAdaTech.JogoDaForca\\jogodaforca.txt";

            Dictionary<string, List<string>> categoriasPalavras = LerArquivo(caminhoArquivo);

            string categoriaSorteada = SortearCategoria(categoriasPalavras);
            string palavraSorteada = SortearPalavra(categoriasPalavras, categoriaSorteada);

            InteracaoUsuario.MetodoPrincipal(categoriaSorteada, palavraSorteada);
        }

        private static Dictionary<string, List<string>> LerArquivo(string caminhoArquivo)
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            Dictionary<string, List<string>> categoriasPalavras = new Dictionary<string, List<string>>();

            foreach (string linha in linhas)
            {
                AdicionarLinhaAoDicionario(categoriasPalavras, linha);
            }

            return categoriasPalavras;
        }

        private static void AdicionarLinhaAoDicionario(Dictionary<string, List<string>> categoriasPalavras, string linha)
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

        private static string SortearCategoria(Dictionary<string, List<string>> categoriasPalavras)
        {
            Random random = new Random();
            List<string> categorias = new List<string>(categoriasPalavras.Keys);
            return categorias[random.Next(categorias.Count)];
        }

        private static string SortearPalavra(Dictionary<string, List<string>> categoriasPalavras, string categoria)
        {
            Random random = new Random();
            List<string> palavrasNaCategoria = categoriasPalavras[categoria];
            return palavrasNaCategoria[random.Next(palavrasNaCategoria.Count)];
        }
    }
}
