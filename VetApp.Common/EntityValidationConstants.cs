namespace VetApp.Common
{
	public class EntityValidationConstants
	{
		public static class AppUserValidations
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;

			public const int AddresMaxLength = 200;
		}

		public static class PatientValidations
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;

			public const int TypeMaxLength = 50;
			public const int TypeMinLength = 2;

			public const int MicroChipMaxLength = 50;
			public const int MicroChipMinLength = 5;
		}

		public static class OwnerValidations
		{
			public const int OwnerNameMaxLength = 50;
			public const int OwnerNameMinLength = 2;

			public const int OwnerPhoneMinLength = 7;
			public const int OwnerPhoneMaxLength = 50;

			public const int OwnerAddressMaxLength = 200;
			public const int OwnerAddressMinLength = 10;
		}

		public static class ExaminationValidations
		{
			public const int TextMaxLength = 300;
			public const int TextMinLength = 5;
		}

		public static class StatusValidations
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;
		}
	}
}
