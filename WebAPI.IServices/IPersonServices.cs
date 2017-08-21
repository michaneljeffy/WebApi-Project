using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entity;

namespace WebAPI.IServices
{
    public interface IPersonServices
    {
        List<Person> GetAll();
    }
}
