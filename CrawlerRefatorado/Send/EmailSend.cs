using System.Net;
using System.Net.Mail;

namespace CrawlerRefatorado.Send
{
    public static class EmailSend
    {

        public static void EnviarEmail(string nomeProdutoMagalu, string nomeProdutoMercado, double precoProdutoMercadoLivre, double precoProdutoMagazineLuiza, string melhorCompra, string urlProduto, string emailTo)
        {

            // Configurações do servidor SMTP do Gmail
            string smtpServer = "smtp-mail.outlook.com"; // Servidor SMTP do Gmail
            int porta = 587; // Porta SMTP do Gmail para TLS/STARTTLS
            string remetente = "diegoalvesteste777@outlook.com"; // Seu endereço de e-mail do Gmail
            string senha = "diegoRibeiroTeste$"; // Sua senha do Gmail

            // Configurar cliente SMTP
            using (SmtpClient client = new SmtpClient(smtpServer, porta))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(remetente, senha);
                client.EnableSsl = true; // Habilitar SSL/TLS

                // Construir mensagem de e-mail
                MailMessage mensagem = new MailMessage(remetente, $"{emailTo}")
                {
                    Subject = "Resultado da comparação de preços",
                    Body = @$"        <h3>Mercado Livre:</h3>
        <p><strong>Produto:</strong> {nomeProdutoMercado}</p>
        <p><strong>Preço:</strong> R${precoProdutoMercadoLivre}</p>
        <br>
        <h3>Magazine Luiza:</h3>
        <p><strong>Produto:</strong> {nomeProdutoMagalu}</p>
        <p><strong>Preço:</strong> R${precoProdutoMagazineLuiza}</p>
        <br>
        <h3>Melhor compra:</h3>
        <p><Strong>{melhorCompra}</Strong> - <a href=""{urlProduto}""> Link do produto.</a></p>
        <br>
        <br>
        <p><strong>Robô:</strong> D777</p>
        <p><strong>Usuário:</strong> diegoalves</p>"

                };
                mensagem.IsBodyHtml = true;

                // Enviar e-mail
                client.Send(mensagem);

                Console.WriteLine(precoProdutoMercadoLivre);
                Console.WriteLine(precoProdutoMagazineLuiza);
            }
        }
    }
}