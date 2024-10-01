using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnos_back.Models;
using turnos_back.repository;

namespace turnos_back.Service
{
    public class ServiceServicio : IServiceServicio
{
        private readonly IServicioRepository _repository;

        public ServiceServicio(IServicioRepository repository)
        {
            _repository = repository;
        }

        public void Add(TServicio servicio)
        {
            _repository.Add(servicio); 
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public async Task<List<TServicio>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<TServicio> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(TServicio servicio)
        {
           await _repository.Update(servicio);
        }
    }
}
