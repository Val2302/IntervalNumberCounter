using System;

namespace IntervalNumberCounter.Src.Models.Entities
{
    [Serializable]
    public class NumberCounter
    {
        public const int ONE_SECOND = 1000;

        public long BeginValue { get; private set; }
        public long CurrentValue { get; set; }
        public int Step { get; private set; }
        public int Timeout { get; private set; } /// миллисекунды

        /// <summary>
        /// Счётчк чисел
        /// </summary>
        /// <param name="beginValue">начальное значение</param>
        /// <param name="step">шаг</param>
        /// <param name="timeout">таймаут (миллисекунды)</param>
        public NumberCounter ( long beginValue = 0, int step = 1, int timeout = ONE_SECOND )
        {
            CurrentValue = BeginValue = beginValue;
            Step = step;
            Timeout = timeout;
        }

        public void Increment ( ) => CurrentValue += Step;

        public void Reset ( ) => CurrentValue = BeginValue;
    }
}
