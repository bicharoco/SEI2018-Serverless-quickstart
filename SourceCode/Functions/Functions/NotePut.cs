using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SEI2018.Models;
using Functions.Models;

namespace SEI2018.Functions
{
    public static class NotePut
    {
        private static IDocumentDBRepository<Note> GetNotesCollection() => new DocumentDBRepository<Note>("Notes");

        [FunctionName(nameof(NotePut))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "note/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation($"{nameof(NotePut)} function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Note>(requestBody);
            data.Id = new Guid(id);

            var note = await GetNotesCollection().UpdateItemAsync(data.Id.Value, data);
            return new OkObjectResult(note);
        }
    }
}
