using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TP_Final.DataAccess;

namespace TP_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly PrestamosDbContext context;
        
        public CategoryController(PrestamosDbContext context)
        {
            this.context = context;
            
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<string> GetAll()
        {
            DataCategory dataCategory = new DataCategory(context);
            var categories = await dataCategory.GetAllCategories();
            return JsonSerializer.Serialize(categories);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<string> GetById(int id)
        {
            DataCategory dataCategory = new DataCategory(context);
            var category = await dataCategory.GetById(id);
            return JsonSerializer.Serialize(category);
        }

        /*
        [HttpPost]
        [Route("Add")]
        public async Task<string> Add()
        {
            var success = await AddCategoryService.AddCategoriesIfNotExists();
            DataCategory dataCategory = new DataCategory(context);
            var addedCategory = await dataCategory.Add();
            return JsonSerializer.Serialize(addedCategory);
        }*/

        /*
        [HttpPut]
        [Route("update/{id}")]
        public async Task<string> Update([FromBody] Category category)
        {
            DataCategory dataCategory = new DataCategory(context);
            var updatedCategory = await dataCategory.Update(category);
            if (updatedCategory == null)
            {
                throw new ValidationException("Esa categoria no existe");
            }
            return JsonSerializer.Serialize(updatedCategory);
        }
        */
    }
}
