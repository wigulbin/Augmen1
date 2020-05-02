using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Augmen1.Models;
using Augmen1.Testing;
using Augmen1.ViewModel;
using System.Collections.ObjectModel;

namespace Augmen1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        private ObservableCollection<GroupedExerciseModel> workoutModels { get; set; }

        public WorkoutsPage()
        {

            InitializeComponent();
            updateWorkouts();

            listView.ItemsSource = workoutModels;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            updateWorkouts();

            listView.ItemsSource = workoutModels;

        }

        async protected void OnWorkoutClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutEntryPage()
            {
                BindingContext = new Workout()
            });
        }

        private void updateWorkouts()
        {
            workoutModels = new ObservableCollection<GroupedExerciseModel>();
            var workouts = Generator.getWorkouts();

            workouts.ForEach(workout => {
                var groupedExercise = new GroupedExerciseModel(workout.Name);
                workout.ListOfExercises.ForEach(exercise => groupedExercise.Add(exercise));

                workoutModels.Add(groupedExercise);
            });
        }

        async void OnWorkoutAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutEntryPage()
            {
                BindingContext = new Workout()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem != null)
            //{
            //    await Navigation.PushAsync(new NoteEntryPage
            //    {
            //        BindingContext = e.SelectedItem as Note
            //    });
            //}
        }
    }
}