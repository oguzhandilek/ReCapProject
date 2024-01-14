﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(int id);

    }
}