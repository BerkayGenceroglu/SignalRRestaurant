﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult NotFoundPage404()
		{
			return View();
		}
	}
}
