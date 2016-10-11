﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Models
{
    public class FitnessItem
    {

        public string Name { get; set; }

        public DateTime date { get; set; }

        public double Value { get; set; }

        public double Value1 { get; set; }

        public double Size { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public FitnessItem(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public FitnessItem(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }

        public FitnessItem(double value, double value1, double size)
        {
            Value1 = value;
            Value = value1;
            Size = size;
        }

        public FitnessItem(string name, double high, double low, double open, double close)
        {
            Name = name;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
        public FitnessItem(DateTime Date, double high, double low, double open, double close)
        {
            date = Date;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
        public FitnessItem(double value, double size)
        {
            Value = value;
            Size = size;
        }

        public FitnessItem(DateTime dateTime, double value)
        {
            date = dateTime;
            Value = value;
        }
    }
}
