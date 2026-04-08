using student__management_login.viewmodel;

namespace student__management_login.view;

public partial class studentmarkview : ContentPage
{
	public studentmarkview()
	{
		InitializeComponent();
		BindingContext = new studentmarkviewmodel();
    }
}