using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsMVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ColorsMVVM.Model.UnitTests
{
    [TestClass()]
    public class MColor_UnitTests
    {
        private const int maxIterations = 100000;
        private Random rnd = new Random();
        [TestMethod()]
        public void MColor_UnitTest()
        {
            //Assert.Fail();
            byte[] randomColorComponent = new byte[3 * maxIterations];
            rnd.NextBytes(randomColorComponent);

            for (int i = 0; i < maxIterations; i++)
            {
                // arrange
                byte r = randomColorComponent[3 * i];
                byte g = randomColorComponent[3 * i + 1];
                byte b = randomColorComponent[3 * i + 2];

                // act
                MColor color = new MColor(r, g, b);

                // assert
                Assert.AreEqual(r, color.R, "Niezgodność dotycząca własności R");
                Assert.AreEqual(g, color.G, "Niezgodność dotycząca własności G");
                Assert.AreEqual(b, color.B, "Niezgodność dotycząca własności B");
            }
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            byte r = 0;
            byte g = 128;
            byte b = 255;

            MColor color = new MColor(r, g, b);

            PrivateObject po = new PrivateObject(color);
            byte color_r = (byte) po.GetField("r");
            byte color_g = (byte) po.GetField("g");
            byte color_b = (byte) po.GetField("b");
            Assert.AreEqual(r, color_r, "Niezgodność dotycząca własności R");
            Assert.AreEqual(g, color_g, "Niezgodność dotycząca własności G");
            Assert.AreEqual(b, color_b, "Niezgodność dotycząca własności B");
        }

        [TestMethod()]
        public void PropertiesTest()
        {
            byte r = 0;
            byte g = 128;
            byte b = 255;

            MColor color = new MColor(r, g, b);
            PrivateObject po = new PrivateObject(color);
            po.SetField("r", r);
            po.SetField("g", g);
            po.SetField("b", b);

            Assert.AreEqual(r, color.R, "Niezgodność dotycząca własności R");
            Assert.AreEqual(g, color.G, "Niezgodność dotycząca własności G");
            Assert.AreEqual(b, color.B, "Niezgodność dotycząca własności B");
        }
    }
}