using ZXing.QrCode.Internal;

namespace MauiCRUD;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ScanClicked(object sender, EventArgs e)
    {
        var scanner = new ZXing.Mobile.MobileBarcodeScanner();
        var result = await scanner.Scan();
        await App.Current.MainPage.DisplayAlert("Success", "Scanned code:" + result.Text, "OK");
        if (YellowCheckbox.IsChecked)
        {
            var fId = DepartmentPicker.SelectedItem as Model.Department;
            await Navigation.PushAsync(new NewPage1(2, fId.Id));
        }


        //QRCode = result.Text;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        DataServices.DataConnector ds = new DataServices.DataConnector();
        var depts = ds.GetDepartments();
        DepartmentPicker.ItemsSource = depts;
    }
}

