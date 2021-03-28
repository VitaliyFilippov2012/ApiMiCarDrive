using DBContext.Context;

namespace Business.Services
{
    public class BaseService
    {
        public readonly DatabaseContext Context;

        public BaseService(DatabaseContext context)
        {
            Context = context;
        }
    }
}
