using Dagbok_JoelMarkgren.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagbok_JoelMarkgren.Services
{
	public class WeekUpdateService
	{
		public event EventHandler OnUpdated;
		public WeekViewModel vm { get; set; }

		public void Update()
		{
			OnUpdated?.Invoke(this, EventArgs.Empty);
		}
	}
}
