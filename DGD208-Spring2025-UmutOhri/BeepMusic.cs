using System;

using System;
using System.Threading;

namespace DGD208_Spring2025_UmutOhri
{
    public static class BeepMusic
    {
        private static Thread _musicThread;
        private static bool _isRunning;

        // 8-bit tarzı melodi (Super Mario temasından esinlenme)
        private static readonly (int freq, int duration)[] _mainTheme =
        { (784, 80), (988, 80), (784, 80), (988, 80), // bi-di dip bi-di dip
            (784, 80), (988, 80), (1046, 80), (988, 80), // bi-di bip bi-di dip
            (0, 60),
            (784, 80), (880, 80), (988, 80), (1046, 80), // hızlı tırmanış
            (988, 80), (784, 80), (784, 80), (988, 80), // tekrar bi-di dip
            (0, 100) };
                
        public static void StartBackgroundMusic()
        {
            if (_isRunning) return;

            _isRunning = true;
            _musicThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    try
                    {
                        foreach (var note in _mainTheme)
                        {
                            if (!_isRunning) break;
                            Console.Beep(note.freq, note.duration);
                        }
                        Thread.Sleep(2000); // Melodi arası
                    }
                    catch { /* Hata durumunda sessiz çalış */ }
                }
            })
            {
                IsBackground = true
            };
            _musicThread.Start();
        }

        public static void StopBackgroundMusic()
        {
            _isRunning = false;
            _musicThread?.Join(300); // Thread'in kapanmasını bekle
        }

        // Oyun içi efektler
       
    }
}