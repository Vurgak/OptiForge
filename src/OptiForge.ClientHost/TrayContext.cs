namespace OptiForge.ClientHost;

public class TrayContext : ApplicationContext
{
    private NotifyIcon _notifyIcon = new();

    public TrayContext()
    {
        var menuStrip = new ContextMenuStrip();
        menuStrip.Items.Add("Exit", null, (sender, e) => Application.Exit());

        _notifyIcon.Text = "OptiForge";
        _notifyIcon.Icon = new Icon(Path.Combine(AppContext.BaseDirectory, "favicon.ico"));
        _notifyIcon.ContextMenuStrip = menuStrip;
        _notifyIcon.Visible = true;
    }
}
