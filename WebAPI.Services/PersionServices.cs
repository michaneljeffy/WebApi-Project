using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entity;
using WebAPI.IRepository;
using WebAPI.IServices;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class PersonServices : IPersonServices
    {
        //程序集属性注入
       public  IPersonRepository iPerson;

        public PersonServices()
        {
            iPerson = new PersonRepository();
        }

        public List<Person> GetAll()
        {
            return iPerson.GetAll();
        }
    }
}
