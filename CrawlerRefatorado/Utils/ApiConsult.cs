using System.Net.Http.Headers;
using System.Text;

namespace CrawlerDados.Utils
{
    class ApiConsult
    {
        private readonly string username;
        private readonly string senha;

        public ApiConsult(string username, string senha)
        {
            this.username = username;
            this.senha = senha;
        }

        public async Task<string> GetApiResponse(string url)
        {
            using (HttpClient client = new())
            {
                // Adicionar as credenciais de autenticação básica
                var byteArray = Encoding.ASCII.GetBytes($"{username}:{senha}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                // Fazer a requisição GET à API
                HttpResponseMessage response = await client.GetAsync(url);

                // Verificar se a requisição foi bem-sucedida (código de status 200)
                if (response.IsSuccessStatusCode)
                {
                    // Ler o conteúdo da resposta como uma string
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Imprimir mensagem de erro caso a requisição falhe
                    Console.WriteLine($"Erro: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}
