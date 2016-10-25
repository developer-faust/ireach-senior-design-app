using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Interfaces
{
    public interface IFitness
    {
        double GetTotalSteps();
        void SetTotalSteps(double steps);
        double GetStepsGoal();
        void SetStepsGoal(double goal);
        void Recalculate();

    }
}
