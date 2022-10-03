using Autofac.Extras.Moq;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Models;
using FysioAvansWebApp.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace F.Tests
{
    public class PatientTest
    {
        [Fact]
        public void CanGetPatients()
        {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IPatientDetailRepo>().Setup(x => x.GetAll()).Returns(GetSamplePatients());
                var cls = mock.Create<IPatientDetailRepo>();
                var expected = GetSamplePatients().ToList();

                var actual = cls.GetAll().ToList();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }
        }

        private IEnumerable<PatientDetailsViewModel> GetSamplePatients()
        {
            IEnumerable<PatientDetailsViewModel> output = new List<PatientDetailsViewModel>
            {
                new PatientDetailsViewModel {
                    Firstname = "Jop",
                    Lastname = "Rill",
                    Phonenumber = "7372192853"
                },
                new PatientDetailsViewModel {
                    Firstname = "Thijs",
                    Lastname = "Rill",
                    Phonenumber = "8456456546"
                },
                new PatientDetailsViewModel {
                    Firstname = "Syb",
                    Lastname = "Rill",
                    Phonenumber = "3546675454"
                }
            };
            return output;
        }
    }

    
}
