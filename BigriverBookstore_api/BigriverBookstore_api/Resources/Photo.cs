using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Models;

namespace BigriverBookstore_api.Resources
{
    public class Photo : Identifiable
    {
        [Attr("url")]
        public string URL { get; set; }

        [HasOne("book")]
        public virtual Book Book { get; set; }
    }
}
