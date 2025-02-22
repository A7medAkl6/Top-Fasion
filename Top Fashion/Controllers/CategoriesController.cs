﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Interfaces;
using Top_Fashion.TopFashion.Domain.Sharing;
using Top_Fashion.TopFashion.Main.Helper;

namespace Top_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork UWO, IMapper mapper)
        {
            _uOW = UWO;
            _mapper = mapper;
        }
        [HttpGet("get-all-cats")]
        public async Task<ActionResult> Get([FromQuery] CategoryParams categoryParams)
        {
           
            var src = await _uOW.CategoryRepository.GetAllAsync(categoryParams);
            var result = _mapper.Map<IReadOnlyList<CategoryDto>>(src.CategoryDtos);
            return Ok(new Pagination<CategoryDto>(categoryParams.PageNumber, categoryParams.PageSize, src.TotalCategory, result));
        }

        [HttpGet("get-all-categories")]
        public async Task<IActionResult> Get()
        {
            var allcategories = await _uOW.CategoryRepository.GetAllAsync();

            if (allcategories != null)
            {
                var res = _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<ListingCategoryDto>>(allcategories);
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

        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _uOW.CategoryRepository.GetAsync(id);
            if (category != null)
            {
                var res = _mapper.Map<Category, ListingCategoryDto>(category);
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
        [HttpPost("add-new-category")]
        public async Task<IActionResult> Post(CategoryDto categoryDto)
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
                    var res = _mapper.Map<Category>(categoryDto);
                    await _uOW.CategoryRepository.AddAsync(res);
                    return Ok(categoryDto);
                }
                return BadRequest(categoryDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-existing-category-by-id")]
        public async Task<ActionResult> Put(ListingCategoryDto categoryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingCategory = await _uOW.CategoryRepository.GetAsync(categoryDto.Id);
                    if (existingCategory != null)
                    {
                        //existingCategory.Name = categoryDto.Name;
                        //existingCategory.Description = categoryDto.Description;
                        _mapper.Map(categoryDto, existingCategory);
                        await _uOW.CategoryRepository.UpdateAsync(categoryDto.Id, existingCategory);
                        return Ok(categoryDto);
                    }
                }
                return BadRequest($"Category Not Found , Id [{categoryDto.Id}] Incorrect");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-category-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingCategory = await _uOW.CategoryRepository.GetAsync(id);
                    if (existingCategory != null)
                    {

                        await _uOW.CategoryRepository.DeleteAsync(id);
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
