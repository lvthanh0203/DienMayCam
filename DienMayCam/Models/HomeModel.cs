﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DienMayCam.Context;

namespace DienMayCam.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }

    }
}