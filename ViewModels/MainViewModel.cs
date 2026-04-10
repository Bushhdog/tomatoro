using Tomatoro.Services;

namespace Tomatoro.ViewModels
{
    public class MainViewModel
    {
        private TimerService _TimerService;

        public string TempoFormatado => $"{_TimerService.DuracaoDoTimer / 60:D2}:{_TimerService.DuracaoDoTimer % 60:D2}";

        public MainViewModel() //Construtor
        {   
            _TimerService = new TimerService(25 * 60);
            
        }
    }
}