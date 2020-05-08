using Augmen1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Augmen1.ViewModel
{
    class WorkoutViewModel : ObservableCollection<Set>
    {
        public ExerciseInstance Exercise { get; set; }

    }
}
