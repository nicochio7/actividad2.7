using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnos_back.Models;

namespace turnos_back.Service
{
    public interface IServiceServicio
    {
        Task<List<TServicio>> GetAll();
        Task<TServicio> GetById(int id);
        void Add(TServicio servicio);
        Task Update(TServicio servicio);
        void Delete(int id);
    }
}
