using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnos_back.Models;

namespace turnos_back.repository
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly db_turnosContext _TurnosContext;

        public ServicioRepository(db_turnosContext turnosContext)
        {
            _TurnosContext = turnosContext;
        }

        public void Add(TServicio servicio)
        {
            _TurnosContext.Add(servicio);
            _TurnosContext.SaveChanges();
        }

        public void Delete(int id)
        {
            //var devuleto = _TurnosContext.TServicios.Find(id);
            //if(devuelto != null)
            //{
            //    devuleto.isActive = false;
            //    _TurnosContext.TServicios.Update(devuleto);
            //    _TurnosContext.SaveChanges();
            //}


            var devuelto= _TurnosContext.TServicios.Find(id);
            if(devuelto != null) { 
            _TurnosContext.TServicios.Remove(devuelto);
            _TurnosContext.SaveChanges();

            }
        }

        public async Task<List<TServicio>> GetAll()//si recibe parametro ,se cambia la condicio del is active
        {
            return await _TurnosContext.TServicios.ToListAsync();//

           // _TurnosContext.TServicios.Where(p => p.isActive == true).ToList();
        }

        public async Task<TServicio> GetById(int id)
        {
            return  await _TurnosContext.TServicios.FindAsync(id);
        }

        public async Task Update(TServicio servicio)
        {
            var servicioExisting = await _TurnosContext.TServicios.FindAsync(servicio.Id);
            if (servicioExisting == null)
            {
                throw new Exception("Servicio no encontrado");
            }
            _TurnosContext.Entry(servicioExisting).CurrentValues.SetValues(servicio);
            await _TurnosContext.SaveChangesAsync();
           
            ////
            ///
            // _TurnosContext.Update(servicio);
            //_TurnosContext.SaveChanges();   
        }
    }
}
