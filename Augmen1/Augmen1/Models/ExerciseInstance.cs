﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Augmen1.Models
{
    public class ExerciseInstance
    {
        public int ExerciseAppID
        {
            get
            {
                return ExerciseAppID;
            }
        }
        public double RestTime { get; set; }
        public double Weight { get; set; }
        public string TypeOfLift { get; set; }
        public Exercise BaseExercise { get; set; }


        public ExerciseInstance(Exercise exercise, double resttime, double weight, string typeoflift)
        {
            this.RestTime = resttime;
            this.Weight = weight;
            this.TypeOfLift = typeoflift;
            this.BaseExercise = exercise;
        }
    }


    public class GroupedExerciseModel : ObservableCollection<ExerciseInstance>
    {
        public string Name { get; set; }

        public GroupedExerciseModel(string name)
        {
            Name = name;
        }
    }
}