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

		public static class PatientViewModelConstants
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;

			public const int TypeMaxLength = 50;
			public const int TypeMinLength = 2;

			public const int MicroChipMaxLength = 50;
			public const int MicroChipMinLength = 5;
		}

		public static class OwnerViewModelConstants
		{
			public const int OwnerNameMaxLength = 50;
			public const int OwnerNameMinLength = 2;

			public const int OwnerPhoneMinLength = 7;
			public const int OwnerPhoneMaxLength = 50;

			public const int OwnerAddressMaxLength = 200;
			public const int OwnerAddressMinLength = 10;
		}
	}
}
