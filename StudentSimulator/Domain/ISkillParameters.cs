using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.Domain
{
    public interface ISkillParameters
    {
        int Coefficient { get; set; }
        int Level { get; set; }
    }
}
