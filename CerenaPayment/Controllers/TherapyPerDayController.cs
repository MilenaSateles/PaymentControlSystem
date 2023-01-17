using CerenaPayment.Models;
using CerenaPayment.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CerenaPayment.Controllers
{
    public class TherapyPerDayController : Controller
    {
        private readonly ITherapyRepository _therapyRepository;

        public TherapyPerDayController(ITherapyRepository therapyRepository)
        {
            _therapyRepository = therapyRepository;
        }

        public IActionResult SelectAll()
        {
            List<TherapyPerDayModel> therapy = _therapyRepository.SearchAll();
            return View(therapy);
        }
       
        public IActionResult Index([FromQuery] int day, [FromQuery] int month, [FromQuery] int year)
        {
            List<TherapyPerDayModel> therapy = _therapyRepository.ListByDate(day, month, year);
            return View(therapy);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TherapyPerDayModel therapy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _therapyRepository.Add(therapy);
                    TempData["MensagemSucesso"] = "Terapia adicionada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(therapy);
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível adicionar a terapia, " +
                    $"tente novamente! Detalhe do erro {erro.Message}:";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            TherapyPerDayModel therapy = _therapyRepository.ListById(id);
            return View(therapy);
        }

        [HttpPost]
        public IActionResult Edit(TherapyPerDayModel therapy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    therapy = _therapyRepository.Update(therapy);
                    TempData["MensagemSucesso"] = "Terapia atualizada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(therapy);
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar a terapia, " +
                    $"tente novamente! Detalhe do erro {erro.Message}:";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            TherapyPerDayModel therapy = _therapyRepository.ListById(id);
            return View(therapy);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _therapyRepository.Delete(id);
                if (deleted)
                {
                    TempData["MensagemSucesso"] = "Terapia apagada com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar a terapia";
                }
                return RedirectToAction("Index");
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar a terapia, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //public IActionResult DisplayDate(DateModel date)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string selectedDay = (date.Day).ToString();
        //            string selectedMonth = date.Month;
        //            string selectedYear = date.Year;
        //            string selectedDate = selectedDay + "/" + selectedMonth + "/" + selectedYear;
        //            var parseSelectedDate = DateTime.ParseExact(selectedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        //        }
        //        return View(date);
        //    }

        //    catch (Exception erro)
        //    {
        //        TempData["MensagemErro"] = $"Não foi possível selecionar a data, " +
        //            $"tente novamente! Detalhe do erro {erro.Message}:";
        //        return RedirectToAction("Index");
        //    }
        //}

    }
}

