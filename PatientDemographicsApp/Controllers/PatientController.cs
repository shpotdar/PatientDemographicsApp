using PatientDemographicsApp.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;

namespace PatientDemographicsApp.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// action method for POST - create patient information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(PatientViewModel model)
        {
            try
            {
                PatientModel _objPatientModel = new PatientModel();
                TelephoneNumbers _ObjtelephoneNumbers = new TelephoneNumbers();
                Serializer _objSerializer = new Serializer();

                _objPatientModel.Forename = model.Forename;
                _objPatientModel.Surname = model.Surname;
                _objPatientModel.DOB = model.DOB;
                _objPatientModel.Gender = model.Gender;
                _ObjtelephoneNumbers.HomeNumber = model.HomeNumber;
                _ObjtelephoneNumbers.WorkNumber = model.WorkNumber;
                _ObjtelephoneNumbers.MobileNumber = model.MobileNumber;
                _objPatientModel.TelephoneNumbers = _ObjtelephoneNumbers;

                string xmlData = _objSerializer.ConvertObjectToXMLString(_objPatientModel);
                Patient _objPatient = new Patient();
                _objPatient.PatientObject = xmlData;


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50271/api/Patient");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Patient>("Patient", _objPatient);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToRoute(new
                        {
                            controller = "Home",
                            action = "Index"
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ExceptionLayer.ExceptionLayer("patient details cannot be created due to following error ", ex.InnerException);
            }
            return View();
        }
    }
}