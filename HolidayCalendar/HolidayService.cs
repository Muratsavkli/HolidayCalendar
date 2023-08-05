using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace HolidayCalendar
{
	public class HolidayService
	{
		private readonly PublicHolidayContext _context;
		public HolidayService(PublicHolidayContext context)
		{
			_context= context;
		}

		public async Task<List<PublicHoliday>> GetPublicHolidays(int year, string countryCode)
		{
			var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

			var httpClient = new HttpClient()
			{
				BaseAddress = new Uri("https://date.nager.at/api/")
			};

			List<PublicHoliday>? holidayList = await httpClient.GetFromJsonAsync<List<PublicHoliday>>
				($"v3/PublicHolidays/{year}/{countryCode}", jsonSerializerOptions);


			return holidayList;
		}

		public async Task AddPublicHoliday(PublicHoliday holiday)
		{
			await _context.AddAsync(holiday);
		}

		public async Task SavePublicHolidays()
		{
			await _context.SaveChangesAsync();
		}
	}
}
