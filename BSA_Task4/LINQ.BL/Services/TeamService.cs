using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQ.BL.Services
{
    public class TeamService : BaseService
    {
        public TeamService(IMapper mapper, LINQDbContext context) : base(context, mapper)
        {
        }
        public async Task<IEnumerable<TeamDTO>> Read()
        {
            var Teams = await _context.Teams.ToListAsync();
            return _mapper.Map<List<TeamDTO>>(Teams);
        }

        public async Task<TeamDTO> ReadById(int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find element with this id");
            return _mapper.Map<TeamDTO>(await _context.Teams.FirstAsync(t => t.Id == id));
        }

        public async System.Threading.Tasks.Task Create(TeamDTO TeamDTO)
        {
            var Team = _mapper.Map<Team>(TeamDTO);
            if (IsExistElementById(TeamDTO.Id))
                throw new System.InvalidOperationException("toject with this id is already exist");
            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(TeamDTO newtoject, int id)
        {
            var Team = _mapper.Map<Team>(newtoject);
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("toject with this id is already exist");
            var update = _context.Teams.First(t => t.Id == id);
            update = Team;
            _context.Teams.Update(update);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find toject with this id");
            var deleted = _context.Teams.First(t => t.Id == id);
            _context.Teams.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        private bool IsExistElementById(int id) => _context.Teams.Any(t => t.Id == id);
    }
}
