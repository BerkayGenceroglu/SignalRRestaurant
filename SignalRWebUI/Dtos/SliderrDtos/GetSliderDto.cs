﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.SliderrDtos
{
	public class GetSliderDto
	{
		public int SliderId { get; set; }
		public string Title1 { get; set; }
		public string Title2 { get; set; }
		public string Title3 { get; set; }
		public string Description1 { get; set; }
		public string Description2 { get; set; }
		public string Description3 { get; set; }
	}
}
