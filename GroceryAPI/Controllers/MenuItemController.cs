using GroceryAPI.Data;
using GroceryAPI.Models;
using GroceryAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GroceryAPI.Utility;

namespace GroceryAPI.Controllers
{
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private readonly ApiResponse response;
        private readonly IMapper _mapper;

        public MenuItemController(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            response = new ApiResponse();
            _mapper = mapper;
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

        [HttpGet("{id:int}", Name = "GetMenuItem")]
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


        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromForm] MenuItemCreateDto menuItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItem.File == null || menuItem.File.Length == 0)
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.IsSuccess = false;
                        return BadRequest();
                    }

                    var item = _mapper.Map<MenuItem>(menuItem);
                    item.Image = "ahjfahf";
                    _db.MenuItems.Add(item);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Result = item;
                    response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute(nameof(GetMenuItem), new { id = item.Id }, response);
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = new List<string> { ex.Message };
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromForm] MenuItemUpdateDto menuItemUpdateDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItemUpdateDto == null || id != menuItemUpdateDto.Id)
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.IsSuccess = false;
                        return BadRequest();
                    }

                    var item = _db.MenuItems.FirstOrDefault(x => x.Id == id);
                    if (item == null)
                    {
                        return BadRequest();
                    }

                    item.ProductName = menuItemUpdateDto.ProductName;
                    item.Description = menuItemUpdateDto.Description;
                    item.Price = menuItemUpdateDto.Price;
                    item.Specification = menuItemUpdateDto.Specification;
                    item.Category = menuItemUpdateDto.Category;

                    _db.MenuItems.Update(item);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Result = item;
                    response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(response);
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = new List<string> { ex.Message };
            }

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                var item = _db.MenuItems.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess=false;
                    return BadRequest();
                }

                _db.MenuItems.Remove(item);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Result = item;
                response.StatusCode = HttpStatusCode.NoContent;
                return Ok(response);
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = new List<string> { ex.Message };
            }

            return Ok(response);
        }

    }
}
