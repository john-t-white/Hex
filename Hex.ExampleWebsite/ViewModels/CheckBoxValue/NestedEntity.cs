using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels.CheckBoxValue
{
	public class NestedEntity
	{
		public NestedEntity( int id, string name )
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; set; }

		public string Name { get; set; }
	}
}