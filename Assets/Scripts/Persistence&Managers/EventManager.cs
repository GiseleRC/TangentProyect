using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    LevelStarted,
    LevelEnded,
    TutorialStarted,
    TutorialCompleted,
    TutorialLevelStarted,
    TutorialLevelCompleted,
    GamePaused,
    GameResumend,
    GameSaved,
    GameLoaded
}

public static class EventManager
{
    public delegate void EventReceiver(params object[] parameters);

    private static Dictionary<EventType, EventReceiver> _events;

    static EventManager()
    {
        _events = new Dictionary<EventType, EventReceiver>();
    }

    public static void SubscribeToEvent(EventType eventType, EventReceiver eventReceiver)
    {
        _events.TryAdd(eventType, null);
        _events[eventType] += eventReceiver;
    }

    public static void UnsubscribeToEvent(EventType eventType, EventReceiver eventReceiver)
    {
        if (_events.ContainsKey(eventType))
            _events[eventType] -= eventReceiver;
    }

    public static void TriggerEvent(EventType eventType)
    {
        TriggerEvent(eventType, null);
    }

    public static void TriggerEvent(EventType eventType, params object[] parameters)
    {
        if (_events.ContainsKey(eventType))
            _events[eventType](parameters);
    }
}
