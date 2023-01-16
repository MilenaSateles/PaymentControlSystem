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
            List<PatientModel> patient = _patientRepository.SearchAll();
            return View(patient);
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

        public IActionResult Edit(int id)
        {
            PatientModel patient = _patientRepository.ListById(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(PatientModel patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    patient = _patientRepository.Update(patient);
                    TempData["MensagemSucesso"] = "Paciente atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(patient);
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar o paciente, " +
                    $"tente novamente! Detalhe do erro {erro.Message}:";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            PatientModel patient = _patientRepository.ListById(id);
            return View(patient);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _patientRepository.Delete(id);
                if (deleted)
                {
                    TempData["MensagemSucesso"] = "Paciente apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar o paciente";
                }
                return RedirectToAction("Index");
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o paciente, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
