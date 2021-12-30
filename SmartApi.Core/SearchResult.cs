using SmartApi.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApi.Core
{
    public class SearchResult
    {
        public List<Property> Properties { get; set; }
        public List<Management> Managements { get; set; }
    }
}
