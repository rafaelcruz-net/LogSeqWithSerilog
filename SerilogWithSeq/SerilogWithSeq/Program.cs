using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogWithSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            for (int i = 0; i < 1500; i++)
            {
                var request = new
                {
                    TransactionId = Guid.NewGuid(),
                    Message = "OK",
                    Response = "Usuário salvo com sucesso"
                };

                log.Information("New Request: TransactionId:{TransactionId} Object:{@request}", request.TransactionId, request);
            }
            Console.Read();
        }
    }
}
