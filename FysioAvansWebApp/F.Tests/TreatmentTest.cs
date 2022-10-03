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
    public class TreatmentTest
    {
        [Fact]
        public void CanGetTreatments()
        {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<ITreatmentDetailRepo>().Setup(x => x.GetAll()).Returns(GetSampleTreatments());
                var cls = mock.Create<ITreatmentDetailRepo>();
                var expected = GetSampleTreatments().ToList();

                var actual = cls.GetAll().ToList();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }
        }

        private IEnumerable<TreatmentDetailsViewModel> GetSampleTreatments()
        {
            IEnumerable<TreatmentDetailsViewModel> output = new List<TreatmentDetailsViewModel>
            {
                new TreatmentDetailsViewModel {
                    PatientFirstname = "Jop",
                    PatientLastname = "Rill",
                    Room = "1"
                },
                new TreatmentDetailsViewModel {
                    PatientFirstname = "Thijs",
                    PatientLastname = "Rill",
                    Room = "2"
                },
                new TreatmentDetailsViewModel {
                    PatientFirstname = "Syb",
                    PatientLastname = "Rill",
                    Room = "3"
                }
            };
            return output;
        }
    }

    
}
