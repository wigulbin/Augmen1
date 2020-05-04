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
        public int sequence { get; set; }

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

        public void UpdateExercise(ExerciseInstance instance)
        {
            var index = ListOfExercises.FindIndex(e => e.ExerciseID == instance.ExerciseID);

            if (index > -1)
            {
                var oldInstance = ListOfExercises[index];
                instance.ExerciseID = oldInstance.ExerciseID;
                ListOfExercises[index] = instance;
            }
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