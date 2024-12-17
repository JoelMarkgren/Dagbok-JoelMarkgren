using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dagbok_JoelMarkgren.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dagbok_JoelMarkgren.ViewModels
{
	public partial class WeekPageViewModel : BaseViewModel
	{
		private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "weeknotes.json");
		private readonly WeekUpdateService weekUpdateService;

		public IRelayCommand ClearCommand => new RelayCommand(Clear);

		public IRelayCommand SaveWeekNotesCommand => new RelayCommand(async () => await SaveWeekNotes());

		[ObservableProperty]
		public WeekViewModel weekVM;


		public WeekPageViewModel(WeekUpdateService weekUpdateService)
		{
			this.weekUpdateService = weekUpdateService;
			WeekVM = weekUpdateService.vm;
		}
		
		public void Clear()
		{
			if (WeekVM.WeekNotes.Length > 0)
			{
				WeekVM.WeekNotes = string.Empty;
			}
		}
		public async Task SaveWeekNotes()
		{
			if (WeekVM == null) return;

			var savedWeekList = new List<WeekViewModel>();
			if (File.Exists(filePath))
			{
				string existingData = await File.ReadAllTextAsync(filePath);
				savedWeekList = JsonSerializer.Deserialize<List<WeekViewModel>>(existingData) ?? new List<WeekViewModel>();
			}

			var existingWeek = savedWeekList.FirstOrDefault(w => w.WeekNumber == WeekVM.WeekNumber);
			if (existingWeek != null)
			{
				existingWeek.WeekNotes = WeekVM.WeekNotes;
			}
			else
			{
				savedWeekList.Add(WeekVM);
			}
			string updateData = JsonSerializer.Serialize(savedWeekList);
			await File.WriteAllTextAsync(filePath, updateData);
			
			weekUpdateService.Update();
			await Shell.Current.GoToAsync("..");
		}

	}
}
