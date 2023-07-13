using MVVMProject.Views;
namespace MVVMProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell
		MainPage = new DataViewPage();
	}
}
