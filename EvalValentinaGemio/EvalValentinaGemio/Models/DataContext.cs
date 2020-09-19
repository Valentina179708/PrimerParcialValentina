

namespace EvalValentinaGemio.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<EvalValentinaGemio.Models.Paises> Paises { get; set; }
    }
}