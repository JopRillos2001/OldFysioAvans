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
    public class AvailabilityTest
    {
        [Fact]
        public void CanGetAvailability()
        {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IAvailabilityDetailRepo>().Setup(x => x.GetAll()).Returns(GetSampleAvailability());
                var cls = mock.Create<IAvailabilityDetailRepo>();
                var expected = GetSampleAvailability().ToList();

                var actual = cls.GetAll().ToList();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }
        }

        private IEnumerable<AvailabilityDetailsViewModel> GetSampleAvailability()
        {
            IEnumerable<AvailabilityDetailsViewModel> output = new List<AvailabilityDetailsViewModel>
            {
                new AvailabilityDetailsViewModel {
                    StartAvailability = DateTime.Now,
                    EndAvailability = DateTime.Now.AddDays(1),
                    EmployeeId = 1
                },
                new AvailabilityDetailsViewModel {
                    StartAvailability = DateTime.Now.AddDays(5),
                    EndAvailability = DateTime.Now.AddDays(7),
                    EmployeeId = 2
                },
                new AvailabilityDetailsViewModel {
                    StartAvailability = DateTime.Now.AddDays(3),
                    EndAvailability = DateTime.Now.AddDays(4),
                    EmployeeId = 3
                }
            };
            return output;
        }
    }

    
}
