using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dagbok_JoelMarkgren.Services;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Dagbok_JoelMarkgren.ViewModels
{
	public partial class MainViewModel : BaseViewModel
	{
		private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "weeknotes.json");
		private readonly WeekUpdateService weekUpdateService;
		[ObservableProperty]
		ObservableCollection<WeekViewModel> weekList = new();

		[ObservableProperty]
		WeekViewModel selectedWeek = new WeekViewModel();


		public MainViewModel(WeekUpdateService weekUpdateService)
		{
			Title = "Din LIA-Dagbok";			
			this.weekUpdateService = weekUpdateService;
			weekUpdateService.OnUpdated += Week_OnUpdated;
			LoadSavedWeeks();
		}

		[RelayCommand]
		async Task GoToSelectedWeek(WeekViewModel selectedWeek)
		{
			if (selectedWeek is null)
			{
				return;
			}
			else
			{
				weekUpdateService.vm = selectedWeek;
				await Shell.Current.GoToAsync($"{nameof(SelectedWeekPage)}", true, new Dictionary<string, object> { { "SelectedWeek", selectedWeek } });
			}
		}
		public void LoadSavedWeeks()
		{
			try
			{
				if (File.Exists(filePath))
				{
					string data = File.ReadAllText(filePath);
					var weeks = JsonSerializer.Deserialize<ObservableCollection<WeekViewModel>>(data);
					if (weeks != null)
					{
						WeekList = weeks;
					}
					else
					{
						Debug.WriteLine("Deserialized data is null, using default weeks.");
					}
				}
				if (WeekList.Count == 0)
				{
					WeekList = CreateWeeks();
				}
				
			}
			catch (JsonException ex)
			{
				Debug.WriteLine($"Error deserializing JSON: {ex.Message}");
			}
		}

		private void Week_OnUpdated(object? sender, EventArgs e)
		{
			try
			{
				string serializedData = JsonSerializer.Serialize(WeekList);
				File.WriteAllText(filePath, serializedData);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"{ex.Message}");
			}
		}
		private ObservableCollection<WeekViewModel> CreateWeeks()
		{
			return new ObservableCollection<WeekViewModel>()
			{
				new WeekViewModel() { WeekNumber = 5, WeekNotes = "" },
				new WeekViewModel() { WeekNumber = 6, WeekNotes = "" },
				new WeekViewModel() { WeekNumber = 7, WeekNotes = "" },
				new WeekViewModel() { WeekNumber = 8, WeekNotes = "" },
				new WeekViewModel() { WeekNumber = 9 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 10 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 11 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 12 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 13 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 14 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 15 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 16 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 17 , WeekNotes = ""},
				new WeekViewModel() { WeekNumber = 18 , WeekNotes = ""},
			};
		}

	}
}

