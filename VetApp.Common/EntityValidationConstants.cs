namespace VetApp.Common
{
	public class EntityValidationConstants
	{
		public static class AppUser
		{
			public const int NameMaxLength = 15;
			public const int NameMinLength = 2;

			public const int AddresMaxLength = 200;
		}

		public static class Patient
		{
			public const int NameMaxLength = 25;
			public const int NameMinLength = 2;

			public const int TypeMaxLength = 15;
			public const int TypeMinLength = 2;

			public const int MicroChipMaxLength = 50;
			public const int MicroChipMinLength = 5;
		}

		public static class Owner
		{
			public const int NameMaxLength = 15;
			public const int NameMinLength = 2;

			public const int PhoneMinLength = 7;
			public const int PhoneMaxLength = 15;

			public const int AddressMaxLength = 85;
		}
	}
}
