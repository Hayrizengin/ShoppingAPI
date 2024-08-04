using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Api.Aspects;
using ShoppingAPI.Api.Validation.FluentValidation;
using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using ShoppingAPI.Helper.CustomException;

namespace ShoppingAPI.Api.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost("/AddCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> AddCategory(CategoryRequestDTO categoryDTORequest)
        {
            Category category = _mapper.Map<Category>(categoryDTORequest);

            await _categoryService.AddAsync(category);

            CategoryResponseDTO categoryResponseDTO = _mapper.Map<CategoryResponseDTO>(category);

            return Ok(Sonuc<CategoryResponseDTO>.SuccessWithData(categoryResponseDTO));

        }

        [HttpGet("/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories!=null)
            {
                List<CategoryResponseDTO> categoryResponseDTOList = new();
                foreach (var category in categories)
                {
                    categoryResponseDTOList.Add(_mapper.Map<CategoryResponseDTO>(category));
                }
                return Ok(Sonuc<List<CategoryResponseDTO>>.SuccessWithData(categoryResponseDTOList));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryResponseDTO>>.SuccessNoDataFound());
            }

            
        }


        [HttpGet("/Category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetAsync(q=>q.id==id);
            if (category != null)
            {
                CategoryResponseDTO categoryResponseDTO = new();

                categoryResponseDTO = _mapper.Map<CategoryResponseDTO>(category);
                
                return Ok(Sonuc<CategoryResponseDTO>.SuccessWithData(categoryResponseDTO));
            }
            else
            {
                return NotFound(Sonuc<CategoryResponseDTO>.SuccessNoDataFound());
            }


        }
    }
}
