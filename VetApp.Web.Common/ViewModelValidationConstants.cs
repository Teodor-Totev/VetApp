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

		public static class QueryModelConstants
		{
			public const int defaultPage = 1;
			public const int entitiesPerPage = 3;
		}

		public static class AddRoleViewModelConstants
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;
		}

	}
}
