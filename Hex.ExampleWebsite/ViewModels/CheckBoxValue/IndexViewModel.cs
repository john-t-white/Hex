using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels.CheckBoxValue
{
	public class IndexViewModel
	{
		public IndexViewModel()
		{
			this.StringValues = new List<string>();
			this.IntValues = new List<int>();
			this.NestedEntities = new List<NestedEntity>();
		}

		public List<string> StringValues { get; private set; }

		public CheckBoxList<string> SelectedStringValues { get; set; }

		public List<int> IntValues { get; private set; }

		[Required]
		public CheckBoxList<int> SelectedIntValues { get; set; }

		public List<NestedEntity> NestedEntities { get; set; }

		public CheckBoxList<int> SelectedEntityIds { get; set; }

		public YesNoType? CheckBoxWithValue { get; set; }
	}

	public enum YesNoType
	{
		Yes,
		No
	}
}