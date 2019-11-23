using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfCoreMVVM.ViewModels;

namespace WpfCoreMVVM.Utillity
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            // Registerer vores instans af MainWindowsViewModel i vores ioc container
            SimpleIoc.Default.Register<MainWindowViewModel>();

            // 
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }
        /// <summary>
        /// Getter til vores instans af MainWindowViewModel fra vores ioc container
        /// </summary>
        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainWindowViewModel>();
            }
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }
    }
}
