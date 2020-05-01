using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Augmen1.Models
{
    public class Workout
    {
        public string Name { get; set; }
        public int WorkoutID { get; }
        public List<ExerciseInstance> ListOfExercises { get; set; }

        public Workout()
        {
            ListOfExercises = new List<ExerciseInstance>();
        }
        public Workout(string name)
        {
            ListOfExercises = new List<ExerciseInstance>();
            Name = name;
            WorkoutID = new Random().Next();
        }

        public void AddExercise(ExerciseInstance exercise)
        {
            ListOfExercises.Add(exercise);
        }

        public List<ExerciseInstance> GetExercise(string name)
        {
            var x = from exercise in ListOfExercises
                    where exercise.BaseExercise.Name == name
                    select exercise;
            return x.ToList();

            //foreach (var exercise in ListOfExercises)
            //{
            //    if (exercise.BaseExercise.Name == name)
            //    {
            //        return exercise;
            //    }
            //}
            //return null;
        }
    }
}