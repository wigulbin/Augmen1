using System;
using System.Collections.Generic;
using System.Text;
using Augmen1.Models;
using Augmen1.Repositories;

namespace Augmen1.Testing
{
    class Generator
    {

        public static List<Workout> workouts()
        {
            var workouts = new List<Workout>();

            if (ExerciseRepository.length() == 0)
            {
                ExerciseRepository.add(new Exercise("Squat", "Barbell", "Legs"));
                ExerciseRepository.add(new Exercise("Bench Press", "Dumbbell", "Chest"));
                ExerciseRepository.add(new Exercise("Push Up", "Bodyweight", "Chest"));
                ExerciseRepository.add(new Exercise("Deadlift", "Barbell", "Legs"));
            }


            var ei1 = new ExerciseInstance(ExerciseRepository.retrieve("Squat"), 1.30, 225, "Primary");
            var ei2 = new ExerciseInstance(ExerciseRepository.retrieve("Bench Press"), 1.45, 135, "Secondary");
            var ei3 = new ExerciseInstance(ExerciseRepository.retrieve("Push Up"), 1.00, 0, "Tertiary");

            var workout = new Workout()
            {
                ei1,
                ei2,
                ei3
            };
            workout.Name = "Workout 1";

            var workout2 = new Workout();
            workout2.AddExercise(ei2);
            workout2.AddExercise(ei1);
            workout2.Name = "Workout2";
            var curWorkout = workout.ListOfExercises;
            var listofworkouts = new Routine();
            listofworkouts.AddWorkout(workout);
            listofworkouts.AddWorkout(workout2);

            workouts.Add(workout);
            workouts.Add(workout2);

            return workouts;
        }

    }
}
