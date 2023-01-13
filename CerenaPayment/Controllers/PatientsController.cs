using Microsoft.AspNetCore.Mvc;

namespace CerenaPayment.Controllers
{
    public class PatientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientModel patient)
        {
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _contatoRepositorio.Adicionar(contato);
        //            TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
        //            return RedirectToAction("Index");
        //        }
        //        return View(contato);
        //    }

        //    catch (Exception erro)
        //    {
        //        TempData["MensagemErro"] = $"Não foi possível cadastrar seu contato, " +
        //            $"tente novamente! Detalhe do erro {erro.Message}:";
        //        return RedirectToAction("Index");
        //    }
        //}

    }
}
