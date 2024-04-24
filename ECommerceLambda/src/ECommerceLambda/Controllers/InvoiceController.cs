using ECommerceLambda.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IStorageService _service;

        public InvoiceController(IStorageService service)
        {
            _service = service;
        }

        [HttpGet("download/{document}/{year}/{month}/{day}/{invoiceId}")]
        public async Task<IActionResult> Download(string document, string year, string month, string day, string invoiceId)
        {
            var fileKey = $"{document}/{year}/{month}/{day}/{invoiceId}.json";
            var fileName = fileKey.Replace("/", "-");

            var obj = await _service.DownloadFile(fileKey);
            return File(obj, "application/octet-stream", fileName);
        }
    }
}