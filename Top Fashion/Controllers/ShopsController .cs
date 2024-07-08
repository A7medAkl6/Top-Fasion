using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Interfaces;

namespace Top_Fashion.Controllers
{
    public class ShopsController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;

        public ShopsController(IUnitOfWork UWO, IMapper mapper)
        {
            _uOW = UWO;
            _mapper = mapper;
        }
        [HttpGet("get-all-Shops")]
        public async Task<IActionResult> Get()
        {
            var allshops = await _uOW.ShopRepository.GetAllAsync();

            if (allshops != null)
            {
                var res = _mapper.Map<IReadOnlyList<Shop>, IReadOnlyList<ListingShopDto>>(allshops);
                //var res = allcategories.Select(x => new ListingCategoryDto
                //{
                //    Id = x.Id,
                //    Name = x.Name,
                //    Description = x.Description,
                //}).ToList();
                return Ok(res);
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        [HttpGet("get-shop-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var shop = await _uOW.ShopRepository.GetAsync(id);
            if (shop != null)
            {
                var res = _mapper.Map<Shop, ListingShopDto>(shop);
                //var newCategoryDto = new ListingCategoryDto
                //{
                //    Id = category.Id,
                //    Name = category.Name,
                //    Description = category.Description,
                //};
                return Ok(res);
            }
            else
            {
                return BadRequest($"Not Found Id [{id}]");
            }
        }
        //Authorize (Roles ="Admin")]
        [HttpPost("add-new-shop")]
        public async Task<IActionResult> Post(ShopDto shopDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var newCategory = new Category
                    //{
                    //    Name = categoryDto.Name,
                    //    Description = categoryDto.Description
                    //};
                    var res = _mapper.Map<Shop>(shopDto);
                    await _uOW.ShopRepository.AddAsync(res);
                    return Ok(shopDto);
                }
                return BadRequest(shopDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("update-existing-shop-by-id")]
        public async Task<ActionResult> Put(ListingShopDto shopDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingShop = await _uOW.ShopRepository.GetAsync(shopDto.Id);
                    if (existingShop != null)
                    {
                        //existingCategory.Name = categoryDto.Name;
                        //existingCategory.Description = categoryDto.Description;
                        _mapper.Map(shopDto, existingShop);
                        await _uOW.ShopRepository.UpdateAsync(shopDto.Id, existingShop);
                        return Ok(shopDto);
                    }
                }
                return BadRequest($"Shop Not Found , Id [{shopDto.Id}] Incorrect");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("delete-shop-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingCategory = await _uOW.ShopRepository.GetAsync(id);
                    if (existingCategory != null)
                    {

                        await _uOW.ShopRepository.DeleteAsync(id);
                        return Ok($"This Category [{existingCategory.Name}] Is Deleted Successfully ");
                    }
                }
                return BadRequest($"Category Not Found , Id [{id}] Incorrect");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
