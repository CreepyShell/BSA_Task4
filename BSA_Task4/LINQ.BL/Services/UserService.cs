using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.Common.DTOModels.UsersDTO;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQ.BL.Services
{
    public class UserService : BaseService
    {
        public UserService(IMapper mapper, LINQDbContext context) : base(context, mapper)
        {
        }
        public async Task<IEnumerable<UserDTO>> Read()
        {
            var Users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(Users);
        }

        public async Task<UserDTO> ReadById(int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find element with this id");
            return _mapper.Map<UserDTO>(await _context.Users.FirstAsync(t => t.Id == id));
        }

        public async System.Threading.Tasks.Task Create(UserDTO UserDTO)
        {
            var User = _mapper.Map<User>(UserDTO);
            if (IsExistElementById(UserDTO.Id))
                throw new System.InvalidOperationException("user with this id is already exist");
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(UpdatedUserDTO updateUser, int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find element with this id");

            var update = _context.Users.First(t => t.Id == id);
            if (updateUser.NewName != null)
                update.Name = updateUser.NewName;
            if (updateUser.NewTeamiD != null)
                update.TeamId = updateUser.NewTeamiD;

            _context.Users.Update(update);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find user with this id");
            var deleted = _context.Users.First(t => t.Id == id);
            _context.Users.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        private bool IsExistElementById(int id) => _context.Users.Any(t => t.Id == id);
    }
}
