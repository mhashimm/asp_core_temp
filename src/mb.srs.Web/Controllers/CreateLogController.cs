using mb.srs.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mb.srs.Core.Entities;

namespace mb.srs.Web.Controllers
{
    public class CreateLogController : Controller
    {
        // GET: CreateLog
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateLog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLogViewModel viewModel)
        {
            string _view = null;

            switch (viewModel.Circumstances) {
                case Circumstances.vaccinated: 
                    _view = "VaccineSideEffect";
                    break;
                case Circumstances.contact_at_work:
                case Circumstances.contact_away_from_work:
                    if (viewModel.FullyVaccinated)
                        _view = "ContactVaccinated";
                    else
                        _view = "ContactUnvaccinated";
                    break;
                case Circumstances.symptomatic:
                    if (viewModel.FullyVaccinated)
                        _view = "SymptomVaccinated";
                    else
                        _view = "SymptomUnvaccinated";
                    break;
                default: break;
            }

            try
            {
                return View(_view);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: CreateLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateLog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateLog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateLog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
