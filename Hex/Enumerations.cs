using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	/// <summary>
	/// Enumerates the values for the autocomplete HTML attribute.
	/// </summary>
	public enum AutoCompleteType
	{
		/// <summary>
		/// Represents autocomplete="on".
		/// </summary>
		On,

		/// <summary>
		/// Represents autocomplete="off".
		/// </summary>
		Off
	}

	/// <summary>
	/// Enumerates the values for the contenteditable HTML attribute.
	/// </summary>
	public enum ContentEditableType
	{
		/// <summary>
		/// Represents contenteditable="true".
		/// </summary>
		True,

		/// <summary>
		/// Represents contenteditable="false".
		/// </summary>
		False,

		/// <summary>
		/// Represents contenteditable="inherit".
		/// </summary>
		Inherit
	}

	/// <summary>
	/// Enumerates the values for the crossorigin HTML attribute.
	/// </summary>
	public enum CrossOriginType
	{
		/// <summary>
		/// Represents crossorigin="anonymous".
		/// </summary>
		Anonymous,

		/// <summary>
		/// Represents crossorigin="use-credentials".
		/// </summary>
		Use_Credentials
	}

	/// <summary>
	/// Enumerates the values for the dir HTML attribute.
	/// </summary>
	public enum DirType
	{
		/// <summary>
		/// Represents dir="ltr".
		/// </summary>
		Ltr,

		/// <summary>
		/// Represents dir="rtl".
		/// </summary>
		Rtl,

		/// <summary>
		/// Represents dir="auto".
		/// </summary>
		Auto
	}

	/// <summary>
	/// Enumerates the values for the draggable HTML attribute.
	/// </summary>
	public enum DraggableType
	{
		/// <summary>
		/// Represents draggable="true".
		/// </summary>
		True,

		/// <summary>
		/// Represents draggable="false".
		/// </summary>
		False,

		/// <summary>
		/// Represents draggable="auto".
		/// </summary>
		Auto
	}

	/// <summary>
	/// Enumerates the values for the dropzone HTML attribute.
	/// </summary>
	public enum DropZoneType
	{
		/// <summary>
		/// Represents dropzone="copy".
		/// </summary>
		Copy,

		/// <summary>
		/// Represents dropzone="link".
		/// </summary>
		Link,

		/// <summary>
		/// Represents dropzone="move".
		/// </summary>
		Move
	}

	/// <summary>
	/// Enumerates the values for the enctype HTML attribute.
	/// </summary>
	public enum EncodingType
	{
		/// <summary>
		/// Represents enctype="multipart/form-data".
		/// </summary>
		Multipart,

		/// <summary>
		/// Represents enctype="application/x-www-form-urlencoded".
		/// </summary>
		UrlEncoding,

		/// <summary>
		/// Represents enctype="text/plain".
		/// </summary>
		Plain
	}

	/// <summary>
	/// Enumerates the values for the rel HTML attribute.
	/// </summary>
	public enum RelType
	{
		/// <summary>
		/// Represents rel="alternate".
		/// </summary>
		Alternate,

		/// <summary>
		/// Represents rel="author".
		/// </summary>
		Author,

		/// <summary>
		/// Represents rel="bookmark".
		/// </summary>
		Bookmark,

		/// <summary>
		/// Represents rel="help".
		/// </summary>
		Help,

		/// <summary>
		/// Represents rel="license".
		/// </summary>
		License,

		/// <summary>
		/// Represents rel="next".
		/// </summary>
		Next,

		/// <summary>
		/// Represents rel="nofollow".
		/// </summary>
		NoFollow,

		/// <summary>
		/// Represents rel="noreferrer".
		/// </summary>
		NoReferrer,

		/// <summary>
		/// Represents rel="prefetch".
		/// </summary>
		PreFetch,

		/// <summary>
		/// Represents rel="prev".
		/// </summary>
		Prev,

		/// <summary>
		/// Represents rel="search".
		/// </summary>
		Search,

		/// <summary>
		/// Represents rel="tag".
		/// </summary>
		Tag
	}

	/// <summary>
	/// Enumerates the values for the shape HTML attribute.
	/// </summary>
	public enum ShapeType
	{
		/// <summary>
		/// Represents shape="default".
		/// </summary>
		Default,

		/// <summary>
		/// Represents shape="rect".
		/// </summary>
		Rect,

		/// <summary>
		/// Represents shape="circle".
		/// </summary>
		Circle,

		/// <summary>
		/// Represents shape="poly".
		/// </summary>
		Poly
	}

	/// <summary>
	/// Enumerates the values for the target HTML attribute.
	/// </summary>
	public enum TargetType
	{
		/// <summary>
		/// Represents target="_blank".
		/// </summary>
		Blank,

		/// <summary>
		/// Represents target="_self".
		/// </summary>
		Self,

		/// <summary>
		/// Represents target="_parent".
		/// </summary>
		Parent,

		/// <summary>
		/// Represents target="_top".
		/// </summary>
		Top
	}

	/// <summary>
	/// Enumerates the values for the translate HTML attribute.
	/// </summary>
	public enum TranslateType
	{
		/// <summary>
		/// Represents translate="yes".
		/// </summary>
		Yes,

		/// <summary>
		/// Represents translate="no".
		/// </summary>
		No
	}

	/// <summary>
	/// Enumerates the values for the wrap HTML attribute.
	/// </summary>
	public enum WrapType
	{
		/// <summary>
		/// Represents wrap="hard".
		/// </summary>
		Hard,

		/// <summary>
		/// Represents wrap="soft".
		/// </summary>
		Soft
	}

	/// <summary>
	/// Enumerates the values for the wrap HTML attribute.
	/// </summary>
	public enum TimeFormat
	{
		/// <summary>
		/// Represents time format down to the minute.
		/// </summary>
		Minute,

		/// <summary>
		/// Represents time format down to the second.
		/// </summary>
		Second,

		/// <summary>
		/// Represents time format down to the millisecond.
		/// </summary>
		Millisecond
	}
}
