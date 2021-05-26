using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.Domain
{
    public abstract class ILearningSkill
    {
        public int Level { get; protected set; }
        public abstract void SideEffect(Player player);
        
        public void LevelUp()
        {
            Level++;
        }
    }
}
