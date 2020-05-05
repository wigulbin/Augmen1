using System;
using System.Collections.Generic;
using System.Text;
using Augmen1.Testing;
using Augmen1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Augmen1.ViewModel
{

    public class WorkoutListModel : ObservableCollection<ExerciseInstance>
    {
        public List<ExerciseInstance> WorkoutData { get; set; }
        public string Name { get; set; }
        public int WorkoutID { get; set; }

        public WorkoutListModel(Workout workout)
        {
            WorkoutData = workout.ListOfExercises;
            Name = workout.Name;
        }


        public ICommand RemoveWorkoutCommand => new Command<int>(RemoveWorkout);
        private void RemoveWorkout(int workoutid)
        {
            Generator.deleteWorkout(workoutid);
        }
    }
}
