using System.ComponentModel;
using Tomatoro.Services;
using System.Windows.Input;

namespace Tomatoro.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TimerService _TimerService;
        public event PropertyChangedEventHandler? PropertyChanged;
        public bool EstaRodando => _TimerService.EstaRodando;
        public string TextoBotaoPrincipal => EstaRodando ? "Pausar" : "Iniciar"; //Para fazer a troca do botão na interface

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnTimerAtualizado(object? sender, EventArgs e)
        {
            OnPropertyChanged("TempoFormatado");
        }

        private void AlternarTimer()
        {
            if (EstaRodando)
            {
                _TimerService.PararTimer();
            } 
            else
            {
                _TimerService.IniciarTimer();
            }
        }

        public string TempoFormatado => $"{_TimerService.DuracaoDoTimer / 60:D2}:{_TimerService.DuracaoDoTimer % 60:D2}";


        public ICommand AlternarCommand => new RelayCommand(() => {
            AlternarTimer();
            OnPropertyChanged("TextoBotaoPrincipal");
        });
        
        public ICommand ResetarCommand => new RelayCommand(() => {
            _TimerService.ResetarTimer();
            OnPropertyChanged("TextoBotaoPrincipal");
        });

        public MainViewModel() //Construtor
        {   
            _TimerService = new TimerService(25 * 60);
            _TimerService.TimerAtualizado += OnTimerAtualizado;
            
        }
    }
}