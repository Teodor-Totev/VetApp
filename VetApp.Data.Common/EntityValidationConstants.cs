namespace VetApp.Data.Common
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

			public const int ChronicIllnessesMaxLength = 200;
			public const int ChronicIllnessesMinLength = 5;

			public const int CharacteristicsMaxLength = 50;
			public const int CharacteristicsMinLength = 5;

			public const string NameErrorMessage = "Name must be between {2} and {1} characters long.";

			public const string TypeErrorMessage = "Type must be between {2} and {1} characters long.";

			public const string MicrochipErrorMessage = "Microchip must be between {2} and {1} characters long.";

			public const string CharacteristicsErrorMessage = "Characteristics must be between {2} and {1} characters long.";

			public const string ChronicIllnessesErrorMessage = "ChronicIllnesses must be between {2} and {1} characters long.";
		}

		public static class OwnerValidations
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 2;

			public const int PhoneMinLength = 7;
			public const int PhoneMaxLength = 50;

			public const int AddressMaxLength = 200;
			public const int AddressMinLength = 10;
		}

		public static class ExaminationValidations
		{
			public const int MedicalHistoryMaxLength = 200;
			public const int MedicalHistoryMinLength = 5;
			
			public const int DiagnosisMaxLength = 200;
			public const int DiagnosisMinLength = 5;
			
			public const int SurgeryMaxLength = 200;
			public const int SurgeryMinLength = 5;

			public const int InputFieldMaxLength = 50;
			public const int InputFieldMinLength = 2;

			public const string MinWeight = "0";
			public const string MaxWeight = "300";
		}
	}
}
