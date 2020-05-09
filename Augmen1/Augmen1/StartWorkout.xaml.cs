using Augmen1.Models;
using Augmen1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Augmen1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartWorkout : ContentPage
    {
        private Workout workout;
        ObservableCollection<WorkoutViewModel> exerciseInstanceSetList { get; set; }
        public StartWorkout()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            workout = (Workout)BindingContext;

            var exercises = Exercise.getExercises();

            exerciseInstanceSetList = new ObservableCollection<WorkoutViewModel>();

            workout.ListOfExercises.ForEach(exercise => {
                var workoutViewModel = new WorkoutViewModel();
                workoutViewModel.Exercise = exercise;
                exercise.SetsReps.ForEach(set => workoutViewModel.Add(set));
            });

            exerciseSetView.ItemsSource = exerciseInstanceSetList;

            BindingContext = this;
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExerciseEntryPage
                {
                    BindingContext = e.SelectedItem as ExerciseInstance
                });
            }
        }
    }
}