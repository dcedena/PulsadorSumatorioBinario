using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;
using PulsadorSumatorioBinario_Classes;

namespace PulsadorSumatorioBinario_Tests
{
    [TestFixture]
    public class TestFixture1
    {
        [Test]
        public void Test_CrearPulsadorDefecto()
        {
            Pulsador p = new Pulsador();

            Assert.AreEqual(3, p.GetLEDCount());
        }

        [Test]
        public void Test_ComprobarValoresPorDefectoDeTodosLEDs()
        {
            Pulsador p = new Pulsador();

            Assert.IsFalse(p.GetValueInLed(0));
            Assert.IsFalse(p.GetValueInLed(1));
            Assert.IsFalse(p.GetValueInLed(2));
        }

        [Test]
        public void Test_AsignarValoresATodosLEDs()
        {
            Pulsador p = new Pulsador();

            p.SetValueInLed(0, true);
            p.SetValueInLed(1, true);
            p.SetValueInLed(2, true);

            Assert.IsTrue(p.GetValueInLed(0));
            Assert.IsTrue(p.GetValueInLed(1));
            Assert.IsTrue(p.GetValueInLed(2));
        }

        [Test]
        public void Test_PulsarBoton_NumeroVeces_1()
        {
            Pulsador p = new Pulsador();
            p.Push();

            Debug.WriteLine(p.GetResult());
            Assert.AreEqual("001", p.GetResult());
        }

        [Test]
        public void Test_PulsarBoton_NumeroVeces_2()
        {
            Pulsador p = new Pulsador();
            p.Push(2);

            Debug.WriteLine(p.GetResult());
            Assert.AreEqual("010", p.GetResult());
        }

        [Test]
        public void Test_PulsarBoton_NumeroVeces_3()
        {
            Pulsador p = new Pulsador();
            p.Push(3);

            Debug.WriteLine(p.GetResult());
            Assert.AreEqual("011", p.GetResult());
        }

        [Test]
        public void Test_PulsarBoton_NumeroVeces_4()
        {
            Pulsador p = new Pulsador();
            p.Push(4);

            Debug.WriteLine(p.GetResult());
            Assert.AreEqual("100", p.GetResult());
        }

        [Test]
        public void Test_PulsarBoton_NumeroVeces_7List()
        {
            Pulsador p = new Pulsador();
            Debug.WriteLine(p.GetResult());

            int NUM = 7;
            for (int i = 0; i < NUM; i++)
            {
                p.Push();
                Debug.WriteLine(p.GetResult());
            }
        }
    }
}