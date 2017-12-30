using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DataConvert.Droid
{
    class Person
    {
        //Declarations
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public List<PersonAttributes> attributes { get; set; }
    }
}