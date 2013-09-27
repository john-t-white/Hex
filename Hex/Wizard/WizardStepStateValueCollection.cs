using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hex.Wizard
{
	[Serializable]
	public class WizardStepStateValueCollection
		: NameValueCollection
	{
		public WizardStepStateValueCollection()
			: base()
		{}

		protected WizardStepStateValueCollection( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{ }
	}
}
