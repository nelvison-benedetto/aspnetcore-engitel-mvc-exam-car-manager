using EngitelExam.Web.Models.Database;
using EngitelExam.Web.Models.ViewModels;
using EngitelExam.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EngitelExam.Web.Services.Implementations
{
    public class CalendarioService : ICalendarioService
    {

        public async Task<CalendarioVM> GetCalendarioMeseAsync(int year, int month)
        {
            using (var db = new EngitelDbContext()) {
                db.Database.Log = msg => Console.WriteLine(msg);
                var firstDay = new DateTime(year, month, 1);
                var lastDay = firstDay.AddMonths(1).AddDays(-1);

                var days = db.Day
                    .Where(d => d.TheDate >= firstDay && d.TheDate <= lastDay)
                    .Include(d => d.Appuntamento)
                    .ToListAsync();
                var calendario = new CalendarioVM
                {
                    Year = year,
                    Month = month,
                    Days = days.Select(d => new DayVM
                    {
                        DayId = d.DayId,
                        Date = d.TheDate,
                        hasAppointment = d.Appuntamento.Any(),
                        IsAvailable = !d.Appuntamento.Any(a => a.IsAvailable == false)
                    }).ToList()
                };
                return calendario;
            }
        }


    }
}