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
            workoutModels = new ObservableCollection<GroupedExerciseModel>();
            var workouts = Generator.workouts();

            workouts.ForEach(workout => {
                var groupedExercise = new GroupedExerciseModel(workout.Name);
                workout.ListOfExercises.ForEach(exercise => groupedExercise.Add(exercise));

                workoutModels.Add(groupedExercise);
            });

            listView.ItemsSource = workoutModels;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var routine = new Routine();

            
        }


        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NoteEntryPage
            //{
            //    BindingContext = new Note()
            //});
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