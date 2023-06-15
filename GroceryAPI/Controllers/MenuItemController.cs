using GroceryAPI.Data;
using GroceryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace GroceryAPI.Controllers
{
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private readonly ApiResponse response;

        public MenuItemController(ApplicationDBContext db)
        {
            _db = db;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            try
            {
                response.Result = _db.MenuItems.ToList();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            try
            {
                response.Result = _db.MenuItems.Where(x => x.Id == id).FirstOrDefault();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMenuItem()
        {
            try
            {
                response.Result = _db.MenuItems.Where(x => x.Id == id).FirstOrDefault();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
        }

    }
}
