using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterNumberSystem;

namespace ManimGUI
{
    public static class Converter
    {
        public static Godot.Color ColorToGodot(System.Drawing.Color color)
        {
            float red = color.R/255f;
            float green = color.G/255f;
            float blue = color.B/255f;
            float alpha = color.A/255f;
            return new Godot.Color(red, green, blue, alpha);
        }
    }
}
