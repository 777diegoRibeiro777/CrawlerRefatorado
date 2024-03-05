using CrawlerDados.Models;
using CrawlerDados.Utils;
using CrawlerRefatorado.Send;

namespace CrawlerRefatorado.Compare
{
    public class Benchmarking
    {

        public static void CompararValores(ProductScraper priceMagazineLuiza, ProductScraper priceMercadoLivre, int idProduto, string NomeProduto)
        {
            Console.WriteLine($"\nValor Mercado livre (String): {priceMercadoLivre.ProductPrice}\nValor Magazine Luiza (String): {priceMagazineLuiza.ProductPrice}\n");


            var priceMercadoLivreClean = priceMercadoLivre.ProductPrice.Replace(".", "");
            var priceMagazineLuizaClean = priceMagazineLuiza.ProductPrice.Trim(new Char[] { ' ', 'R', '$' }).Replace(".", "");
            // Converte as strings para decimal

            var priceMercadoLivreDouble = Double.Parse(priceMercadoLivreClean);
            var priceMagazineLuizaDouble = Double.Parse(priceMagazineLuizaClean);



                Console.WriteLine($"\nValor Magazine Luiza (Decimal): {priceMagazineLuizaDouble}\nValor Mercado Livre (Deciaml): {priceMercadoLivreDouble}\n");

                if (priceMagazineLuizaDouble < priceMercadoLivreDouble)
                {

                   LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "Menor Valor - Magazine Luiza", "Sucesso", idProduto);

                   EmailSend.EnviarEmail(priceMagazineLuiza.PruductName, nomeProdutoMercado: priceMagazineLuiza.PruductName, precoProdutoMercadoLivre: priceMercadoLivreDouble, precoProdutoMagazineLuiza: priceMagazineLuizaDouble, melhorCompra: "Magazine Luiza", urlProduto: priceMagazineLuiza.ProductUrl, emailTo: Program.userEmail);

                   LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "Email enviado", "Sucesso", idProduto);

                if (Program.resposta.ToLower() == "sim")
                {

                    _ = WhatssappSend.Main(Program.phoneNumber, priceMagazineLuiza.PruductName, nomeProdutoMercado: priceMagazineLuiza.PruductName, precoProdutoMercadoLivre: priceMercadoLivreDouble, precoProdutoMagazineLuiza: priceMagazineLuizaDouble, melhorCompra: "Magazine Luiza", urlProduto: priceMagazineLuiza.ProductUrl);

                    LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "WhatsApp enviado", "Sucesso", idProduto);
                }
            }
                else if (priceMercadoLivreDouble < priceMagazineLuizaDouble)
                {
                    
                    LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "Menor Valor - Mercado Livre", "Sucesso", idProduto);

                    EmailSend.EnviarEmail(nomeProdutoMagalu: priceMagazineLuiza.PruductName, nomeProdutoMercado: priceMercadoLivre.PruductName, precoProdutoMercadoLivre: priceMercadoLivreDouble, precoProdutoMagazineLuiza: priceMagazineLuizaDouble, melhorCompra: "Mercado Livre", urlProduto: priceMercadoLivre.ProductUrl, emailTo: Program.userEmail);
                    LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "Email enviado", "Sucesso", idProduto);
                if (Program.resposta.ToLower() == "sim")
                {

                    _ = WhatssappSend.Main(Program.phoneNumber, nomeProdutoMagalu: priceMagazineLuiza.PruductName, nomeProdutoMercado: priceMercadoLivre.PruductName, precoProdutoMercadoLivre: priceMercadoLivreDouble, precoProdutoMagazineLuiza: priceMagazineLuizaDouble, melhorCompra: "Mercado Livre", urlProduto: priceMercadoLivre.ProductUrl);

                    LogRegister.StoreLog("D777", "DiegoAlves", DateTime.Now, "WhatsApp enviado", "Sucesso", idProduto);
                }

            }
        }
    }
}