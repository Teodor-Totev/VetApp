﻿namespace VetApp.Common;

public static class ValidationConstants
{
	public static class LoginViewModel
	{
		public const int UsernameMaxLength = 15;
		public const int UsernameMinLength = 2;
	}

	public static class RegisterViewModel
	{
		public const int UsernameMaxLength = 15;
		public const int UsernameMinLength = 2;

		public const int FirstNameMaxLength = 15;
		public const int FirstNameMinLength = 2;

		public const int LastNameMaxLength = 15;
		public const int LastNameMinLength = 2;
	}
}
