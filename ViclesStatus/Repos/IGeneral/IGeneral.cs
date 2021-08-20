using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViclesStatus.Models.IGeneral
{
   public interface IGeneral<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task ADD(T t);
        Task Delete(int id);
        Task Update(T t);
    }
}
