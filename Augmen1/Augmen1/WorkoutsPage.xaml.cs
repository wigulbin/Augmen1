﻿using System;
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
        ObservableCollection<GroupedExerciseModel> workoutModels { get; set; }

        public WorkoutsPage()
        {

            InitializeComponent();
            updateWorkouts();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            updateWorkouts();
        }

        private void updateWorkouts()
        {
            workoutModels = new ObservableCollection<GroupedExerciseModel>();
            var workouts = Generator.getWorkouts();

            workouts.ForEach(workout => {
                var groupedExercise = new GroupedExerciseModel(workout.Name, workout.WorkoutID);
                workout.ListOfExercises.ForEach(exercise => groupedExercise.Add(exercise));

                workoutModels.Add(groupedExercise);
            });
            workoutModels = workoutModels;
            listView.ItemsSource = workoutModels;
        }

        async protected void OnWorkoutClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutEntryPage()
            {
                BindingContext = new Workout()
            });
        }
        async protected void OnWorkoutEditClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutEntryPage()
            {
                BindingContext = new Workout()
            });
        }
        protected void OnWorkoutDeleteClick(object sender, EventArgs e)
        {
            var workout = new Workout();
            updateWorkouts();
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
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExerciseEntryPage
                {
                    BindingContext = e.SelectedItem as ExerciseInstance
                });
            }
        }

        async void OnExerciseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateExercisePage
            {
                BindingContext = new Exercise()
            });
        }
        async void OnActionSheetSimpleClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var workoutID = int.Parse(button.ClassId);
            var workout = Generator.getWorkout(workoutID);

            var action = await DisplayActionSheet(workout.Name, "Cancel", null, "Edit", "Delete");
            if("Edit".Equals(action))
            {
                await Navigation.PushAsync(new WorkoutEntryPage
                {
                    BindingContext = Generator.getWorkout(workoutID)
                });
            }
            if("Delete".Equals(action))
            {
                var workoutModel = workoutModels.ToList().FirstOrDefault(x => x.WorkoutID == workoutID);
                int i = workoutModels.IndexOf(workoutModel);
                workoutModels.RemoveAt(i);
                Generator.deleteWorkout(workoutID);
            }
        }
        async void OnActionStartWorkout(object sender, EventArgs e)
        {
            var button = sender as Button;
            var workoutID = int.Parse(button.ClassId);
            var workout = Generator.getWorkout(workoutID);
            await Navigation.PushAsync(new StartWorkout
            {
                BindingContext = Generator.getWorkout(workoutID)
            });
        }
    }
}