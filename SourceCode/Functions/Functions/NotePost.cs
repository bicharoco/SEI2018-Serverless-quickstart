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
    public static class NotePost
    {
        private static IDocumentDBRepository<Note> GetNotesCollection() => new DocumentDBRepository<Note>("Notes");

        [FunctionName(nameof(NotePost))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "note")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(NotePost)} function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Note>(requestBody);
            data.Id = null;

            var note = await GetNotesCollection().CreateItemAsync(data);
            return new OkObjectResult(note);
        }
    }
}
