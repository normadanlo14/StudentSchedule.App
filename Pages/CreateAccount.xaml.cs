using StudentSchedule.Model;
using StudentSchedule.Pages;
namespace StudentSchedule.Pages;

public partial class CreateAccount : ContentPage
{
	Users users = new Users();
	public CreateAccount()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var result = await users.AddUser(subjectTime.Text, fname.Text, lname.Text, emailCA.Text, passwordCA.Text);
		if (result)
		{
			await DisplayAlert("Information", "Account Created", "Ok");
		}
		else
		{
            await DisplayAlert("Information", "Somethings Wrong", "Ok");
        }

    }
}