using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    // ValidationAspect, MethodInterception'dan türeyen somut bir sınıftır,
    // bu da bir yöntemin çağrıldığını engellemek için tasarlandığını ima eder.
    public class ValidationAspect : MethodInterception
    {
        // Doğrulama sırasında kullanılacak doğrulayıcının türü.
        private Type _validatorType;

        // Belirli bir doğrulayıcı türü ile ValidationAspect'in başlatılması için constructor.
        public ValidationAspect(Type validatorType)
        {
            // Sağlanan türün geçerli bir IValidator olup olmadığını kontrol et.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir"); // Geçerli bir doğrulayıcı türü değilse istisna fırlatılır.
            }

            _validatorType = validatorType;
        }

        // OnBefore metodunu geçersiz kılmak için, engellenen yöntem çağrılmadan önce kodun çalıştırılmasını sağlar.
        protected override void OnBefore(IInvocation invocation)
        {
            // Yansıma kullanarak doğrulayıcı bir örneği oluştur.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            // Validator'ün temel türünden generic argümanlardan varlık türünü al.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            // Yöntem argümanlarını filtreleyerek varlık türünü bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            // Her varlık için doğrulamayı gerçekleştir.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
