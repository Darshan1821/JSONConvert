using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;

namespace DataConvert.Droid
{
	[Activity (Label = "DataConvert.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        TextView jsonData, objectData;
        Button deserialize;
        string json = "{'firstName':'Darshan','middleName':'R','lastName':'Bangoria','attributes':[{'value':'9428215644'},{'value':'9909133784'},{'value':'d@gmail.com'},{'value':'a@gmail.com'}]}";
        Person p;

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

        private void Deserialize_Click(object sender, EventArgs e)
        {
            p = JsonConvert.DeserializeObject<Person>(json);

            string objectstring = "FirstName: "+p.firstName+"\nMiddleName: "+p.middleName+"\nLastName: "+p.lastName+"\nAttributes:\n";

            foreach(var d in p.attributes)
            {
                objectstring = objectstring + d.value + "\n";
                Toast.MakeText(this, d.value,ToastLength.Short).Show();
            }
            objectData.Text = objectstring;
        }
    }
}


