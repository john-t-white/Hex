using Hex.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Mvc;

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

		public void Add( string key, ValueProviderResult valueProviderResult )
		{
			if( valueProviderResult != null )
			{
				object rawValue = valueProviderResult.RawValue;
				if( rawValue is IEnumerable )
				{
					foreach( var currentValue in ( IEnumerable )rawValue )
					{
						this.Add( key, currentValue.ToString() );
					}
				}
				else
				{
					this.Add( key, rawValue.ToString() );
				}
			}
		}
	}
}
