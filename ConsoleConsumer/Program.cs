using Amazon.SQS;
using Amazon.SQS.Model;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConsumirMensagem();


            Console.ReadLine();
        }

        static private async Task ConsumirMensagem()
        {
            try
            {
                AmazonSQSClient client = new AmazonSQSClient("", "", Amazon.RegionEndpoint.USEast1);

                ReceiveMessageRequest request = new ReceiveMessageRequest();
                request.QueueUrl = "";
                request.WaitTimeSeconds = 20;
                request.MaxNumberOfMessages = 1;

                var mensagem = await client.ReceiveMessageAsync(request, CancellationToken.None);

                foreach (var m in mensagem.Messages)
                {
                    SnsModel sns = Newtonsoft.Json.JsonConvert.DeserializeObject<SnsModel>(m.Body);
                    PessoaModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<PessoaModel>(sns.Message);
                    Console.WriteLine("Nome da nova pessoa: " + model.Nome);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
         
        }
    }
}
