using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ImageEditor.Helpers
{
    internal static class SliderColorsList
    {
        internal static List<SliderColors> SliderColors = new List<SliderColors>()
        {
            new SliderColors
            {
                ID=0,
                ColorOnHEX = "#FFFFFF"
            },
            new SliderColors
            {
                ID=1,
                ColorOnHEX = "#F80000"
            },
            new SliderColors
            {
                ID=2,
                ColorOnHEX = "#4F0000"
            },
            new SliderColors
            {
                ID=3,
                ColorOnHEX = "#4200FF"
            },
            new SliderColors
            {
                ID=4,
                ColorOnHEX = "#28009A"
            },
            new SliderColors
            {
                ID=5,
                ColorOnHEX = "#17EF00"
            },
            new SliderColors
            {
                ID=6,
                ColorOnHEX = "#0B7100"
            },
            new SliderColors
            {
                ID=7,
                ColorOnHEX = "#FFF000"
            },
            new SliderColors
            {
                ID=8,
                ColorOnHEX = "#686100"
            },
            new SliderColors
            {
                ID=9,
                ColorOnHEX = "#000000"
            }
        };
    }
    internal class SliderColors
    {
        public int ID { get; set; }
        public string ColorOnHEX { get; set; }
    }
}
