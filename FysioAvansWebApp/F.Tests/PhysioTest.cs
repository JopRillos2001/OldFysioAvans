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
    public class PhysioTest
    {
        [Fact]
        public void CanGetPhysio()
        {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IPhysiotherapistDetailRepo>().Setup(x => x.GetAll()).Returns(GetSamplePhysiotherapist());
                var cls = mock.Create<IPhysiotherapistDetailRepo>();
                var expected = GetSamplePhysiotherapist().ToList();

                var actual = cls.GetAll().ToList();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }
        }

        private IEnumerable<PhysiotherapistDetailsViewModel> GetSamplePhysiotherapist()
        {
            IEnumerable<PhysiotherapistDetailsViewModel> output = new List<PhysiotherapistDetailsViewModel>
            {
                new PhysiotherapistDetailsViewModel {
                    Firstname = "Jop",
                    Lastname = "Rill",
                    Phonenumber = "7372192853"
                },
                new PhysiotherapistDetailsViewModel {
                    Firstname = "Thijs",
                    Lastname = "Rill",
                    Phonenumber = "8456456546"
                },
                new PhysiotherapistDetailsViewModel {
                    Firstname = "Syb",
                    Lastname = "Rill",
                    Phonenumber = "3546675454"
                }
            };
            return output;
        }
    }

    
}
