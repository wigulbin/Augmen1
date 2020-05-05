using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Augmen1.Models;
using System.Text;

namespace Augmen1.Repositories
{
    public static class ExerciseRepository
    {
        private static Dictionary<string, Exercise> _list;

        static void ExerciseList()
        {
            _list = new Dictionary<string, Exercise>();
        }

        public static void add(Exercise exercise)
        {
            if (_list is null)
            {
                _list = new Dictionary<string, Exercise>();
            }
            _list.Add(exercise.Name, exercise);
        }

        public static Exercise retrieve(string key)
        {
            return _list[key];
        }

        public static int length()
        {
            if (_list is null)
            {
                return 0;
            }
            return _list.Count;
        }

        public static List<string> display()
        {
            var listOfKeys = new List<string>();
            foreach (var key in _list.Keys)
            {
                listOfKeys.Add(key);
            }
            return listOfKeys;
        }
    }
}
