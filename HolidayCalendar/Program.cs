using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HolidayCalendar
{
	internal class Program
	{
		static async Task Main()
		{
			List<PublicHoliday> publicHolidays = new List<PublicHoliday>();

			HolidayService holidayService = new HolidayService(new PublicHolidayContext());
			publicHolidays = await holidayService.GetPublicHolidays(2023, "tr");
			
			foreach(var holiday in publicHolidays)
			{
				await holidayService.AddPublicHoliday(holiday);
			}
			
			await holidayService.SavePublicHolidays();
		}
	}
}