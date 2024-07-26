using FluentValidation;
using NLayer.Core.Models;

namespace NLayer.Service.Validations
{
	public class RezervasyonDtoVlidator : AbstractValidator<Rezervasyon>
	{
		public RezervasyonDtoVlidator()
		{
			RuleFor(x => x.RezervasyonTarih).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
			RuleFor(x => x.Müşteri_Id).InclusiveBetween(1, int.MinValue).WithMessage("{PropertyName} must be greater than 0");
			RuleFor(x => x.Kuaför_Id).InclusiveBetween(1, int.MinValue).WithMessage("{PropertyName} must be greater than 0");
		}
	}
}
