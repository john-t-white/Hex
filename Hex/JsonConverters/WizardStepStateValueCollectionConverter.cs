﻿using Hex.Wizard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.JsonConverters
{
	public class WizardStepStateValueCollectionConverter
		: JsonConverter
	{
		public override bool CanConvert( Type objectType )
		{
			return typeof( WizardStepStateValueCollection ).IsAssignableFrom( objectType );
		}

		public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
		{
			if( reader.TokenType == JsonToken.Null )
			{
				return existingValue;
			}

			WizardStepStateValueCollection wizardStepFormState = ( existingValue == null ) ? new WizardStepStateValueCollection() : ( WizardStepStateValueCollection )existingValue;

			JObject jObject = JObject.Load( reader );

			foreach( KeyValuePair<string, JToken> currentKeyValuePair in jObject )
			{
				string currentName = currentKeyValuePair.Key;
				foreach( string currentValue in currentKeyValuePair.Value )
				{
					wizardStepFormState.Add( currentName, currentValue );
				}
			}

			return wizardStepFormState;
		}

		public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
		{
			if( value != null )
			{
				WizardStepStateValueCollection wizardStepFormState = ( WizardStepStateValueCollection )value;

				writer.WriteStartObject();

				foreach( string currentName in wizardStepFormState )
				{
					writer.WritePropertyName( currentName );

					string[] currentValues = wizardStepFormState.GetValues( currentName );
					if( currentValues != null )
					{
						writer.WriteStartArray();
						foreach( string currentValue in currentValues )
						{
							writer.WriteValue( currentValue );
						}

						writer.WriteEndArray();
					}
				}

				writer.WriteEndObject();
			}
			else
			{
				writer.WriteNull();
			}
		}
	}
}
