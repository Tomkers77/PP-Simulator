using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly {  get; set; } = true;

    public override string Info
    {
        get
        {
            string skill = "";
            if (CanFly == true)
            {
                skill = "(fly+)";
            }
            else
            {
                skill = "(fly-)";
            }
            return $"{Description} {skill} <{Size}>";
        }
    }
}
