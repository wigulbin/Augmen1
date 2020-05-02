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
    public partial class WorkoutEntryPage : ContentPage
    {
        public WorkoutEntryPage()
        {
            InitializeComponent();
        }


        async void OnSaveWorkout(object sender, EventArgs e)
        {
            var workout = (Workout)BindingContext;

            if (string.IsNullOrWhiteSpace(workout.Name))
            {
                // Save
                Generator.addWorkout(workout);
            }
            else
            {
                // Update 
                Generator.addWorkout(workout);
            }

            await Navigation.PopAsync();

        }
    }
}