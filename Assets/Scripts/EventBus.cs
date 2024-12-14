using System;
using UniRx;

public static class EventBus
{
    private static readonly Subject<object> _eventStream = new Subject<object>();

    public static IObservable<T> OnEvent<T>()
    {
        return _eventStream.OfType<object, T>();
    }

    public static void Publish<T>(T eventData)
    {
        _eventStream.OnNext(eventData);
    }
}