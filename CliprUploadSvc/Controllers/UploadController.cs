using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CliprUploadSvc.Controllers;

[ApiController]
[Route("[controller]")]
public class UploadController: ControllerBase
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private string _storagePath = string.Empty;

    public UploadController(IWebHostEnvironment hostingEnvironment, IMediator mediator)
    {
        _hostingEnvironment = hostingEnvironment;

        _storagePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Storage");
    }

    [HttpPost(Name = "UploadVideo")]
    public async Task<IActionResult> UploadVideo(List<IFormFile> files)
    {
        var video = HttpContext.Request.Form.Files.GetFile("Data");
        
        var file = HttpContext.Request.Form.Files.GetFile("Data");

        if (file == null)
        {
            throw new ArgumentNullException("File cannot be null!");
        }

        // Building the path to the uploads directory
        // Get the mime type
        var mimeType = HttpContext.Request.Form.Files.GetFile("Data")!.ContentType;

        // Get File Extension
        string extension = Path.GetExtension(file.FileName);

        // Generate Random name.
        string name = string.Concat(Guid.NewGuid().ToString().AsSpan(0, 8), extension);

        string link = Path.Combine(_storagePath, name);

        // Create directory if it dose not exist.
        FileInfo dir = new FileInfo(_storagePath);
        dir.Directory!.Create();

        string[] videoMimetypes = { "video/mp4", "video/webm", "video/ogg" };
        string[] videoExt = { ".mp4", ".webm", ".ogg" };

        if (Array.IndexOf(videoMimetypes, mimeType) >= 0 && (Array.IndexOf(videoExt, extension) >= 0))
        {
            // Copy contents to memory stream.
            Stream stream;
            stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;
            string serverPath = link;

            // Save the file
            using (FileStream writerFileStream = System.IO.File.Create(serverPath))
            {
                await stream.CopyToAsync(writerFileStream);
                writerFileStream.Dispose();
            }

            // Return the file path as json
            Hashtable videoUrl = new Hashtable();
            videoUrl.Add("link", "/uploads/" + name);

            return Ok(videoUrl);

        }

        return Ok();


        /*        if (video == null || video.Length == 0)
                {
                    return BadRequest("No file selected");
                }

                var videoPath = Path.Combine(_storagePath, video.FileName);

                if (!Directory.Exists(Path.GetDirectoryName(videoPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(videoPath)!);

                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    await video.CopyToAsync(stream);
                }

                return Ok(videoPath);*/
    }
}
