using Augmen1.Models;
using Augmen1.Testing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Augmen1.ViewModel
{
    class GroupedExerciseModel : ObservableCollection<ExerciseInstance>
    {
        public static ObservableCollection<GroupedExerciseModel> workoutModels { get; set; }

        public string Name { get; set; }
        public int WorkoutID { get; set; }

        public INavigation Navigation { get; set; }

        public GroupedExerciseModel(string name, int workoutID)
        {
            Name = name;
            WorkoutID = workoutID;
        }


        public ICommand EditWorkoutCommand => new Command<int>(EditWorkout);
        private async static void EditWorkout(int workoutid)
        {
            var workoutModel = workoutModels.ToList().FirstOrDefault(x => x.WorkoutID == workoutid);
            await Application.Current.MainPage.Navigation.PushAsync(new WorkoutEntryPage()
            {
                BindingContext = Generator.getWorkout(workoutModel.WorkoutID)
            });
        }

        public ICommand RemoveWorkoutCommand => new Command<int>(RemoveWorkout);
        private static void RemoveWorkout(int workoutid)
        {
            var workoutModel = workoutModels.ToList().FirstOrDefault(x => x.WorkoutID == workoutid);
            int i = workoutModels.IndexOf(workoutModel);
            workoutModels.RemoveAt(i);
            Generator.deleteWorkout(workoutid);
        }
    }
}
