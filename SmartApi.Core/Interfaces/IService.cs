using SmartApi.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApi.Core.Interfaces
{
    public interface IService
    {
        List<Property> SearchApartment(string query);
        List<Management> SearchManagement(string query);
    }
}
