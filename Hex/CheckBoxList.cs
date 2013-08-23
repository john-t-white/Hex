using Hex.ModelBinders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex
{
	[ModelBinder( typeof( CheckBoxListModelBinder ) )]
	public class CheckBoxList
		: ArrayList
	{
		public CheckBoxList()
			: base()
		{ }

		public CheckBoxList( ICollection collection )
			: base( collection )
		{ }

		public CheckBoxList( int capacity )
			: base( capacity )
		{ }
	}

	[ModelBinder( typeof( CheckBoxListModelBinder ) )]
	public class CheckBoxList<T>
		: List<T>
	{
		public CheckBoxList()
			: base()
		{ }

		public CheckBoxList( int capacity )
			: base( capacity )
		{ }

		public CheckBoxList( IEnumerable<T> collection )
			: base( collection )
		{ }
	}
}
