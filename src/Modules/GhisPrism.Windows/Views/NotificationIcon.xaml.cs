using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing;

namespace GhisPrism.Windows.Views
{
  /// <summary>
  /// Interaction logic for NotificationIcon.xaml
  /// </summary>
  public partial class NotificationIcon : UserControl
  {
    public NotificationIcon()
    {
      InitializeComponent();
    }

    private void Click(object sender, RoutedEventArgs e)
    {
      var con = new Icon("NotifyIcon.ico");
      // Configure and show a notification icon in the system tray
      var notifyIcon = new System.Windows.Forms.NotifyIcon
      {
        BalloonTipText = @"Hello, NotifyIcon!",
        Text = @"Hello, NotifyIcon!",
        Icon = new Icon("NotifyIcon.ico"),
        Visible = true
      };
      notifyIcon.ShowBalloonTip(1000);
    }
  }
}