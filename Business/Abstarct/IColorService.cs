﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.Abstarct
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int id);

        void Add(Color color);
        void Update(Color color);
        void Delete(int id);

    }
}
