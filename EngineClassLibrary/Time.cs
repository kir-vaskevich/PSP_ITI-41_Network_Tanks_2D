using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineClassLibrary
{
    /// <summary>
    /// Класс времени.
    /// </summary>
    public static class Time
    {
        /// <summary>
        /// Статическое поле для точного измерения затраченного времени.
        /// </summary>
        private static Stopwatch _watch;

        /// <summary>
        /// Предыдущие тики.
        /// </summary>
        private static long _previousTicks;

        /// <summary>
        /// Текущее время с запуска приложения
        /// </summary>
        public static float CurrentTime { get; private set; }

        /// <summary>
        /// Разница во времени между кадрами
        /// </summary>
        public static float DeltaTime { get; private set; }

        /// <summary>
        /// Конструктори статического класса
        /// </summary>
        static Time()
        {
            _watch = new Stopwatch();
            Reset();
        }

        /// <summary>
        /// Обновление подсчитанных значений
        /// </summary>
        public static void UpdateTime()
        {
            long ticks = _watch.Elapsed.Ticks;

            CurrentTime = (float)ticks / TimeSpan.TicksPerSecond;
            DeltaTime = (float)(ticks - _previousTicks) / TimeSpan.TicksPerSecond;

            _previousTicks = ticks;
        }

        /// <summary>
        /// Сброс таймера и счетчика
        /// </summary>
        public static void Reset()
        {
            _watch.Reset();
            _watch.Start();
            _previousTicks = _watch.Elapsed.Ticks;
        }
    }
}
