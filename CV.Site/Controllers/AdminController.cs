using CV.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CV.Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult UploadImageWithId(IFormFile image)
        {
            try
            {
                string guid = Guid.NewGuid() + "_" + image.FileName;
                if (image != null && image.Length > 0)
                {
                    
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image");
                    var filePath = Path.Combine(uploads, guid);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    return Content(guid);
                }
                else
                {
                    return Content("");
                }
            }
            catch (Exception ex)
            {
                return Content("");
            }
        }

        [HttpDelete]
        public IActionResult DeleteImage(string id)
        {
            try
            {
                if(id == null)
                {
                    return Content("");
                }
                // Get the root path where the images are stored
                var webRootPath = _webHostEnvironment.WebRootPath + "//image//";

                // Combine the root path with the image name to get the full path
                var imagePath = Path.Combine(webRootPath, id);

                // Check if the file exists
                if (System.IO.File.Exists(imagePath))
                {
                    // Delete the file
                    System.IO.File.Delete(imagePath);
                    return Content("Image deleted successfully.");
                }
                else
                {
                    return Content("Image not found.");
                }
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAndSaveJson(JsonPop model)
        {
            try
            {

                // Convert the object to JSON
                var json = JsonConvert.SerializeObject(model);

                // Get the root path where the JSON file will be saved
                var webRootPath = _webHostEnvironment.WebRootPath;

                // Combine the root path with the file name to get the full path
                var jsonFilePath = Path.Combine(webRootPath, "jsonPop.json");

                // Save the JSON data to the file
                System.IO.File.WriteAllText(jsonFilePath, json);

                return Content("JSON file created and saved successfully.");
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }
    }
    }

