using Augmen1.Models;
using Augmen1.Repositories;
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
    public partial class CreateExercisePage : ContentPage
    {
        public CreateExercisePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Exercises.ItemsSource = ExerciseRepository.display();
        }



        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var exercise = (Exercise)BindingContext;
            var ExerciseTypes = getExerciseTypes();
            exercise.Name = ExerciseName.Text.ToString();
            exercise.BodyPart = BodyPartPicker.SelectedItem.ToString();
            exercise.EquipNeeded = ExerciseTypes;
            ExerciseRepository.add(exercise);
            await Navigation.PopAsync();
        }

        private List<string> getExerciseTypes()
        {
            var listE = new List<string>();
            if (barbell.IsChecked)
            {
                listE.Add("Barbell");
            }
            if (dumbell.IsChecked)
            {
                listE.Add("Dumbbell");
            }
            if (bodyweight.IsChecked)
            {
                listE.Add("Bodyweight");
            }
            if (cable.IsChecked)
            {
                listE.Add("Cable");
            }
            return listE;
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}