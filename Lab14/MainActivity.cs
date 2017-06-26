using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab14
{
    [Activity(Label = "Lab14", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var ValidacionButton = FindViewById<Button>(Resource.Id.buttonValidate);

            ValidacionButton.Click += (sender, ev) => {

                ValidacionAsync();

            };

        }

        private async void ValidacionAsync()
        {
            var Client = new SALLab14.ServiceClient();
            var Result = await Client.ValidateAsync(this);

            Android.App.AlertDialog.Builder Builder =
            new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();

            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token}");
            Alert.Show();
        }
    }
}