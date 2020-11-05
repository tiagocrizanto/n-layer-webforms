using PatientManager.Domain.Entity;
using PatientManager.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PatientManager.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string filePath = System.Web.HttpContext.Current.Server.MapPath("\\App_Data\\PatientData.xml");

        public void AddPatient(Patient patient)
        {
            var lastPatient = XDocument.Load(filePath)
                    .Descendants("patient");

            XElement x = new XElement("patient");
            x.Add(new XAttribute("id", !lastPatient.Any() ? "1" : (long.Parse(lastPatient.Last().Attribute("id").Value) + 1).ToString()));
            x.Add(new XAttribute("firstName", patient.FirstName));
            x.Add(new XAttribute("lastName", patient.LastName));
            x.Add(new XAttribute("phone", patient.Phone));
            x.Add(new XAttribute("gender", patient.Gender));
            x.Add(new XAttribute("email", patient.Email));
            x.Add(new XAttribute("notes", patient.Notes));
            x.Add(new XAttribute("isDeleted", "false"));
            XElement xml = XElement.Load(filePath);
            xml.Add(x);
            xml.Save(filePath);
        }

        public void DeletePatientById(long id)
        {
            // code to delete register

            //XElement xml = XElement.Load(filePath);
            //XElement x = xml.Elements().Where(p => p.Attribute("id").Value.Equals(id.ToString())).First();
            //if (x != null)
            //{
            //    x.Remove();
            //}
            //xml.Save(filePath);

            // keep the record and set flag as deleted - Linq to SQL example
            XElement xml = XElement.Load(filePath);
            var patient = (from p in xml.Elements()
                          where (long) p.Attribute("id") == id
                          select p).FirstOrDefault();

            if (patient != null)
            {
                patient.Attribute("isDeleted").SetValue("true");
            }
            xml.Save(filePath);
        }

        public void EditPatient(Patient patient)
        {
            XElement xml = XElement.Load(filePath);
            XElement x = xml.Elements().FirstOrDefault(p => p.Attribute("id").Value.Equals(patient.Id.ToString()));
            if (x != null)
            {
                x.Attribute("email").SetValue(patient.Email);
                x.Attribute("firstName").SetValue(patient.FirstName);
                x.Attribute("gender").SetValue(patient.Gender);
                x.Attribute("lastName").SetValue(patient.LastName);
                x.Attribute("notes").SetValue(patient.Notes);
                x.Attribute("phone").SetValue(patient.Phone);
            }
            xml.Save(filePath);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            XElement xml = XElement.Load(filePath);
            foreach (XElement x in xml.Elements())
            {
                Patient p = new Patient()
                {
                    Id = long.Parse(x.Attribute("id").Value),
                    Email = x.Attribute("email").Value,
                    FirstName = x.Attribute("firstName").Value,
                    Gender = x.Attribute("gender").Value,
                    LastName = x.Attribute("lastName").Value,
                    Notes = x.Attribute("notes").Value,
                    Phone = x.Attribute("phone").Value,
                    IsDeleted = bool.Parse(x.Attribute("isDeleted").Value)
                };
                patients.Add(p);
            }

            return patients.Where(x => !x.IsDeleted);
        }

        public Patient GetPatientById(long id)
        {
            XElement xml = XElement.Load(filePath);
            XElement patient = xml.Elements().FirstOrDefault(p => p.Attribute("id").Value.Equals(id.ToString()));

            if(patient != null)
            {
                return new Patient()
                {
                    Id = long.Parse(patient.Attribute("id").Value),
                    Email = patient.Attribute("email").Value,
                    FirstName = patient.Attribute("firstName").Value,
                    Gender = patient.Attribute("gender").Value,
                    LastName = patient.Attribute("lastName").Value,
                    Notes = patient.Attribute("notes").Value,
                    Phone = patient.Attribute("phone").Value
                };
            }

            return null;
        }
    }
}
