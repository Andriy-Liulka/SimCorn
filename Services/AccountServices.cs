using DomainModel;
using Services.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public sealed class AccountServices
    {
        public AccountServices(ApplicationContext context)
        {
            _context = context;
        }
        public DateTimeDto dtToTs(DateTime dt)
        {
            var dateTimeInt = new DateTimeDto
            {
                Year = dt.Year,
                Month = dt.Month,
                Day = dt.Day,
                Hours = dt.Hour,
                Minutes = dt.Minute,
                Seconds = dt.Second
            };
            return dateTimeInt;
        }
        public DateTime tsToDt(DateTimeDto dateTimeInt)
        {
            DateTime dt = new DateTime
                (
                dateTimeInt.Year,
                dateTimeInt.Month,
                dateTimeInt.Day,
                dateTimeInt.Hours,
                dateTimeInt.Minutes,
                dateTimeInt.Seconds
                );
            return dt;
        }
        public decimal GetAveragePrice(Account account)
        {
            DateTime startDate = account.Date;
            DateTime EndDate = account.Date.AddSeconds(10000);

            bool instrumentExist = _context.Accounts.Any(us => us.Instrument.Equals(account.Instrument));
            bool instrumentOwnerExist = _context.Accounts.Any(us => us.Instrument_owner.Equals(account.Instrument_owner));
            bool portfolioExist = _context.Accounts.Any(us => us.Portfolio.Equals(account.Portfolio));
            if (!instrumentExist || instrumentOwnerExist==false || portfolioExist==false)
            {
                return -1;
            }
            //TimeSpan diff = date.ToUniversalTime() - origin;
            //Math.Floor(diff.TotalSeconds);
            ICollection<Account> accounts=_context.Accounts.Where(us => (us.Date >= startDate && us.Date <= EndDate)
            &&us.Instrument.Equals(account.Instrument)&& us.Instrument_owner.Equals(account.Instrument_owner)&& us.Portfolio.Equals(account.Portfolio)).ToArray();
            decimal totalSum = default;
            foreach (var item in accounts)
            {
                totalSum += item.Price;
            }
            return totalSum;
        }
        private readonly ApplicationContext _context;
    }
}
