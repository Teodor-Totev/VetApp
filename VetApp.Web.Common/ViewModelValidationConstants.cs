namespace VetApp.Web.Common
{
	public class ViewModelValidationConstants
	{

		public static class LoginViewModelConstants
		{
			public const int UsernameMaxLength = 15;
			public const int UsernameMinLength = 2;
		}

		public static class RegisterViewModelConstants
		{
			public const int UsernameMaxLength = 15;
			public const int UsernameMinLength = 2;

			public const int FirstNameMaxLength = 15;
			public const int FirstNameMinLength = 2;

			public const int LastNameMaxLength = 15;
			public const int LastNameMinLength = 2;
		}

		public static class ExaminationFormModelConstants
		{
			public const int TextAreaMaxLength = 200;
			public const int TextAreaMinLength = 5;

			public const int InputFieldMaxLength = 50;
			public const int InputFieldMinLength = 2;
		}

		public static class PatientFormModelConstants
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;

			public const int TypeMaxLength = 50;
			public const int TypeMinLength = 2;

			public const int MicroChipMaxLength = 50;
			public const int MicroChipMinLength = 5;

			public const string NameErrorMessage = "Name must be between {2} and {1} characters long.";
			public const string TypeErrorMessage = "Type must be between {2} and {1} characters long.";
			public const string MicrochipErrorMessage = "Microchip must be between {2} and {1} characters long.";
		}

		public static class OwnerFormModelConstants
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;

			public const int PhoneMinLength = 7;
			public const int PhoneMaxLength = 50;

			public const int AddressMaxLength = 200;
			public const int AddressMinLength = 10;

		}

		public static class QueryModelConstants
		{
			public const int defaultPage = 1;
			public const int entitiesPerPage = 3;
		}

	}
}
