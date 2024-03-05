using CrawlerDados.Data;
using CrawlerDados.Models;

namespace CrawlerDados.Utils
{
    class LogRegister
    {
        // Método para registrar um log no banco de dados
        public static void StoreLog(string codRob, string usuRob, DateTime dateLog, string processo, string infLog, int idProd)
        {
            using (var context = new LogContext())
            {
                var log = new Log
                {
                    CodigoRobo = codRob,
                    UsuarioRobo = usuRob,
                    DateLog = dateLog,
                    Etapa = processo,
                    InformacaoLog = infLog,
                    IdProdutoAPI = idProd
                };
                context.LOGROBO.Add(log);
                context.SaveChanges();
            }
        }
    }
}
