using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Augmen1.Models
{
    public class Workout : List<ExerciseInstance>
    {
        public string Name { get; set; }
        public int WorkoutID { get; }
        public List<ExerciseInstance> ListOfExercises => this;

        public void AddExercise(ExerciseInstance exercise)
        {
            ListOfExercises.Add(exercise);
        }

        public List<string> GetAllExerciseNames()
        {
            var x = from exercise in ListOfExercises
                    select exercise.BaseExercise.Name;
            return x.ToList();
        }


    }
}