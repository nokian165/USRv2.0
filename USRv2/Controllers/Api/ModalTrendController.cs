using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USRv2.Models;
using System.Data.Entity;
using USRv2.Dtos;
using AutoMapper;
using System.Globalization;


namespace USRv2.Controllers.Api
{
    public class ModalTrendController : ApiController
    {
        private ApplicationDbContext _context;

        public ModalTrendController()
        {
            _context = new ApplicationDbContext();
        }
        /*
        //GET /api/ModalTrend/1
        public IHttpActionResult GetDataModalTrend(int id)
        {

            var sample = _context.NumericSampleses.SingleOrDefault(c => c.TagId == id);

            if (sample == null)
                return NotFound();

         
            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(m => m.Names.Contains(query));

            var customesDtos = customersQuery

                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(Mapper.Map<NumericSamples, TrendDataDto>(sample));
        }
        */
        public IHttpActionResult GetDataModalTrendAll(int id, string dtDateStart, string dtDateEnd)
        {
            DateTime dtStart, dtEnd;

            DateTime.TryParseExact(dtDateStart, "dd.MM.yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dtStart);

            DateTime.TryParseExact(dtDateEnd, "dd.MM.yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dtEnd);

            var dataQuery = _context.NumericSampleses
                .Where(m => m.TagId == id && m.SampleDateTime <= dtEnd && m.SampleDateTime >= dtStart);

            var valuesDtos = dataQuery
                .ToList()
                .Select(Mapper.Map<NumericSamples, TrendDataDto>);
            return Ok(valuesDtos);
        }
    }
}
