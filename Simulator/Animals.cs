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
            string description = value.Trim();

            if (description.Length > 15)
            {
                description = description.Remove(15).TrimEnd();
            }

            if (description.Length < 3)
            {
                description = description.PadRight(3, '#');
            }

            if (char.IsLower(description[0]))
            {
                description = char.ToUpper(description[0]) + description.Substring(1);
            }

            _description = description;
        } 
    }
    public uint Size { get; set; } = 3;

    public string Info
    {
        get
        {
            return $"{Description} <{Size}>";
        }

    }
}
