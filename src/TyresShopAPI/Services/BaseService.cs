using TyresShopAPI.Interfaces;

namespace TyresShopAPI.Services
{
    public class BaseService
    {
        protected readonly IContext _context;

        public BaseService(IContext context)
        {
            _context = context;
        }
    }
}
