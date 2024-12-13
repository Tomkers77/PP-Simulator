using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string _description = "No Data";
    public required string Description 
    { 
        get { return _description; }
        init
        {
            _description = Validator.Shortener(value, 3, 15, '#');
        } 
    }
    public uint Size { get; set; } = 3;

    public virtual string Info
    {
        get
        {
            return $"{Description} <{Size}>";
        }

    }

    //----------------------------------------------------------------------------------

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }
}
