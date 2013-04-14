using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UI.Common
{
    class Colors
    {
        public Color ColorToUse(String name)
        {
            Color temp;
            if (name.CompareTo("purpleishColor") == 0)
            {
                temp.R = Convert.ToByte("147");
                temp.G = Convert.ToByte("125");
                temp.B = Convert.ToByte("211");
                temp.A = Convert.ToByte("255");
            }
            else if (name.CompareTo("bluenishColor") == 0)
            {
                temp.R = Convert.ToByte("124");
                temp.G = Convert.ToByte("211");
                temp.B = Convert.ToByte("190");
                temp.A = Convert.ToByte("255");
            }
            else if (name.CompareTo("greenishColor") == 0)
            {
                temp.R = Convert.ToByte("188");
                temp.G = Convert.ToByte("211");
                temp.B = Convert.ToByte("123");
                temp.A = Convert.ToByte("255");
            }
            else if (name.CompareTo("renkishColor") == 0)
            {
                temp.R = Convert.ToByte("211");
                temp.G = Convert.ToByte("190");
                temp.B = Convert.ToByte("123");
                temp.A = Convert.ToByte("255");
            }
            return temp;
        }
    }
}
