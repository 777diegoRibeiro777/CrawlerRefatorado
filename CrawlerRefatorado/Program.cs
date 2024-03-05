using CrawlerDados.Utils;


namespace CrawlerRefatorado
{
    public class Program
    {
        public static string? userEmail;

        public static string? resposta;

        public static string? phoneNumber;

        public static void Main(string[] args)
        {
            Console.WriteLine("Por favor, insira seu endereço de e-mail:");
            userEmail = Console.ReadLine();

            Console.WriteLine("Deseja enviar um ZAP ao final do ciclo? (Digite 'sim' ou 'não')");
            resposta = Console.ReadLine();

            // Pedir ao usuário o número para envio no formato 55xxyyyyzzzz
            if (resposta.ToLower() == "sim")
            {

                Console.WriteLine($"Por favor insira o número de telefone para enviar sua mensagem no formato 55xxyyyyzzzz:");
                phoneNumber = Console.ReadLine();

            }


            // Definir o intervalo de tempo para 5 minutos (300.000 milissegundos)
            int intervalo = 60000;

            // Criar um temporizador que dispara a cada 5 minutos
            Timer timer = new(callback: VerifyProduct.CheckNewProducts, state: null, dueTime: 0, period: intervalo);

            while (true)
            {
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}