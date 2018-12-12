using PatientDemographicsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PatientDemographicsApp.Controllers
{
    public class PatientDetailsController : Controller
    {
        /// <summary>
        /// GET method - get patient details
        /// </summary>
        /// <returns></returns>
        // GET: PatientDetails
        public ActionResult Index()
        {
            try
            {
                PatientModel _objPatient = new PatientModel();
                List<PatientModel> _objPatientDetails = new List<PatientModel>();
                Serializer _objSerializer = new Serializer();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:50271/");
                HttpResponseMessage response = client.GetAsync("api/Patient").Result;
                if (response.IsSuccessStatusCode)
                {
                    //HTTP GET
                    var readTask = response.Content.ReadAsAsync<List<Patient>>().Result;
                    foreach (var xmlData in readTask)
                    {
                        _objPatient = (PatientModel)_objSerializer.ConvertXmlStringtoObject<PatientModel>(xmlData.PatientObject.ToString());
                        _objPatientDetails.Add(_objPatient);
                    }
                }
                return View(_objPatientDetails);
            }
            catch (Exception ex)
            {
                throw new ExceptionLayer.ExceptionLayer("patient details could not be fetched due to following error ", ex.InnerException);
            }
            return View();
        }
    }
}