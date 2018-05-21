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
    public class MainTableController : ApiController
    {

        private ApplicationDbContext _context;
        public MainTableController()
        {
            _context = new ApplicationDbContext();
        }

        //DELETE /api/mainTable/1
        [HttpDelete]
        public void DeleteMainTable(int id)
        {
            var mainTablePropertieInDb = _context.MainTableProperties.SingleOrDefault(c => c.MainTablePropertieId == id);
            var mainTableInDb = _context.MainTables.SingleOrDefault(c => c.Id == id);

            if ((mainTableInDb == null) || (mainTablePropertieInDb == null))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.MainTableProperties.Remove(mainTablePropertieInDb);
            _context.MainTables.Remove(mainTableInDb);
            _context.SaveChanges();
        }

        //PUT /api/mainTable/1
        [HttpPut]
        public void MoveTagOutOfView(int id, MoveTagOutOfViewDto moveTagOutOfViewDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var mainTableInDb = _context.MainTables.SingleOrDefault(c => c.Id == id);

            if (mainTableInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            mainTableInDb.IsOutOfView = moveTagOutOfViewDto.IsOutOfView;

            _context.SaveChanges();

        }

        [HttpPost]
        public IHttpActionResult UpdateRowsTable(ChangeRowsTableDto changeRowsTable)
        {
            var rows = _context.MainTables.ToList();
            var rowsForIndexSearch = changeRowsTable.RowsIds.ToList();

            foreach (var row in rows)
            {
                int myIndex = rowsForIndexSearch.IndexOf(row.Id);
                row.IdAsc = myIndex;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}