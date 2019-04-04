﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Models;

namespace BigriverBookstore_api.Resources
{
    public class Book : Identifiable
    {
        [Attr("title")]
        public string Title { get; set; }

        [Attr("date_published")]
        public DateTime Date_Published { get; set; }

        [Attr("isbn")]
        public string ISBN { get; set; }
    }
}
