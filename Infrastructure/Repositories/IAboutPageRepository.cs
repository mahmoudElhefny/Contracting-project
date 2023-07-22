using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IAboutPageRepository
    {
        public Task<dynamic> GetAll(string Lang);
        public Task<dynamic> Insert( AboutDto pageDto);
    }
}
