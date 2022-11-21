namespace MauiCRUD;

public partial class NewPage1 : ContentPage
{
    public int Partid { get; set; }
    public int FoundDepartmentId { get; set; }
    public NewPage1(int pId,int fID)
	{
		InitializeComponent();
        Partid = pId;
        FoundDepartmentId = fID;
	}
    DataServices.DataConnector ds = new DataServices.DataConnector();
    private async void ScanClicked(object sender, EventArgs e)
    {
        var scanner = new ZXing.Mobile.MobileBarcodeScanner();

        var result = await scanner.Scan();
        await App.Current.MainPage.DisplayAlert("Success", "Scanned code:" + result.Text, "OK");
        //QRCode = result.Text;
        var dId = DefectCategory.SelectedItem as Model.DefectCategory;
        var rId = ReasonText.SelectedItem as Model.Reason;
        var qId = QuantityText.SelectedItem as Model.DefectQuantity;
        var aId = CorrctiveText.SelectedItem as Model.CorrctiveAction;
        var fId = FoundDepartmentPicker.SelectedItem as Model.Department;
        var sId = SourceDepartmentPicker.SelectedItem as Model.Department;
        ds.InsertPartRecord(new Model.Part() { PartID=Partid,DefectID=dId.DefectID,DefectQTY=qId.Id,Comments=string.IsNullOrEmpty(CommentsText.Text)?" ": CommentsText.Text,
            CorrectActID=aId.Id,FoundDeptID=fId.Id,SourceDeptID=sId.Id,Reason=rId.ReasonId});
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        var depts = ds.GetDepartments();
        var reasons = ds.GetReasons();
        var quas = ds.GetDefectQuantities();
        var cates = ds.GetDefectCateogires();
        var actions = ds.GetCorrctiveAction();
        FoundDepartmentPicker.ItemsSource = depts;
        SourceDepartmentPicker.ItemsSource = depts;
        var foundDept = depts.Where(x => x.Id == this.FoundDepartmentId).FirstOrDefault();
        FoundDepartmentPicker.SelectedItem = foundDept;
        QuantityText.ItemsSource = quas;
        DefectCategory.ItemsSource = cates;
        ReasonText.ItemsSource = reasons;
        CorrctiveText.ItemsSource = actions;
    }
}