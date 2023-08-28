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
			.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
							Initial Catalog=PublicHolidays;
							Integrated Security=True;
							Connect Timeout=30;
							Encrypt=False;
							Trust Server Certificate=False;
							Application Intent=ReadWrite;
							Multi Subnet Failover=False");
		}
	}
}
