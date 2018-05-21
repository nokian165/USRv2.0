using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USRv2.Models;
using USRv2.Dtos;

namespace USRv2.Controllers.Api
{
    public class LabelsController : ApiController
    {
        private ApplicationDbContext _context;
        public LabelsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public void DeleteLabel(ChangeRowsTableDto сhangeRowsTableDto)
        {
            var rows = сhangeRowsTableDto.RowsIds.ToList();
            foreach (var row in rows)
            {
                var result = _context.Labels.SingleOrDefault(c => c.Id == row);
                _context.Labels.Remove(result);
                _context.SaveChanges();
            }

        }




}
}

