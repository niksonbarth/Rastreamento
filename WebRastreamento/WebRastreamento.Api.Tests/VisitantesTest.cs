using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebRastreamento.Api.Controllers;
using WebRastreamento.Domain;

namespace WebRastreamento.Api.Tests
{
    [TestClass]
    public class VisitantesTest
    {
        [TestMethod]
        public void GetVisitantesTest()
        {
            var a = new VisitantesController().GetVisitantes();
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void GetAcessosEmailTest()
        {
            var a = new VisitantesController().GetVisitante("nikson@gmail");
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void PostAcessos()
        {
            new VisitantesController().PostVisitante(
                new Visitante
                {
                    Email = "nikson@teste.com"
                });

            var a = new VisitantesController().GetVisitante("nikson@teste");

            Assert.IsInstanceOfType(a, typeof(OkResult));
        }
    }
}
