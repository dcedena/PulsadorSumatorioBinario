using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PulsadorSumatorioBinario_Classes
{
    public class Pulsador
    {
        private readonly int NUM_LEDS = 3;
        private bool[] leds = null;
        private int numPushed = 0;

        public bool _FALSE_ = false;
        public bool _TRUE_ = true;

        public char _FALSE_VALUE = '0';
        public char _TRUE_VALUE = '1';

        public Pulsador()
        {
            leds = new bool[NUM_LEDS];
        }

        public Pulsador(int numLeds)
        {
            this.NUM_LEDS = numLeds;
            leds = new bool[NUM_LEDS];
        }

        public int GetLEDCount()
        {
            return NUM_LEDS;
        }

        public void Push()
        {
            pushButton(1);
        }

        public void Push(int numPush)
        {
            pushButton(numPush);
        }

        private void pushButton(int numPush)
        {
            this.numPushed += numPush;

            double max = Math.Pow(2, NUM_LEDS);
            max--;

            if(this.numPushed > max)
                Reset();

            int k = this.numPushed;
            for(int i=0;i<NUM_LEDS;i++)
            {
                SetValueInLed(i, (k%2==1 ? _TRUE_ : _FALSE_));
                k = k/2;
            }
        }

        public void SetValueInLed(int indexLed, bool value)
        {
            this.leds[indexLed] = value;
        }

        public bool GetValueInLed(int indexLed)
        {
            return this.leds[indexLed];
        }

        public void Reset()
        {
            this.numPushed = 0;
        }

        public string GetResult()
        {
            string result = "";

            for (int i = 0; i < NUM_LEDS;i++)
                result = ( leds[i] ? _TRUE_VALUE : _FALSE_VALUE ) + result;

            return result;
        }
    }
}