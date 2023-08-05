using HolidayCalendar;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;


public class PublicHoliday
{

	//Wed projesinde Bu model için PK'e ihtiyaç olmayacaksa OnModelCreating HasNoKey i değiştireceğizD
	public int Id { get; set; }
	public DateTime Date { get; set; }
	public string LocalName { get; set; }
	public string Name { get; set; }
	public string CountryCode { get; set; }
	public bool Fixed { get; set; }
	public bool Global { get; set; }

	[NotMapped]
	public string[] Counties { get; set; }
	public int? LaunchYear { get; set; }

	[NotMapped]
	public string[] Types { get; set; }

}
