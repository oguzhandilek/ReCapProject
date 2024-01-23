using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
     private readonly   ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.CarPriceInValid);
            }
           _carDal.Add(car);
            return new SuccessResult(Messages.CarofAdded);
        }

        public void Delete(int id)
        {
           _carDal.Delete(id);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));

        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetailDtos();
        }

        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
