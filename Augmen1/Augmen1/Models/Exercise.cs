using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Augmen1.Models
{
    public class Exercise
    {
        public string Name { get; set; }
        public int ExerciseID { get; }
        public List<string> EquipNeeded { get; set; }
        public string BodyPart { get; set; }
        public string TypeOfLift { get; set; }
        public TimeSpan DefaultRestTime { get; set; }

        public Exercise()
        {

        }

        public static List<String> getExercises()
        {
            return new List<string>()
            {
                "Squat",
                "Bench Press",
                "Push Up"
            };
        }

        public Exercise(Exercise exercise)
        {
            this.Name = exercise.Name;
        }

        public Exercise(string Name, List<string> EquipNeeded, string BodyPart)
        {
            this.Name = Name;
            this.EquipNeeded = EquipNeeded;
            this.BodyPart = BodyPart;
            this.DefaultRestTime = new TimeSpan(0, 2, 0);
        }

        public Exercise(string Name, List<string> EquipNeeded, string BodyPart, TimeSpan resttime)
        {
            this.Name = Name;
            this.EquipNeeded = EquipNeeded;
            this.BodyPart = BodyPart;
            this.DefaultRestTime = resttime;
        }
    }
}