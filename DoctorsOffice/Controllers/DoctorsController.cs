using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public DoctorsController(DoctorsOfficeContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisDoctor = _db.Doctors
        .Include(doctor => doctor.Patients)
        .ThenInclude(join => join.Patient)
        .Include(doctor => doctor.Specialties)
        .ThenInclude(join => join.Specialty)
        .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }
    public ActionResult Edit(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientName");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor)
    {
      _db.Entry(doctor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = doctor.DoctorId });
    }
    public ActionResult Delete(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      _db.Doctors.Remove(thisDoctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeletePatient(int doctorId, int joinId)
    {
      var joinEntry = _db.DoctorPatient.FirstOrDefault(entry => entry.DoctorPatientId == joinId);
      _db.DoctorPatient.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = doctorId});
    }
    public ActionResult AddPatient(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientName");
      return View(thisDoctor);
    }
    [HttpPost]
    public ActionResult AddPatient(Doctor doctor, int PatientId)
    {
      if (PatientId != 0)
      {
      _db.DoctorPatient.Add(new DoctorPatient() { PatientId = PatientId, DoctorId = doctor.DoctorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = doctor.DoctorId});
    }
    [HttpPost]
    public ActionResult DeleteSpecialty(int doctorId, int joinId)
    {
      var joinEntry = _db.DoctorSpecialty.FirstOrDefault(entry => entry.DoctorSpecialtyId == joinId);
      _db.DoctorSpecialty.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = doctorId});
    }
    public ActionResult AddSpecialty(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "SpecialtyName");
      return View(thisDoctor);
    }
    [HttpPost]
    public ActionResult AddSpecialty(Doctor doctor, int SpecialtyId)
    {
      if (SpecialtyId != 0)
      {
      _db.DoctorSpecialty.Add(new DoctorSpecialty() { SpecialtyId = SpecialtyId, DoctorId = doctor.DoctorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = doctor.DoctorId});
    }
  }
}