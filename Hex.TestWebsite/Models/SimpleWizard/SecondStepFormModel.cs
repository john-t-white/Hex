﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hex.TestWebsite.Models.SimpleWizard
{
	public class SecondStepFormModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string ConfirmPassword { get; set; }
	}
}