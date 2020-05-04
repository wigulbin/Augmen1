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
        public string Type { get; set; }
        public string BodyPart { get; set; }

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

        public Exercise(string Name, string Type, string BodyPart)
        {
            this.Name = Name;
            this.Type = Type;
            this.BodyPart = BodyPart;
        }
    }
}