using AutoMapper;
using LINQ.DataAccess;
using System;

namespace LINQ.BL.Services
{
    public abstract class BaseService : IDisposable
    {
        protected LINQDbContext _context;
        protected IMapper _mapper;
        public BaseService(LINQDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
