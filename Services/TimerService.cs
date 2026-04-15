using System;
using System.Windows;
using System.Windows.Threading;

namespace Tomatoro.Services
{

    public class TimerService
    {
        public int NumPomodoros { get; set; }
        public bool TimerEmFoco { get; set; } 
        public int DuracaoDoTimer { get; set; } //em segundos
        
        private DispatcherTimer _timer;
        private int _TempoInicial { get; set; }

        private void EmCadaTique(object? sender, EventArgs e)
        {
            DuracaoDoTimer--;

            TimerAtualizado?.Invoke(this, EventArgs.Empty);

            if (DuracaoDoTimer == 0)
            {
                _timer.Stop();
                TimerFinalizado?.Invoke(this, EventArgs.Empty);
            }
        }

        public void IniciarTimer()
        {
            _timer.Start(); //Inicia o timer
        }
        public void PararTimer()
        {
            _timer.Stop(); //Para o timer
        }
        public void ResetarTimer()
        {
            _timer.Stop(); //Para o timer
            DuracaoDoTimer = _TempoInicial; //Reiniciar a contagem
        }

        public event EventHandler TimerFinalizado;
        public event EventHandler TimerAtualizado;

        public TimerService(int DuracaoInicial) //Construtor
        {
            _TempoInicial = DuracaoInicial;
            DuracaoDoTimer = _TempoInicial;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += EmCadaTique;

        }   

   }
}