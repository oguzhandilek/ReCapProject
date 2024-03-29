﻿using Business.Abstarct;
using Business.Rules.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(int id)
        {
            _colorDal.Delete(id);
        }

        public List<Color> GetAll()
        {
           return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
           return _colorDal.Get(p=> p.Id==id);

        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
