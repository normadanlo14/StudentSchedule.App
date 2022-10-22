using StudentSchedule.Model;

namespace StudentSchedule.Pages;

public partial class Schedules : ContentPage
{
	private Users userlist = new();
	public Schedules()
	{
		InitializeComponent();
        ListUsers.ItemsSource = userlist.GetUserList();

    }

    private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        App.email = (e.CurrentSelection.FirstOrDefault() as Users)?.Email;
        App.key = await userlist.GetUserKey(App.email);
    }

    private async void edititem_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditPage());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
        }
    }

    private async void BTN_delete_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Alert", "Are You Sure to Delete", "YES", "NO");
        if (result)
        {
            await userlist.Deletedata();
            return;

        }
        await DisplayAlert("Alert", "Deletion not Successfully", "YES");
    }
}