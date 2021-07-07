using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Livet;

namespace DatabaseExtension.SampleApp {
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            DispatcherHelper.UIDispatcher = Dispatcher;
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            var mainWindow = new Views.MainWindow();
            mainWindow.DataContext = new ViewModels.MainWindowViewModel();
            this.MainWindow = mainWindow;
            mainWindow.Show();

            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            using (var vm = new ViewModels.ExceptionWindowViewModel()) {
                vm.EnableContinue = true;
                vm.Exception = e.Exception;
                var window = new Views.ExceptionWindow();
                window.DataContext = vm;
                if (window.ShowDialog() == true) {
                    e.Handled = true;
                    return;
                } else {
                    Current.Shutdown(-1);
                    System.Environment.Exit(1);
                }
            }
        }

        //集約エラーハンドラ
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            using (var vm = new ViewModels.ExceptionWindowViewModel()) {
                vm.EnableContinue = false;
                vm.Exception = e.ExceptionObject as Exception;
                var window = new Views.ExceptionWindow();
                window.DataContext = vm;
                window.ShowDialog();
                Current.Shutdown(-1);
                System.Environment.Exit(1);
            }
        }
    }
}
