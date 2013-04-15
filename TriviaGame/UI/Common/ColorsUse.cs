using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UI.Common
{
    public class ColorsUse
    {
        public static Color ColorToUse(String name)
        {
            Color temp;
            //Comment of the Hexadecimal for the color
            //purpleishColor:	#937dd3
            if (name.CompareTo("purpleishColor") == 0)
            {
                temp.R = Convert.ToByte("147");
                temp.G = Convert.ToByte("125");
                temp.B = Convert.ToByte("211");
                temp.A = Convert.ToByte("255");
            }
            //bluenishColor:	#7cd3be
            else if (name.CompareTo("bluenishColor") == 0)
            {
                temp.R = Convert.ToByte("124");
                temp.G = Convert.ToByte("211");
                temp.B = Convert.ToByte("190");
                temp.A = Convert.ToByte("255");
            }
            //greenishColor:	#bcd37b
            else if (name.CompareTo("greenishColor") == 0)
            {
                temp.R = Convert.ToByte("188");
                temp.G = Convert.ToByte("211");
                temp.B = Convert.ToByte("123");
                temp.A = Convert.ToByte("255");
            }
            //renkishColor:		#d37b91
            else if (name.CompareTo("renkishColor") == 0)
            {
                temp.R = Convert.ToByte("211");
                temp.G = Convert.ToByte("123");
                temp.B = Convert.ToByte("145");
                temp.A = Convert.ToByte("255");
            }
            //ishColor:         #d3be7b
            else if (name.CompareTo("ishColor") == 0)
            {
                temp.R = Convert.ToByte("211");
                temp.G = Convert.ToByte("190");
                temp.B = Convert.ToByte("123");
                temp.A = Convert.ToByte("255");
            }
            //Fail safe if the color is misspelled so that the class doesn't return a NULL type and creates an error
            //This will just be gray
            else
            {
                temp.R = Convert.ToByte("128");
                temp.G = Convert.ToByte("128");
                temp.B = Convert.ToByte("128");
                temp.A = Convert.ToByte("255");
            }
            return temp;
        }
    }
}