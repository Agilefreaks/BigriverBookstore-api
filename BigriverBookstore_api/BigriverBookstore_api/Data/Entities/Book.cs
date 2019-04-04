using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BigriverBookstore_api.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        
        public DateTime Date_Published { get; set; }
        
        public string ISBN { get; set; }
    }
}
