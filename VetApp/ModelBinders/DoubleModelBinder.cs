namespace VetApp.ModelBinders
{
	using System.Globalization;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc.ModelBinding;

	public class DoubleModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider
				.GetValue(bindingContext.ModelName);

			if(valueResult != ValueProviderResult.None &&
				!string.IsNullOrEmpty(valueResult.FirstValue))
			{
				double result = 0d;
				bool success = false;

				try
				{
					string strValue = valueResult.FirstValue.Trim();
					strValue = strValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					strValue = strValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					result = Convert.ToDouble(strValue, CultureInfo.CurrentCulture);
					success = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}

				if (success)
				{
					bindingContext.Result = ModelBindingResult.Success(result);
				}
			}

			return Task.CompletedTask;
		}
	}
}
