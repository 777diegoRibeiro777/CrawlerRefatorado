using CrawlerDados.Models;
using CrawlerRefatorado.Compare;
using CrawlerRefatorado.Scraper;

namespace CrawlerDados.Utils
{
    class VerifyProduct
    {
        // Lista para armazenar produtos já verificados
        static List<Product> produtosVerificados = new();

        public static List<Product> ProdutosVerificados { get => produtosVerificados; set => produtosVerificados = value; }

        public static void CheckNewProducts(object state)
        {

            string username = "11164448";
            string senha = "60-dayfreetrial";
            string url = "http://regymatrix-001-site1.ktempurl.com/api/v1/produto/getall";

            Benchmarking benchmarking = new();
            try
            {
                ApiConsult apiClient = new(username, senha);
                string responseData = apiClient.GetApiResponse(url).Result;

                // Processar os dados da resposta
                List<Product> novosProdutos = ProductManager.ObterNovosProdutos(responseData);
                foreach (Product produto in novosProdutos)
                {
                    if (!produtosVerificados.Exists(p => p.Id == produto.Id))
                    {
                        // Se é um novo produto, faça algo com ele
                        Console.WriteLine($"Novo produto encontrado: ID {produto.Id}, Nome: {produto.Nome}");
                        // Adicionar o produto à lista de produtos verificados
                        produtosVerificados.Add(produto);

                        

                        // Registra um log no banco de dados apenas se o produto for novo
                        if (!ProductManager.ProdutoJaRegistrado(produto.Id))
                        {
                            LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "ConsultaAPI - Verificar Produto", "Sucesso", produto.Id);

                            MercadoLivreScraper mercadoLivreScraper = new();
                            MagazineLuizaScraper magazineLuizaScraper = new();

                            // Obter preço da Magazine Luiza
                            var precoMagazineLuiza = MagazineLuizaScraper.ObterPreco(produto.Nome, produto.Id);
                            // Obter preço do Mercado Livre
                            var precoMercadoLivre = MercadoLivreScraper.ObterPreco(produto.Nome, produto.Id);

                            Benchmarking.CompararValores(precoMagazineLuiza, precoMercadoLivre, produto.Id, produto.Nome);

                            Console.WriteLine("Comparação realizada com sucesso!!!");

                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Imprimir mensagem de erro caso ocorra uma exceção
                Console.WriteLine($"Erro ao fazer a requisição: {ex.Message}");
            }

            
        }
    }
}
