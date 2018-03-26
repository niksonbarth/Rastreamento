using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WebRastreamento.Api.Controllers;
using WebRastreamento.Domain;

namespace WebRastreamento.Api.Tests
{
    [TestClass]
    public class AcessosTest
    {
        [TestMethod]
        public void GetAcessosTest()
        {
            var a = new AcessosController().GetAcessoes();
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void GetAcessosEmailTest()
        {
            var a = new AcessosController().GetAcessoes("nikson@gmail");
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void PostAcessos()
        {
            new AcessosController().PostAcesso( 
                new Acesso { Data = DateTime.Now,
                                    Pagina="HomeTeste",
                                    VisitanteEmail="nikson@gmail.com"});

            var a = new AcessosController().GetAcessoes("nikson@gmail").ToList().Where(x => x.Pagina == "HomeTeste");

            Assert.AreNotEqual(a.Count(), 0);
        }
    }
}
