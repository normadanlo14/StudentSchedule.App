using Firebase.Database;
namespace StudentSchedule;

public partial class App : Application
{
	public static FirebaseClient client = new("https://project-c3d5e-default-rtdb.asia-southeast1.firebasedatabase.app/");
    public static string subjectandtime ,email, key, firstname, lastname, pass;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
