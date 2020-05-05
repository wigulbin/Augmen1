using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Augmen1.Models;
using Augmen1.Repositories;
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
            var defaultEquip = new List<string>
            {
                "Barbell",
                "Dumbbell",
                "Bodyweight",
                "Cable"
            };

            if (ExerciseRepository.length() == 0)
            {
                ExerciseRepository.add(new Exercise("Squat", defaultEquip, "Legs"));
                ExerciseRepository.add(new Exercise("Bench Press", defaultEquip, "Chest"));
                ExerciseRepository.add(new Exercise("Push Up", defaultEquip, "Chest"));
                ExerciseRepository.add(new Exercise("Deadlift", defaultEquip, "Legs"));
            }

            var workout = new Workout();
            workout.Name = "Workout 1";

            var workout2 = new Workout();
            workout.ListOfExercises = new List<ExerciseInstance>
            {
                new ExerciseInstance(workout.WorkoutID, ExerciseRepository.retrieve("Squat"), ExerciseRepository.retrieve("Squat").EquipNeeded[0]),
                new ExerciseInstance(workout.WorkoutID, ExerciseRepository.retrieve("Bench Press"), new TimeSpan(0, 3, 0), ExerciseRepository.retrieve("Bench Press").EquipNeeded[1]),
                new ExerciseInstance(workout.WorkoutID, ExerciseRepository.retrieve("Push Up"), ExerciseRepository.retrieve("Push Up").EquipNeeded[2])
            };

            workout2.ListOfExercises = new List<ExerciseInstance>
            {
                new ExerciseInstance(workout2.WorkoutID, ExerciseRepository.retrieve("Deadlift"), ExerciseRepository.retrieve("Deadlift").EquipNeeded[0]),
                new ExerciseInstance(workout2.WorkoutID, ExerciseRepository.retrieve("Bench Press"), new TimeSpan(0, 3, 0), ExerciseRepository.retrieve("Bench Press").EquipNeeded[0]),
                new ExerciseInstance(workout2.WorkoutID, ExerciseRepository.retrieve("Squat"), ExerciseRepository.retrieve("Squat").EquipNeeded[1])
            };



            workout2.Name = "Workout2";

            workouts.Add(workout);
            workouts.Add(workout2);

            return workouts;
        }
    }
}
