using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsMVVM.Model;

namespace ColorsMVVM.ViewModel.UnitTests
{
    [TestClass()]
    public class ColorEdit_UnitTests
    {
        [TestMethod()]
        public void ConstructorTest()
        {
            ColorEdit ce = new ColorEdit(true);

            Assert.AreEqual(0, ce.R, "Niezgodność dotyczy własności R");
            Assert.AreEqual(128, ce.G, "Niezgodność dotyczy własności G");
            Assert.AreEqual(255, ce.B, "Niezgodność dotyczy własności B");
        }

        private const int maxIterations = 100000;
        private Random rnd = new Random();


        [TestMethod()]
        public void SaveTest()
        {
            for (int i = 0; i < maxIterations; i++)
            {
                byte[] colorComponent = new byte[3];
                rnd.NextBytes(colorComponent);

                ColorEdit ce = new ColorEdit(true);
                ce.R = colorComponent[0];
                ce.G = colorComponent[1];
                ce.B = colorComponent[2];

                Assert.IsTrue(ce.Zapisz.CanExecute(null));
                ce.Zapisz.Execute(null);
                Assert.AreEqual(ce.R, Settings_Mock.r);
                Assert.AreEqual(ce.G, Settings_Mock.g);
                Assert.AreEqual(ce.B, Settings_Mock.b);
            }
        }

        [TestMethod()]
        public void ResetTest()
        {
            ColorEdit ce = new ColorEdit(true);
            Assert.IsTrue(ce.Reset.CanExecute(null), "Niezgodność dotyczy metody CanExecute wywołanej przed zresetowaniem");
            ce.Reset.Execute(null);
            Assert.AreEqual(0, ce.R, "Niezgodność dotyczy własności R");
            Assert.AreEqual(0, ce.G, "Niezgodność dotyczy własności G");
            Assert.AreEqual(0, ce.B, "Niezgodność dotyczy własności B");
            Assert.IsFalse(ce.Reset.CanExecute(null),
                "Niezgodność dotyczy metody CanExecute wywołanej po zresetowaniu");
        }
    }
}