using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManimGUI.MObject
{
    /// <summary>
    /// A timing function for a curve
    /// </summary>
    public class AnimationCurve
    {
        /// <summary>
        /// A dictionary of the keyframe, where the key is the time
        /// </summary>
        public Dictionary<float, float> keyframes = new();
    }
}
