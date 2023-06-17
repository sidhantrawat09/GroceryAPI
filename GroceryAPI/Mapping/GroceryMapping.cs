using AutoMapper;
using GroceryAPI.Models;
using GroceryAPI.Models.Dto;

namespace GroceryAPI.Mapping
{
    public class GroceryMapping: Profile
    {
        public GroceryMapping()
        {
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItemUpdateDto, MenuItem>();
        }
    }
}
