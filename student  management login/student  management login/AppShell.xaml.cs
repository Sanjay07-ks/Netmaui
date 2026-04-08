using student__management_login.view;

namespace student__management_login
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(studentmarkview), typeof(studentmarkview));
        }
    }
}
