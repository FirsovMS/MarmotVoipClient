using MarmotVoipClient.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.Wrapper
{
	public class MessageWrapper : ModelWrapper<Message>
	{
		public MessageWrapper(Message model) : base(model)
		{
		}

		public int Id
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		public string Text
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public DateTime Data
		{
			get { return GetValue<DateTime>(); }
			set { SetValue(value); }
		}

		public bool IsDelivered
		{
			get { return GetValue<bool>(); }
			set { SetValue(value); }
		}

		//protected override IEnumerable<string> ValidateProperty(string propertyName)
		//{
		//	switch (propertyName)
		//	{
		//		case nameof(Text):
		//			if (string.Equals(Text, "Robot", StringComparison.OrdinalIgnoreCase))
		//			{
		//				yield return "Robots are not valid friends";
		//			}
		//			break;
		//	}
		//}
	}
}
