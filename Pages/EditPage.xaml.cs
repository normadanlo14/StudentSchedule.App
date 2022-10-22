using StudentSchedule.Model;
using static StudentSchedule.App;
namespace StudentSchedule.Pages;

public partial class EditPage : ContentPage
{
    private Users users = new();
    public EditPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {

        base.OnAppearing();
        entryfname.Text = firstname;
        entrylname.Text = lastname;
        entrySaT.Text = subjectandtime;

    }

    private async void btnmodify_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryfname.Text) || string.IsNullOrEmpty(entrylname.Text) || string.IsNullOrEmpty(entrySaT.Text))
        {
            var a = await users.editdata(entrySaT.Text, entrylname.Text, entryfname.Text);
            if (!a)
                await DisplayAlert("Modify", "Data Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Modify", "Data Not Updated", "OK");
    }
}
