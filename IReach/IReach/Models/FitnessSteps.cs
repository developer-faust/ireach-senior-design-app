using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Interfaces;

namespace IReach.Models
{
    class FitnessSteps : IFitness 
    {
        public FitnessSteps()
        {
            _stepGoal = 1000;
            _stepCount = 0;
        }

        public double GetTotalSteps()
        {
            return _stepCount;
        }

        public void SetTotalSteps(double steps)
        {
            if (_stepCount != steps)
            {
                _stepCount = steps;
                Recalculate();
            }
        }

        public double GetStepsGoal()
        {
            return _stepGoal;
        }

        public void SetStepsGoal(double goal)
        {
            if (_stepGoal != goal)
            {
                _stepGoal = goal;
                Recalculate();
            }
        }
        public void Recalculate()
        {
            _percentComplete = (_stepCount / _stepGoal) * 100;
        }

        private double _stepCount;
        private double _stepGoal;
        private double _percentComplete;
        public double Complete
        {
            get
            {
                return Math.Round(_percentComplete, 1);
            }
            set
            {
                if (_percentComplete != value)
                {
                    _percentComplete = value;
                }
            }
        }
    }
}
