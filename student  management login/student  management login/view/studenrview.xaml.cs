using student__management_login.viewmodel;

namespace student__management_login.view;

public partial class studenrview : ContentPage
{
	public studenrview()
	{
		InitializeComponent();
		BindingContext = new studentviewmodel();
    }
}