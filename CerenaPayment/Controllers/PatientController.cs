using CerenaPayment.Models;
using CerenaPayment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CerenaPayment.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

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
            try
            {
                if (ModelState.IsValid)
                {
                    _patientRepository.Add(patient);
                    TempData["MensagemSucesso"] = "Paciente adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(patient);
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível adicionar o paciente, " +
                    $"tente novamente! Detalhe do erro {erro.Message}:";
                return RedirectToAction("Index");
            }
        }

    }
}
