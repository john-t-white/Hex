using Hex.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hex.Wizard
{
	[Serializable]
	[JsonConverter( typeof( WizardStepValueCollectionConverter ) )]
	public class WizardStepValueCollection
		: NameValueCollection
	{
		public WizardStepValueCollection()
			: base()
		{}

		protected WizardStepValueCollection( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{ }
	}
}
