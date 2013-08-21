using Hex.Extensions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Globalization;

namespace Hex.TestProject.Extensions.ModelStateDictionaryExtensionsTests
{
	[TestClass]
	public class ModelStateDictionaryExtensions_GetModelStateValue
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string key = "Key";
			string value = "Value";

			var modelState = new ModelState();
			modelState.Value = new ValueProviderResult( value, value, CultureInfo.InvariantCulture );

			var modelStateDictionary = new ModelStateDictionary();
			modelStateDictionary.Add( key, modelState );

			ModelState modelStateResult;
			var result = modelStateDictionary.GetModelStateValue( key, value.GetType(), out modelStateResult );

			Assert.AreEqual( result, value );
			Assert.AreSame( modelStateResult, modelState );
		}

		[TestMethod]
		public void WithKeyNotFoundReturnsCorrectly()
		{
			string key = "Key";
			string value = "Value";

			var modelState = new ModelState();
			modelState.Value = new ValueProviderResult( value, value, CultureInfo.InvariantCulture );

			var modelStateDictionary = new ModelStateDictionary();
			modelStateDictionary.Add( key, modelState );

			ModelState modelStateResult;
			var result = modelStateDictionary.GetModelStateValue( "KeyNotFound", typeof( string ), out modelStateResult );

			Assert.IsNull( result );
			Assert.IsNull( modelStateResult );
		}
	}
}
