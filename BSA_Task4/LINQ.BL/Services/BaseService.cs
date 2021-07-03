using AutoMapper;
using LINQ.DataAccess;
using System.Linq;

namespace LINQ.BL.Services
{
    public abstract class BaseService
    {
        protected LINQDbContext _context;
        protected IMapper _mapper;
        public BaseService(LINQDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
