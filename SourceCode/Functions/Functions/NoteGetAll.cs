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
    public static class NoteGetAll
    {
        private static IDocumentDBRepository<Note> GetNotesCollection() => new DocumentDBRepository<Note>("Notes");

        [FunctionName(nameof(NoteGetAll))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "note")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(NoteGetAll)} function processed a request.");

            var notes = await GetNotesCollection().GetItemsAsync();
            return new OkObjectResult(notes);
        }
    }
}
