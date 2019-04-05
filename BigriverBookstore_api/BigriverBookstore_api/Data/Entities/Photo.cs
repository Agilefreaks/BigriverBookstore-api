using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BigriverBookstore_api.Data.Entities
{
    public class Photo : BaseEntity
    {
        public string URL { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
