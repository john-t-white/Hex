﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Extensions
{
	public static class BooleanExtensions
	{
		public static string ToLowerString( this bool boolean )
		{
			return boolean.ToString().ToLower();
		}
	}
}