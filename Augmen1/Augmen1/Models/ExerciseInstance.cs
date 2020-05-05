using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Augmen1.Models
{
    public class ExerciseInstance
    {
        public Exercise BaseExercise { get; set; }
        public string ExerciseName => BaseExercise.Name;
        public string ExerciseInstanceName => $"{EquipNeeded} {BaseExercise.Name}";
        public List<Tuple<int, int>> SetsReps { get; set; }
        public double Weight { get; set; }
        public TimeSpan RestTime { get; set; }
        public string EquipNeeded { get; set; }



        public int WorkoutID { get; set; }
        public int ExerciseID { get; set; }


        public ExerciseInstance(int workoutID)
        {
            this.ExerciseID = new Random().Next();
            this.WorkoutID = workoutID;
        }

        public ExerciseInstance(int workoutID, Exercise exercise, TimeSpan resttime, string EquipNeeded)
        {
            this.ExerciseID = new Random().Next();
            this.WorkoutID = workoutID;
            this.RestTime = resttime;
            this.EquipNeeded = EquipNeeded;
            this.BaseExercise = exercise;
        }

        public ExerciseInstance(int workoutID, Exercise exercise, string EquipNeeded)
        {
            this.ExerciseID = new Random().Next();
            this.WorkoutID = workoutID;
            this.RestTime = exercise.DefaultRestTime;
            this.EquipNeeded = EquipNeeded;
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