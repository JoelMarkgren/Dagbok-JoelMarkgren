using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Dagbok_JoelMarkgren.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dagbok_JoelMarkgren.ViewModels
{
	public partial class WeekViewModel : BaseViewModel
	{
		private string weekNotes = "";
		
		public string WeekNotes
		{
			get => weekNotes;
			set
			{
				SetProperty(ref weekNotes, value);
				OnPropertyChanged(nameof(HasData));
			}
		}
		[ObservableProperty]
		public int weekNumber;
		[JsonIgnore]
		public bool? HasData => WeekNotes.Length > 0;

	}
}
