using Hex.ModelBinders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex
{
	/// <summary>
	/// Contains the list of checkboxes that are selected in a checkbox list.
	/// </summary>
	[ModelBinder( typeof( CheckBoxValuesModelBinder ) )]
	public class CheckBoxValues
		: ArrayList
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.CheckBoxValues" /> class.
		/// </summary>
		public CheckBoxValues()
			: base()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.CheckBoxValues" /> class.
		/// </summary>
		public CheckBoxValues( ICollection collection )
			: base( collection )
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.CheckBoxValues" /> class.
		/// </summary>
		public CheckBoxValues( int capacity )
			: base( capacity )
		{ }
	}

	/// <summary>
	/// Contains the list of checkboxes that are selected in a checkbox list.
	/// </summary>
	[ModelBinder( typeof( CheckBoxValuesModelBinder ) )]
	public class CheckBoxValues<T>
		: List<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.CheckBoxValues{T}" /> class.
		/// </summary>
		public CheckBoxValues()
			: base()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.CheckBoxValues{T}" /> class.
		/// </summary>
		public CheckBoxValues( int capacity )
			: base( capacity )
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.CheckBoxValues{T}" /> class.
		/// </summary>
		public CheckBoxValues( IEnumerable<T> collection )
			: base( collection )
		{ }
	}
}
