using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Augmen1.Models
{
    public class Set
    {
        public int Index { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public int RPE { get; set; }

        public Set(int index)
        {
            Index = index;
            Reps = 8;
            Weight = 135;
            RPE = 0;

        }

    }
}
