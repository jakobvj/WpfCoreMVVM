using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfCoreMVVM.Model;

namespace WpfCoreMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Ansat> ansatte;
        private Ansat selectedAnsat;

        public MainWindowViewModel()
        {
            LoadAnsatteCommand = new RelayCommand(LoadAnsatteMetode);
            SaveAnsatteCommand = new RelayCommand(SaveAnsatteMetode);
        }

        public ICommand LoadAnsatteCommand { get; private set; }
        public ICommand SaveAnsatteCommand { get; private set; }

        /// <summary>
        /// Get metode til vores obserrvable collection af ansatte
        /// </summary>
        public ObservableCollection<Ansat> AnsatteList
        {
            get
            {
                return ansatte;
            }
        }

        /// <summary>
        /// Get og Set til vores select´ede ansat
        /// </summary>
        public Ansat SelectedAnsat
        {
            get
            {
                return selectedAnsat;
            }
            set
            {
                selectedAnsat = value;
                RaisePropertyChanged("SelectedAnsat");
            }
        }

        /// <summary>
        /// Metode til at sende en notification til vores messenger om ansat er gemt
        /// </summary>
        public void SaveAnsatteMetode()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Ansatte gemt."));
        }

        /// <summary>
        /// Hent ansatte og send en notification til vores messenger om at ansatte er hentet
        /// </summary>
        private void LoadAnsatteMetode()
        {
            ansatte = Ansat.GetEksempelAnsatte();
            this.RaisePropertyChanged(() => this.AnsatteList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Ansatte hentet."));
        }
    }
}

