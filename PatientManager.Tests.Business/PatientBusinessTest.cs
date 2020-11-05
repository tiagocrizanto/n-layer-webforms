using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientManager.Business;
using PatientManager.Domain.Dto;
using PatientManager.Domain.Entity;
using PatientManager.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PatientManager.Tests.Business
{
    [TestClass]
    public class PatientBusinessTest
    {
        private Mock<IPatientRepository> patientRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            patientRepository = new Mock<IPatientRepository>();
        }

        [TestMethod]
        public void GetPatientById_ReturnValidPatient()
        {
            var patient = new Patient
            {
                Email = "mail@mail.com",
                FirstName = "Tiago",
                LastName = "Crizanto",
                Gender = "M",
                Id = 1,
                Notes = "My notes",
                Phone = "+55 31 9 88989349"
            };

            patientRepository.Setup(x => x.GetPatientById(1)).Returns(patient);
            var patientBusiness = new PatientBusiness(patientRepository.Object);

            //Act
            var returnedPatient = patientBusiness.GetPatientById(1);

            //Assert
            Assert.AreEqual(patient.Id, returnedPatient.Id);
            Assert.AreEqual(patient.Email, returnedPatient.Email);
            Assert.AreEqual(patient.FirstName, returnedPatient.FirstName);
            Assert.AreEqual(patient.Gender, returnedPatient.Gender);
            Assert.AreEqual(patient.LastName, returnedPatient.LastName);
            Assert.AreEqual(patient.Notes, returnedPatient.Notes);
            Assert.AreEqual(patient.Phone, returnedPatient.Phone);
        }

        [TestMethod]
        public void GetPatientById_ReturnExpectedType()
        {
            var patient = new Patient
            {
                Email = "mail@mail.com",
                FirstName = "Tiago",
                LastName = "Crizanto",
                Gender = "M",
                Id = 1,
                Notes = "My notes",
                Phone = "+55 31 9 88989349"
            };

            patientRepository.Setup(x => x.GetPatientById(1)).Returns(patient);
            var patientBusiness = new PatientBusiness(patientRepository.Object);

            //Act
            var returnedPatient = patientBusiness.GetPatientById(1);

            //Assert
            Assert.IsInstanceOfType(returnedPatient, typeof(PatientDto));
        }

        [TestMethod]
        public void GetAllPatients_ReturnAllPatients()
        {
            //Arrange
            var patients = new List<Patient>
            {
                new Patient
                {
                    Email = "mail@mail.com",
                    FirstName = "Tiago",
                    LastName = "Crizanto",
                    Gender = "M",
                    Id = 1,
                    Notes = "My notes",
                    Phone = "+55 31 9 88989349"
                },
                new Patient
                {
                    Email = "mail1@mail1.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "M",
                    Id = 2,
                    Notes = "Other notes",
                    Phone = "No phone"
                },
            };

            patientRepository.Setup(x => x.GetAllPatients()).Returns(patients);
            var patientBusiness = new PatientBusiness(patientRepository.Object);

            //Act
            var returnedPatient = patientBusiness.GetAllPatients();

            //Assert
            Assert.AreEqual(patients.Count(), returnedPatient.Count());
        }

        [TestMethod]
        public void GetAllPatients_ReturnExpectedType()
        {
            //Arrange
            var patients = new List<Patient>
            {
                new Patient
                {
                    Email = "mail@mail.com",
                    FirstName = "Tiago",
                    LastName = "Crizanto",
                    Gender = "M",
                    Id = 1,
                    Notes = "My notes",
                    Phone = "+55 31 9 88989349"
                },
                new Patient
                {
                    Email = "mail1@mail1.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "M",
                    Id = 2,
                    Notes = "Other notes",
                    Phone = "No phone"
                },
            };

            patientRepository.Setup(x => x.GetAllPatients()).Returns(patients);
            var patientBusiness = new PatientBusiness(patientRepository.Object);

            //Act
            var returnedPatient = patientBusiness.GetAllPatients();

            //Assert
            Assert.IsInstanceOfType(returnedPatient, typeof(IEnumerable<PatientDto>));
        }
    }
}
