using Elektronika.Data;
using Microsoft.EntityFrameworkCore;

namespace Elektronika.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ElektronikaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ElektronikaContext>>()))
            {
                if (context == null || context.Alkatresz == null)
                {
                    throw new ArgumentNullException("Null ElektronikaContext");
                }


                if (context.Alkatresz.Any())
                {
                    return;
                }

                context.Alkatresz.AddRange(
                    new Alkatresz
                    {
                        Megnevezes = "Processor",
                        Gyarto = "Asus",
                        Tipus = "AMD Ryzen 5",
                        Beszar = 72000
                    },

                    new Alkatresz
                    {
                        Megnevezes = "nvme",
                        Gyarto = "Samsung",
                        Tipus = "PRO NVMe 2TB M. 2 PCIe",
                        Beszar = 42920
                    },

                    new Alkatresz
                    {
                        Megnevezes = "Ssd",
                        Gyarto = "Kingston",
                        Tipus = "A400 2.5",
                        Beszar = 9900
                    },

                    new Alkatresz
                    {
                        Megnevezes = "Ram",
                        Gyarto = "Kingstone",
                        Tipus = "2GB DDR3 1333MHz",
                        Beszar = 3600
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
