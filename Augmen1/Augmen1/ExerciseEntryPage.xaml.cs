using Augmen1.Models;
using Augmen1.Repositories;
using Augmen1.Testing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Augmen1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseEntryPage : ContentPage
    {
        private int workoutID = 0;
        ObservableCollection<Set> exerciseSetList { get; set; }
        public ICommand DeleteSetCommand { get; private set; }
        public ExerciseInstance exerciseInstance { get; set; }

        public string ExerciseName { get; private set; }

        public ExerciseEntryPage()
        {
            InitializeComponent();
            DeleteSetCommand = new Command<int>(DeleteSet);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            exerciseInstance = (ExerciseInstance)BindingContext;
            workoutID = exerciseInstance.WorkoutID;

            var exercises = Exercise.getExercises();

            exerciseSetList = new ObservableCollection<Set>();
            exerciseInstance.SetsReps.ForEach(set => exerciseSetList.Add(set));
            exerciseSets.ItemsSource = exerciseSetList;
            ExerciseName = exerciseInstance.ExerciseName;
            BindingContext = this;
        }

        void OnAddSetClick(object sender, EventArgs e)
        {
            var newSet = new Set(exerciseSetList.Count + 1);
            exerciseSetList.Add(newSet);
        }
        void OnDeleteExercise(object sender, EventArgs e)
        {
            Debug.WriteLine("Here");
        }
        async void OnExerciseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseEntryPage()
            {
                BindingContext = new ExerciseInstance(workoutID)
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ExerciseEntryPage()
            {
                BindingContext = new ExerciseInstance(workoutID)
            });
        }
        async void OnSaveExercise(object sender, EventArgs e)
        {
            var exerciseInstance = (ExerciseEntryPage)BindingContext;

            if (string.IsNullOrWhiteSpace(exerciseInstance.ExerciseName))
            {

            }
            else
            {

            }

            await Navigation.PopAsync();

        }

        void DeleteSet(int index)
        {
            exerciseSetList.RemoveAt(index-1);
            for (var i = 0; i < exerciseSetList.Count; i++)
            {
                var set = exerciseSetList[i];
                set.Index = i + 1;
                exerciseSetList[i] = set;
            }

        }

        private void exerciseSets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}