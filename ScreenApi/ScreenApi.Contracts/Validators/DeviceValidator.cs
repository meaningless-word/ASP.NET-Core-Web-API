using FluentValidation;
using ScreenApi.Contracts.Models;

namespace ScreenApi.Contracts.Validators
{
	public class DeviceValidator : AbstractValidator<Device>
	{
		public DeviceValidator()
		{
			RuleFor(x => x.StorageType).NotEmpty();
			RuleFor(x => x.Manufacturer).NotEmpty();
			RuleFor(x => x.Capacity).Must(BeValidCapacity).WithMessage("Поддерживаются диски объёмом от 120 до 512 Гб.");
		}

		private bool BeValidCapacity(long Сapacity)
		{
			if (Сapacity < 120)
				return false;
			if (Сapacity > 512)
				return false;

			return true;
		}
	}
}
