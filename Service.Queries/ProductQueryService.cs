using Persistence.DataBase;

namespace Service.Queries
{
    public class ProductQueryService
    {
        //Inyeccion de dependencia
        private readonly ApplicationDbContext _context;
        public ProductQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
