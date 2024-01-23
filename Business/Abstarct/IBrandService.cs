using Core.Utilities.Results.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id); // buradaki <Brand> liste değil interface istediğimiz <T> datası
        IResult Add(Brand brand);
        IResult Update(Brand brand);
       void Delete(int id);

    }
}
