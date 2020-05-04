using Augmen1.Models;
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
            var exerciseInstance = BindingContext as ExerciseInstance;
            if (exerciseInstance != null)
                workoutID = exerciseInstance.WorkoutID;

            exercisePicker.ItemsSource = Exercise.getExercises();
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