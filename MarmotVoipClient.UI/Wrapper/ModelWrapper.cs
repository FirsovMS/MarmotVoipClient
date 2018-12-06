using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MarmotVoipClient.UI.Wrapper
{
	public class ModelWrapper<T> : NotifyDataErrorInfoBase
	{
		public T Model { get; }

		public ModelWrapper(T model)
		{
			Model = model;
		}

		protected virtual void SetValue<TValue>(TValue value, [CallerMemberName]string propertyName = null)
		{
			typeof(T).GetProperty(propertyName).SetValue(Model, value);
			OnPropertyChanged(propertyName);
			ValidatePropertyInternal(propertyName, value);
		}

		protected virtual TValue GetValue<TValue>([CallerMemberName]string propertyName = null)
		{
			return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
		}

		private void ValidatePropertyInternal<TValue>(string propertyName, TValue value)
		{
			ClearErrors(propertyName);

			ValidateCustomErrors(propertyName);
		}

		private void ValidateCustomErrors(string propertyName)
		{
			var errors = ValidateProperty(propertyName);
			if (errors != null)
			{
				foreach (var error in errors)
				{
					AddError(propertyName, error);
				}
			}
		}

		/// <summary>
		/// Customize your validation logic
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		protected virtual IEnumerable<string> ValidateProperty(string propertyName)
		{
			return null;
		}
	}
}
