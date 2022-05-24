using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Threading.Tasks;

namespace WebPublisher.Controllers
{
    public class MensagemController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PessoaModel m)
        {
            string mensagem = Newtonsoft.Json.JsonConvert.SerializeObject(m);

            //var retorno = await SendMessage(client, fila, mensagem);

            AmazonSimpleNotificationServiceClient clientSNS = new AmazonSimpleNotificationServiceClient("", "", Amazon.RegionEndpoint.USEast1);

            var request = new PublishRequest
            {
                Message = mensagem,
                TopicArn = ""
            };

            try
            {
                var response = await clientSNS.PublishAsync(request);

            }
            catch (Exception ex)
            {
  
            }

            return View("Index");
        }
    }
}
