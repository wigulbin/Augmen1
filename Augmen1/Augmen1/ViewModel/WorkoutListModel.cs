using System;
using System.Collections.Generic;
using System.Text;
using Augmen1.Testing;
using Augmen1.Models;
using System.Collections.ObjectModel;

namespace Augmen1.ViewModel
{
    public class WorkoutListModel : ObservableCollection<ExerciseInstance>
    {
        public List<ExerciseInstance> WorkoutData { get; set; }
        public string Name { get; set; }

        public WorkoutListModel(Workout workout)
        {
            WorkoutData = workout.ListOfExercises;
            Name = workout.Name;

        }
    }
}
