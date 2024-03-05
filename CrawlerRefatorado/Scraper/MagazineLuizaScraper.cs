using CrawlerDados.Models;
using CrawlerDados.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CrawlerRefatorado.Scraper
{
    public class MagazineLuizaScraper
    {
        public static ProductScraper ObterPreco(string descricaoProduto, int idProduto)
        {
            try
            {
                // Inicializa o ChromeDriver
                using IWebDriver driver = new ChromeDriver();
                // Abre a página
                driver.Navigate().GoToUrl($"https://www.magazineluiza.com.br/busca/{descricaoProduto}");

                // Aguarda um tempo fixo para permitir que a página seja carregada (você pode ajustar conforme necessário)
                Thread.Sleep(5000);

                // Encontra o elemento que possui o atributo data-testid
                IWebElement priceElement = driver.FindElement(By.CssSelector("[data-testid='price-value']"));
                IWebElement titleElement = driver.FindElement(By.CssSelector("[data-testid='product-title']"));
                IWebElement urlElement = driver.FindElement(By.CssSelector("[data-testid='product-card-container']"));

                // Verifica se o elemento foi encontrado
                if (priceElement != null)
                {
                    

                    ProductScraper produto = new()
                    {
                        ProductPrice = priceElement.Text.Trim(),
                        PruductName = titleElement.Text.Trim(),
                        ProductUrl = urlElement.GetAttribute("href")
                    };


                    // Registra o log com o ID do produto
                    LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "WebScraping - Magazine Luiza", "Sucesso", idProduto);

                    // Retorna o preço
                    return produto;
                }
                else
                {
                    Console.WriteLine("Preço não encontrado.");

                    // Registra o log com o ID do produto
                    LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "WebScraping - Magazine Luiza", "Preço não encontrado", idProduto);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar a página: {ex.Message}");

                // Registra o log com o ID do produto
                LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "WebScraping - Magazine Luiza", $"Erro: {ex.Message}", idProduto);

                return null;
            }
        }
    }
}