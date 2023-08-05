using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayCalendar
{
	public class PublicHolidayContext:DbContext
	{
		public DbSet<PublicHoliday> PublicHolidays { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
			.UseSqlServer(@"server=(localdb)\mssqllocaldb; Database=PublicHolidays;Trusted_Connection=True");
		}
	}
}
