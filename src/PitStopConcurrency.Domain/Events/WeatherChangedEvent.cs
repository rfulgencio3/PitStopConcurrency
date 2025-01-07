using PitStopConcurrency.Domain.ValueObjects;

namespace PitStopConcurrency.Domain.Events
{
    public class WeatherChangedEvent
    {
        public WeatherCondition NewCondition { get; }

        public WeatherChangedEvent(WeatherCondition newCondition)
        {
            NewCondition = newCondition;
        }
    }
}
