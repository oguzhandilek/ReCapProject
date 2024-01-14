using Business.Abstarct;
using Business.Concrete;
using Business.Rules.Validation;
using Business.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
       public static IServiceCollection RegisterBusinessServicess(this IServiceCollection services)
        {
            services.AddSingleton<IBrandDal, EfBrandDal>()
               .AddSingleton<IBrandService, BrandManager>()
               .AddSingleton<BrandBusinessRules>()
               .AddSingleton<BrandValidator>()


               .AddSingleton<ICarDal, EfCarDal>()
               .AddSingleton<ICarService, CarManager>()
               .AddSingleton<CarBusinessRules>()
               .AddSingleton<CarValidator>()


               .AddSingleton<IColorDal, EfColorDal>()
               .AddSingleton<IColorService, ColorManager>();
              
            

            return services;

        }
    }
}
