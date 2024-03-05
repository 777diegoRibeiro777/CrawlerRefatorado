using CrawlerDados.Data;
using CrawlerDados.Models;
using Newtonsoft.Json;

namespace CrawlerDados.Utils
{
    class ProductManager
    {
        // Método para processar os dados da resposta e obter produtos
        public static List<Product> ObterNovosProdutos(string responseData)
        {
            // Desserializar os dados da resposta para uma lista de produtos
            List<Product> produtos = JsonConvert.DeserializeObject<List<Product>>(responseData);
            return produtos;
        }

        // Método para verificar se o produto já foi registrado no banco de dados
        public static bool ProdutoJaRegistrado(int idProduto)
        {
            using var context = new LogContext();
            return context.LOGROBO.Any(log => log.IdProdutoAPI == idProduto && log.CodigoRobo == "D777");
        }
    }
}
