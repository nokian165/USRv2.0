using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Globalization;
using USRv2.Models;
using USRv2.ViewModels;

namespace USRv2.Controllers
{
    public class ParametersController : Controller
    {
        private ApplicationDbContext _context;
        public ParametersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // Index ----------------------------------------------------------------------------------------------
        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult Units()
        {
            var units = _context.Units.ToList();

            return View(units);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult Plcs()
        {
            var plcs = _context.Plcs.ToList();

            return View(plcs);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult Labels()
        {
            var labels = _context.Labels.ToList();

            return View(labels);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult Titles()
        {
            var titles = _context.Titles.ToList();

            return View(titles);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ViewResult MainTable()
        {
            var mainTables = _context.MainTables
                .Include(m => m.Plc)
                .Include(m => m.Label)
                .Include(m => m.Title)
                .Include(m => m.Unit)
                .ToList();

            return View(mainTables);
        }

        [Authorize]
        public ActionResult DayReport(string dtDate)
        {
            var vm = new MainTableViewModel();

            DateTime dtStart, dtEnd;

            if (dtDate == null)
                dtDate = DateTime.Now.ToString("dd.MM.yyyy") + " 08:00:00";
            else
                dtDate = dtDate + " 08:00:00";

            DateTime.TryParseExact(dtDate, "dd.MM.yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dtStart);

            if (dtStart.Year == 1)
                return RedirectToAction("DayReport", "Parameters");


            if (DateTime.Now.Hour < 8)
                dtStart = dtStart.AddDays(-1);

            ViewBag.StartDay = dtStart.Day;
            ViewBag.StartMonthYear = dtStart.ToString("MM.yyyy");
            dtEnd = dtStart.AddDays(1);
            ViewBag.EndDay = dtEnd.Day;
            ViewBag.EndMonthYear = dtEnd.ToString("MM.yyyy");

            DateTime dt8 = dtStart, dt8Added24 = dtStart.AddHours(24), dt9 = dtStart.AddHours(1), dt10 = dtStart.AddHours(2), dt11 = dtStart.AddHours(3), dt12 = dtStart.AddHours(4),
                dt13 = dtStart.AddHours(5), dt14 = dtStart.AddHours(6), dt15 = dtStart.AddHours(7), dt16 = dtStart.AddHours(8), dt17 = dtStart.AddHours(9),
                dt18 = dtStart.AddHours(10), dt19 = dtStart.AddHours(11), dt20 = dtStart.AddHours(12), dt21 = dtStart.AddHours(13), dt22 = dtStart.AddHours(14),
                dt23 = dtStart.AddHours(15), dt0 = dtStart.AddHours(16), dt1 = dtStart.AddHours(17), dt2 = dtStart.AddHours(18), dt3 = dtStart.AddHours(19),
                dt4 = dtStart.AddHours(20), dt5 = dtStart.AddHours(21), dt6 = dtStart.AddHours(22), dt7 = dtStart.AddHours(23);

            vm.MainTables = _context.MainTables
                .Include(m => m.Plc)
                .Include(m => m.Label)
                .Include(m => m.Title)
                .Include(m => m.Unit)
                .Include(m => m.MainTablePropertie)
                .ToList();
            vm.Plcs = _context.Plcs.ToList();

            
            var isEmptyMaintables = _context.MainTables.SingleOrDefault(c => c.Id == 1);
            var isEmptyNumericSamples = _context.NumericSampleses.FirstOrDefault(c => c.TagId == 1);
            // Устранение эксепшена при первой инициализации пустой базы данных
            if (isEmptyMaintables == null || isEmptyNumericSamples == null)
            {
                vm.NumericSampleAverages = _context.MainTables.Select(m => new NumericSampleAverage
                {
                    Id = m.Id,
                    Average0 = null, Average1 = null, Average2 = null, Average3 = null, Average4 = null,
                    Average5 = null, Average6 = null, Average7 = null, Average8 = null, Average9 = null,
                    Average10 = null, Average11 = null, Average12 = null, Average13 = null, Average14 = null,
                    Average15 = null, Average16 = null, Average17 = null, Average18 = null, Average19 = null,
                    Average20 = null, Average21 = null, Average22 = null, Average23 = null,
                    Minimum8Till20 = null, Minimum20Till8 = null, Maximum8Till20 = null, Maximum20Till8 = null
                }).ToList();
            }
            else
            {
                vm.NumericSampleAverages = _context.MainTables.Select(m => new NumericSampleAverage
                {
                    Id = m.Id,
                    Average0 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt1 && a.SampleDateTime >= dt0 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average1 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt2 && a.SampleDateTime >= dt1 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average2 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt3 && a.SampleDateTime >= dt2 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average3 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt4 && a.SampleDateTime >= dt3 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average4 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt5 && a.SampleDateTime >= dt4 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average5 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt6 && a.SampleDateTime >= dt5 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average6 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt7 && a.SampleDateTime >= dt6 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average7 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt8Added24 &&
                                    a.SampleDateTime >= dt7 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average8 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt9 && a.SampleDateTime >= dt8 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average9 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt10 && a.SampleDateTime >= dt9 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average10 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt11 && a.SampleDateTime >= dt10 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average11 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt12 && a.SampleDateTime >= dt11 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average12 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt13 && a.SampleDateTime >= dt12 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average13 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt14 && a.SampleDateTime >= dt13 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average14 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt15 && a.SampleDateTime >= dt14 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average15 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt16 && a.SampleDateTime >= dt15 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average16 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt17 && a.SampleDateTime >= dt16 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average17 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt18 && a.SampleDateTime >= dt17 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average18 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt19 && a.SampleDateTime >= dt18 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average19 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt20 && a.SampleDateTime >= dt19 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average20 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt21 && a.SampleDateTime >= dt20 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average21 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt22 && a.SampleDateTime >= dt21 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average22 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt23 && a.SampleDateTime >= dt22 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                    Average23 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt0 && a.SampleDateTime >= dt23 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),

                    Minimum8Till20 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt20 && a.SampleDateTime >= dt8 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Min(),
                    Minimum20Till8 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt8Added24 &&
                                    a.SampleDateTime >= dt20 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Min(),
                    Maximum8Till20 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt20 && a.SampleDateTime >= dt8 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Max(),
                    Maximum20Till8 = m.NumericSamples
                        .Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime < dt8Added24 &&
                                    a.SampleDateTime >= dt20 &&
                                    a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >=
                                    a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Max()


                }).ToList();
            }

            return View(vm);
        }

        
        [Authorize]
        public ActionResult RandomReport(string dtDateStart, string dtDateEnd)
        {
            var vm = new MainTableViewModel();

            DateTime dtStart, dtEnd;

            if (dtDateStart == null || dtDateEnd == null)
            {
                dtDateStart = DateTime.Now.ToString("dd.MM.yyyy") + " 00:00:00";
                dtDateEnd = DateTime.Now.ToString("dd.MM.yyyy") + " 23:59:59";
            }

            DateTime.TryParseExact(dtDateStart, "dd.MM.yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dtStart);
            DateTime.TryParseExact(dtDateEnd, "dd.MM.yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dtEnd);



            if (dtStart.Year == 1 || dtEnd.Year == 1 || dtEnd <= dtStart)
                return RedirectToAction("RandomReport", "Parameters");

            ViewBag.StartTime = dtStart.ToString("HH:mm:ss");
            ViewBag.StartDay = dtStart.Day;
            ViewBag.StartMonthYear = dtStart.ToString("MM.yyyy");
            ViewBag.EndTime = dtEnd.ToString("HH:mm:ss");
            ViewBag.EndDay = dtEnd.Day;
            ViewBag.EndMonthYear = dtEnd.ToString("MM.yyyy");

            vm.MainTables = _context.MainTables
                .Include(m => m.Plc)
                .Include(m => m.Label)
                .Include(m => m.Title)
                .Include(m => m.Unit)
                .Include(m => m.MainTablePropertie)
                .ToList();
            vm.Plcs = _context.Plcs.ToList();

            vm.NumericSampleRandoms = _context.MainTables.Select(m => new NumericSampleRandom
            {
                Id = m.Id,
                AverageRandom = m.NumericSamples.Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime <= dtEnd && a.SampleDateTime >= dtStart && a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >= a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Average(),
                SumRandom = m.NumericSamples.Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime <= dtEnd && a.SampleDateTime >= dtStart && a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >= a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Sum(),
                MinimumRandom = m.NumericSamples.Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime <= dtEnd && a.SampleDateTime >= dtStart && a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >= a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Min(),
                MaximumRandom = m.NumericSamples.Where(a => a.TagId == a.MainTable.Id && a.SampleDateTime <= dtEnd && a.SampleDateTime >= dtStart && a.SampleValue <= a.MainTable.MainTablePropertie.CutOffMax && a.SampleValue >= a.MainTable.MainTablePropertie.CutOffMin).Select(d => d.SampleValue).Max()

            }).ToList();



            return View(vm);
        }


        [Authorize(Roles = RoleName.ManageSettings)]
        public ViewResult Limits()
        {
            var limits = _context.MainTableProperties
                .Include(m => m.MainTable.Title)
                .ToList();

            return View(limits);
        }

        // Edit ----------------------------------------------------------------------------------------------
        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult UnitEdit(int id)
        {
            var unit = _context.Units.SingleOrDefault(c => c.Id == id);

            if (unit == null)
                return HttpNotFound();
            return View("UnitForm", unit);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult PlcEdit(int id)
        {
            var plc = _context.Plcs.SingleOrDefault(c => c.Id == id);

            if (plc == null)
                return HttpNotFound();
            return View("PlcForm", plc);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult LabelEdit(int id)
        {
            var label = _context.Labels.SingleOrDefault(c => c.Id == id);

            if (label == null)
                return HttpNotFound();
            return View("LabelForm", label);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult TitleEdit(int id)
        {
            var title = _context.Titles.SingleOrDefault(c => c.Id == id);

            if (title == null)
                return HttpNotFound();
            return View("TitleForm", title);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult MainTableEdit(int id)
        {
            var mainTables = _context.MainTables.SingleOrDefault(c => c.Id == id);

            if (mainTables == null)
                return HttpNotFound();

            var viewModel = new MainTableFormViewModel
            {
                MainTable = mainTables,
                Plcs = _context.Plcs.ToList(),
                Labels = _context.Labels.ToList(),
                Titles = _context.Titles.ToList(),
                Units = _context.Units.ToList()
            };

            return View("MainTableForm", viewModel);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult LimitsEdit(int id)
        {
            var mainTableProperties = _context.MainTableProperties.SingleOrDefault(c => c.MainTablePropertieId == id);

            if (mainTableProperties == null)
                return HttpNotFound();
            return View("LimitsForm", mainTableProperties);
        }

        // Save ----------------------------------------------------------------------------------------------

        [Authorize(Roles = RoleName.ManageSettings)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UnitSave(Unit unit)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Unit
                {
                    Name = unit.Name,
                    Id = unit.Id
                };
                return View("UnitForm", viewModel);
            }

            if (unit.Id == 0)
                _context.Units.Add(unit);
            else
            {
                var unitInDb = _context.Units.Single(c => c.Id == unit.Id);
                unitInDb.Name = unit.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Units", "Parameters");
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PlcSave(Plc plc)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Plc
                {
                    DepName = plc.DepName,
                    Name = plc.Name,
                    Id = plc.Id
                };
                return View("PlcForm", viewModel);
            }

            if (plc.Id == 0)
                _context.Plcs.Add(plc);
            else
            {
                var plcInDb = _context.Plcs.Single(c => c.Id == plc.Id);
                plcInDb.Name = plc.Name;
                plcInDb.DepName = plc.DepName;
            }
            _context.SaveChanges();
            return RedirectToAction("Plcs", "Parameters");
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LabelSave(Label label)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Label
                {
                    Name = label.Name,
                    Id = label.Id
                };
                return View("LabelForm", viewModel);
            }

            if (label.Id == 0)
                _context.Labels.Add(label);
            else
            {
                var labelInDb = _context.Labels.Single(c => c.Id == label.Id);
                labelInDb.Name = label.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Labels", "Parameters");
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult TitleSave(Title title)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Title
                {
                    Name = title.Name,
                    Id = title.Id
                };
                return View("TitleForm", viewModel);
            }

            if (title.Id == 0)
                _context.Titles.Add(title);
            else
            {
                var titleInDb = _context.Titles.Single(c => c.Id == title.Id);
                titleInDb.Name = title.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Titles", "Parameters");
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult MainTableSave(MainTable mainTable)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MainTableFormViewModel
                {
                    MainTable = mainTable,
                    Plcs = _context.Plcs.ToList(),
                    Units = _context.Units.ToList(),
                    Labels = _context.Labels.ToList(),
                    Titles = _context.Titles.ToList()
                };
                return View("MainTableForm", viewModel);
            }

            if (mainTable.Id == 0)
            {
                _context.MainTables.Add(mainTable);
                _context.SaveChanges();
                //duplicate new id parameter to IdAsc for asc or desc
                var mainTableInDb = _context.MainTables.Single(c => c.Id == mainTable.Id);

                mainTableInDb.IdAsc = mainTable.Id;
                //  _context.SaveChanges();
                // populate MainTablePropertie table
                var viewModel = new MainTablePropertie
                {
                    MainTablePropertieId = mainTable.Id,
                    SclMax = 100,
                    SclMin = 0,
                    IsCutOffMax = false,
                    CutOffMax = 100,
                    IsCutOffMin = false,
                    CutOffMin = 0
                };

                _context.MainTableProperties.Add(viewModel);
                _context.SaveChanges();
            }

            else
            {
                var mainTableInDb = _context.MainTables.Single(c => c.Id == mainTable.Id);
                mainTableInDb.LabelId = mainTable.LabelId;
                mainTableInDb.PlcId = mainTable.PlcId;
                mainTableInDb.UnitId = mainTable.UnitId;
                mainTableInDb.TitleId = mainTable.TitleId;
                mainTableInDb.IsContainer = mainTable.IsContainer;
                mainTableInDb.Container = mainTable.Container;
                _context.SaveChanges();
            }
            // _context.SaveChanges();
            return RedirectToAction("MainTable", "Parameters");
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LimitsSave(MainTablePropertie mainTablePropertie)
        {
            if (!ModelState.IsValid)
            {
                return View("LimitsForm", mainTablePropertie);
            }

            if (mainTablePropertie.MainTablePropertieId == 0)
                _context.MainTableProperties.Add(mainTablePropertie);
            else
            {
                var mainTablePropertieInDb = _context.MainTableProperties.Single(c => c.MainTablePropertieId == mainTablePropertie.MainTablePropertieId);

                if (!mainTablePropertie.IsCutOffMax)
                    mainTablePropertieInDb.CutOffMax = mainTablePropertie.SclMax;
                else
                    mainTablePropertieInDb.CutOffMax = mainTablePropertie.CutOffMax;

                if (!mainTablePropertie.IsCutOffMin)
                    mainTablePropertieInDb.CutOffMin = mainTablePropertie.SclMin;
                else
                    mainTablePropertieInDb.CutOffMin = mainTablePropertie.CutOffMin;

                mainTablePropertieInDb.IsCutOffMax = mainTablePropertie.IsCutOffMax;
                mainTablePropertieInDb.IsCutOffMin = mainTablePropertie.IsCutOffMin;
                mainTablePropertieInDb.SclMax = mainTablePropertie.SclMax;
                mainTablePropertieInDb.SclMin = mainTablePropertie.SclMin;

            }
            _context.SaveChanges();
            return RedirectToAction("Limits", "Parameters");
        }
        // New ----------------------------------------------------------------------------------------------

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult UnitNew()
        {
            var viewModel = new Unit { };

            return View("UnitForm", viewModel);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult PlcNew()
        {
            var viewModel = new Plc { };

            return View("PlcForm", viewModel);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult LabelNew()
        {
            var viewModel = new Label { };

            return View("LabelForm", viewModel);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult TitleNew()
        {
            var viewModel = new Title { };

            return View("TitleForm", viewModel);
        }

        [Authorize(Roles = RoleName.ManageSettings)]
        public ActionResult MainTableNew()
        {
            var units = _context.Units.ToList();
            var plcs = _context.Plcs.ToList();
            var titles = _context.Titles.ToList();
            var labels = _context.Labels.ToList();
            var viewModel = new MainTableFormViewModel
            {
                MainTable = new MainTable(),
                Units = units,
                Plcs = plcs,
                Titles = titles,
                Labels = labels

            };
            return View("MainTableForm", viewModel);
        }
    }
}