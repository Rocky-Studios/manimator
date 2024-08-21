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
        public static Godot.Vector2 Vector2ToGodot(BetterNumberSystem.Vector2 vector)
        {
            switch (vector.X.MeasurementType)
            {
                case MeasurementType.Length:
                    {
                        double X = vector.X.Convert("Metre").NumericValue;
                        double Y = vector.Y.Convert("Metre").NumericValue;
                        return new Godot.Vector2((float)X, (float)Y);
                    }
                case MeasurementType.Angle:
                    {
                        double X = vector.X.Convert("Radian").NumericValue;
                        double Y = vector.Y.Convert("Radian").NumericValue;
                        return new Godot.Vector2((float)X, (float)Y);
                    }
            }
            throw new Exception("Cannot convert vector");
        }
        public static Godot.Vector3 Vector3ToGodot(BetterNumberSystem.Vector3 vector)
        {
            switch (vector.X.MeasurementType)
            {
                case MeasurementType.Length:
                    {
                        double X = vector.X.Convert("Metre").NumericValue;
                        double Y = vector.Y.Convert("Metre").NumericValue;
                        double Z = vector.Z.Convert("Metre").NumericValue;
                        return new Godot.Vector3((float)X, (float)Y, (float)Z);
                    }
                case MeasurementType.Angle:
                    {
                        double X = vector.X.Convert("Radian").NumericValue;
                        double Y = vector.Y.Convert("Radian").NumericValue;
                        double Z = vector.Z.Convert("Radian").NumericValue;
                        return new Godot.Vector3((float)X, (float)Y, (float)Z);
                    }
            }
            throw new Exception("Cannot convert vector");
        }
    }
}
