using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Html
{
	public enum AutoCompleteType
	{
		On,
		Off
	}

	public enum ContentEditableType
	{
		True,
		False,
		Inherit
	}

	public enum DirType
	{
		Ltr,
		Rtl,
		Auto
	}

	public enum DraggableType
	{
		True,
		False,
		Auto
	}

	public enum DropZoneType
	{
		Copy,
		Link,
		Move
	}

	public enum RelType
	{
		Alternate,
		Author,
		Bookmark,
		Help,
		License,
		Next,
		NoFollow,
		NoReferrer,
		PreFetch,
		Prev,
		Search,
		Tag
	}

	public enum TargetType
	{
		Blank,
		Self,
		Parent,
		Top
	}

	public enum TranslateType
	{
		Yes,
		No
	}
}
