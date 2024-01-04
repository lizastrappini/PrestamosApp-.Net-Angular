using Microsoft.EntityFrameworkCore;
using TP_Final.Domain;

namespace TP_Final.DataAccess
{
    public class DataCategory : DbContext

    {
        private readonly PrestamosDbContext context;

        public DataCategory(PrestamosDbContext context)
        {
            this.context = context;
        }

        public async Task<Category[]> GetAllCategories()
        {
            var categories = await context.Category.ToListAsync();
            return categories.ToArray();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await context.Category.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }
        /*
        public async Task<List<Category>> Add()
        {
            //categorias: libros, indumentaria, herramientas, electronica, objetos varios
            List<string> categoryDescriptions = new List<string> { "Libros", "Indumentaria", "Herramientas","Electronica", "Objetos Varios" };
            //busco el 1ero porque si ese existe existen todos
            var categoriesExists = await context.Category.FirstOrDefaultAsync(c => categoryDescriptions.Contains(c.Description));
            Console.WriteLine(categoriesExists);

            if (categoriesExists==null)
            {
                
                List<Category> categories = new List<Category>
            {
                new Category { Description = "Libros", CreationDate = DateTime.Now},
                new Category { Description = "Indumentaria", CreationDate = DateTime.Now},
                new Category { Description = "Herramientas", CreationDate = DateTime.Now},
                new Category { Description = "Electronica", CreationDate = DateTime.Now},
                new Category { Description = "Objetos Varios", CreationDate = DateTime.Now},

            };
                Console.WriteLine(categories);
                await context.Category.AddRangeAsync(categories);
                await this.context.SaveChangesAsync();
                return categories;
            }
            else return null;
            
            
        }
        */

        public async Task<Category> Update(Category categoryToUpdate)
        {
            var updatedCategory = await context.Category.Where(t => t.Id == categoryToUpdate.Id).FirstOrDefaultAsync();


            if (updatedCategory == null)
            {
                return null;
            }
            else
            {
                context.Entry(updatedCategory).CurrentValues.SetValues(categoryToUpdate);
                await this.context.SaveChangesAsync();
                return updatedCategory;

            }

        }
    }
}
