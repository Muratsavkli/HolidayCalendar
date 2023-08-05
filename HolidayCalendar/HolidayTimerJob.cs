using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HolidayCalendar
{
	public class HolidayTimerJob : IHostedService, IDisposable
	{
		
		private readonly HolidayService _holidayService;
		private Timer? _timer;

		public HolidayTimerJob(HolidayService holidayService)
		{
			_holidayService = holidayService;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(7));

			return Task.CompletedTask;
		}

		private void DoWork(object? state)
		{
			_ = SaveHolidaysToDataBase();
		}

		private async Task SaveHolidaysToDataBase()
		{
			var holidays = await _holidayService.GetPublicHolidays(2023, "tr");

			foreach (var holiday in holidays)
			{
				await _holidayService.AddPublicHoliday(holiday);
			}

			await _holidayService.SavePublicHolidays();

		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			await SaveHolidaysToDataBase();

			_timer?.Change(Timeout.Infinite, 0);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			_timer?.Dispose();
		}

	}
}
