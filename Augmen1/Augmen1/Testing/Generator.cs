using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Augmen1.Models;
using Xamarin.Forms.Internals;

namespace Augmen1.Testing
{
    class Generator
    {
        private static Dictionary<int, Workout> generatedWorkouts;

        public static List<Workout> getWorkouts()
        {
            if (generatedWorkouts == null)
            {
                var workoutList = workouts();
                generatedWorkouts = new Dictionary<int, Workout>();
                workoutList.ForEach(workout => generatedWorkouts.Add(workout.WorkoutID, workout));
                
            }
            var allWorkouts = new List<Workout>();
            generatedWorkouts.Values.ForEach(workout => allWorkouts.Add(workout));
            return allWorkouts.OrderBy(w => w.WorkoutID).ToList();
        }

        public static List<Workout> addWorkout(Workout workout)
        {
            generatedWorkouts.Add(workout.WorkoutID, workout);

          
            return getWorkouts();
        }

        public static Workout getWorkout(int workoutID)
        {
            return generatedWorkouts[workoutID];
        }
        private static List<Workout> workouts()
        {
            var workouts = new List<Workout>();

            var squat = new Exercise("Squat", "Barbell", "Legs");
            var bench = new Exercise("Bench Press", "Dumbbell", "Chest");
            var pushup = new Exercise("Push Up", "Bodyweight", "Chest");
            var deadlift = new Exercise("Deadlift", "Barbell", "Legs");

            var workout = new Workout("Workout1");

            var ei1 = new ExerciseInstance(workout.WorkoutID, squat, new TimeSpan(0, 1, 30), 225, "Primary");
            var ei2 = new ExerciseInstance(workout.WorkoutID, bench, new TimeSpan(0, 1, 45), 135, "Secondary");
            var ei3 = new ExerciseInstance(workout.WorkoutID, pushup, new TimeSpan(0, 1, 0), 0, "Tertiary");

            workout.AddExercise(ei1);
            workout.AddExercise(ei2);
            workout.AddExercise(ei3);

            var workout2 = new Workout("Workout2");
            workout2.AddExercise(ei2);
            workout2.AddExercise(ei1);
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
