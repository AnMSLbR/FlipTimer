using FlipTimer.Commands;
using FlipTimer.Stores;
using FlipTimer.ViewModels;
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
using System.Windows.Shell;


namespace FlipTimer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount == 2)
            //    MaximizeMainWindow();
            //else
                this.DragMove();
        }

        private void MaximizeMainWindow()
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }
        private void CommandBinding_Executed_CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void CommandBinding_Executed_MaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                SystemCommands.MaximizeWindow(this);
            else
                SystemCommands.RestoreWindow(this);
        }

        private void CommandBinding_Executed_MinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void winMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mainViewModel = (MainViewModel)DataContext;
            if(mainViewModel.SaveCommand.CanExecute(null))
                mainViewModel.SaveCommand.Execute(null);
        }
    }
}
