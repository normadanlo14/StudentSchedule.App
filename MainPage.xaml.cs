using StudentSchedule.Model;
using StudentSchedule.Pages;

namespace StudentSchedule;

public partial class MainPage : ContentPage
{
	Users users = new Users();
	public MainPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var a = await users.UserLogin(emailLogIn.Text, passwordLogIn.Text);
		if (a)
		{
            await DisplayAlert("Information", "Acces granted", "Ok");
			await Navigation.PushAsync(new Schedules());
        }
		else
		{
            await DisplayAlert("Information", "Acces denied", "Ok");
        }

    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CreateAccount());
	}
}

