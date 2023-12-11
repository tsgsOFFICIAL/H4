using HillBilly_API.DAL;
using HillBilly_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using System.Text.Json;
using System.Net;

namespace HillBilly_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HillBillyController : ControllerBase
    {
        readonly DBManager manager = new DBManager();
        CryptographyManager cryptoEngine = new CryptographyManager(new byte[] { 0x4c, 0x4f, 0x53, 0x25, 0x21, 0x56, 0x42, 0x5f, 0x53, 0x26, 0x28, 0x2f, 0x41, 0x21 }, 5);

        // GET: api/HillBilly/Get/All
        [Route("Get/All")]
        [HttpGet]
        public string? Get()
        {
            try
            {
                return JsonSerializer.Serialize(manager.GetHistory(), new JsonSerializerOptions() { WriteIndented = true });
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/HillBilly/Post
        [Route("Post")]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public ObjectResult Post([FromForm]IFormCollection value)
        {
            try
            {
                double outsideTemperature = double.Parse(value["outsideTemperature"]!);
                int uvIndex = int.Parse(value["uvIndex"]!);
                int waterLevelPercentage = int.Parse(value["waterLevelPercentage"]!);
                int stableId = int.Parse(value["stableId"]!);

                manager.AppendLogEntry(outsideTemperature, uvIndex, waterLevelPercentage, stableId);

                return StatusCode(200, "A-Okay!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/HillBilly/Clear
        [Route("Clear")]
        [HttpDelete]
        public string? Delete()
        {
            try
            {
                manager.Clear();
                return "Deletion was successfull";
            }
            catch (Exception)
            {
                return "Failed to delete";
            }
        }
    }
}