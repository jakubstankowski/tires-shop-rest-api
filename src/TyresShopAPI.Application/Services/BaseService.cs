using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class BaseService
    {
        protected Context _context;

        public BaseService(Context context)
        {
            _context = context;
        }
    }
}
