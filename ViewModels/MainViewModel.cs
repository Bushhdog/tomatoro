using System.ComponentModel;
using Tomatoro.Services;
using System.Windows.Input;

namespace Tomatoro.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TimerService _TimerService;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnTimerAtualizado(object? sender, EventArgs e)
        {
            OnPropertyChanged("TempoFormatado");
        }

        public string TempoFormatado => $"{_TimerService.DuracaoDoTimer / 60:D2}:{_TimerService.DuracaoDoTimer % 60:D2}";

        public ICommand IniciarCommand => new RelayCommand(() => _TimerService.IniciarTimer()); //RelayCommand
        public ICommand PausarCommand => new RelayCommand(() => _TimerService.PararTimer());
        public ICommand ResetarCommand => new RelayCommand(() => _TimerService.ResetarTimer());

        public MainViewModel() //Construtor
        {   
            _TimerService = new TimerService(25 * 60);
            _TimerService.TimerAtualizado += OnTimerAtualizado;
            
        }
    }
}