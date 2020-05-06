using Augmen1.Models;
using Augmen1.Repositories;
using Augmen1.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Augmen1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseEntryPage : ContentPage
    {
        private int workoutID = 0;

        public ExerciseEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var exerciseInstance = (ExerciseInstance)BindingContext;
            workoutID = exerciseInstance.WorkoutID;

            var exercises = Exercise.getExercises();
            exercisePicker.ItemsSource = exercises;
            exercisePicker.SelectedItem = exerciseInstance.ExerciseName;
            exercisePicker.SelectedIndexChanged += (sender, args) =>
            {
                if (exercisePicker.SelectedIndex > -1)
                {
                    var exerciseName = exercisePicker.SelectedItem.ToString();
                    equipPicker.ItemsSource = ExerciseRepository.retrieve(exerciseName).EquipNeeded;
                }
            };

            equipPicker.ItemsSource = exerciseInstance.BaseExercise.EquipNeeded;
        }

        async void OnExerciseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseEntryPage()
            {
                BindingContext = new ExerciseInstance(workoutID)
            });
        }
        async void OnSaveExercise(object sender, EventArgs e)
        {
            var exerciseInstance = (ExerciseInstance)BindingContext;

            if (string.IsNullOrWhiteSpace(exerciseInstance.ExerciseName))
            {

            }
            else
            {

            }

            await Navigation.PopAsync();

        }
    }
}