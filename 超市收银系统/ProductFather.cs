﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    //不夸项目，加不加public都行
    class ProductFather
    {
        public double Price
        {
            get;
            set;
        }
        public double Count
        {
            get;
            set;
        }
        public string ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public ProductFather(string id,double price, string name)
        {
            this.ID = id;
            this.Price = price;
            this.Name = name;
        }
    }
}
