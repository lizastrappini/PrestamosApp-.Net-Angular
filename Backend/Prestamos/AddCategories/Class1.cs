using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Class1
{
    static void Main()
    {
        using (var context = new PrestamosDbContext())
        {
            // Verificar si ya existen categorías
            if (!context.Categories.Any())
            {
                // Agregar datos iniciales
                context.Categories.AddRange(
                    new Category { Id = 1, Description = "Libros", CreationDate = DateTime.UtcNow },
                    new Category { Id = 2, Description = "Indumentaria", CreationDate = DateTime.UtcNow },
                    new Category { Id = 3, Description = "Herramientas", CreationDate = DateTime.UtcNow },
                    new Category { Id = 4, Description = "Electronica", CreationDate = DateTime.UtcNow },
                    new Category { Id = 5, Description = "Objetos Varios", CreationDate = DateTime.UtcNow }
                );

                // Guardar cambios en la base de datos
                context.SaveChanges();

                Console.WriteLine("Datos insertados correctamente.");
            }
            else
            {
                Console.WriteLine("Ya existen datos en la base de datos.");
            }
        }
    }
}