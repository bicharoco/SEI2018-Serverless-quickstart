using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SEI2018.Models;
using Functions.Models;

namespace SEI2018.Functions
{
    public static class NoteDelete
    {
        private static IDocumentDBRepository<Note> GetNotesCollection() => new DocumentDBRepository<Note>("Notes");

        [FunctionName(nameof(NoteDelete))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "note/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation($"{nameof(NoteDelete)} function processed a request.");

            var guid = new Guid(id);
            await GetNotesCollection().DeleteItemAsync(guid);
            return new OkObjectResult(new Note { Id = guid });
        }
    }
}
