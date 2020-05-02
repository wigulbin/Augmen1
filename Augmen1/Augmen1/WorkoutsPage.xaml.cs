using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Augmen1.Models;
using Augmen1.Testing;

namespace Augmen1
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        public WorkoutsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var routine = new Routine();

            var workoutsGen = Generator.workouts();

            GroupedView.ItemsSource = workoutsGen;

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