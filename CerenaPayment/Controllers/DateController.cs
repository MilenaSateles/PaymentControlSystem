using CerenaPayment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CerenaPayment.Controllers
{
    public class DateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(DateModel date)
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
