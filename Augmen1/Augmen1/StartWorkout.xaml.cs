using Augmen1.Models;
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
        ObservableCollection<ExerciseInstance> exerciseInstanceList { get; set; }
        Dictionary<int, ObservableCollection<Set>> exerciseSetDictionary { get; set; }
        public StartWorkout()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            workout = (Workout)BindingContext;

            var exercises = Exercise.getExercises();

            exerciseInstanceList = new ObservableCollection<ExerciseInstance>();
            workout.ListOfExercises.ForEach(exercise => {
                exerciseInstanceList.Add(exercise);
                exerciseSetDictionary.Add(exercise.ExerciseID, new ObservableCollection<Set>());
                exercise.SetsReps.ForEach(set => exerciseSetDictionary[exercise.ExerciseID].Add(set));
            });

            exerciseSetView.ItemsSource = exerciseSetList;

            BindingContext = this;
        }
    }
}