using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataConvert.Droid
{
	[Activity (Label = "DataConvert.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        //Declarations
        TextView jsonData, objectData;
        Button deserialize;
        string json = "[{'firstName':'Darshan','middleName':'R','lastName':'Bangoria','attributes':[{'value':'9428215644'},{'value':'9909133784'},{'value':'d@gmail.com'},{'value':'a@gmail.com'}]},{'firstName':'Kandarp','middleName':'M','lastName':'Joshi','attributes':[{'value':'9898989898'},{'value':'9988776655'},{'value':'k@gmail.com'},{'value':'m@gmail.com'}]}]";
        List<Person> person;
        string objectstring="";

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

            jsonData = FindViewById<TextView>(Resource.Id.jsonstring);
            deserialize = FindViewById<Button>(Resource.Id.convert);
            objectData = FindViewById<TextView>(Resource.Id.objectstring);

            jsonData.Text = json;

            deserialize.Click += Deserialize_Click;
        }

        //set Onclick Listner
        private void Deserialize_Click(object sender, EventArgs e)
        {
            //deserialize the JSON sting to person objects
            person = JsonConvert.DeserializeObject<List<Person>>(json);

            foreach (var p in person)
            {
                objectstring += "FirstName: " + p.firstName + "\nMiddleName: " + p.middleName + "\nLastName: " + p.lastName + "\nAttributes:\n";

                foreach (var d in p.attributes)
                {
                    objectstring = objectstring + d.value + "\n";
                }
                objectstring += "\n\n";
                Toast.MakeText(this, p.firstName,ToastLength.Short).Show();
            }
            objectData.Text = objectstring;
        }
    }
}


