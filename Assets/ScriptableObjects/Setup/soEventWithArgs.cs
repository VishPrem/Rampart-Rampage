using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soEventWithArgs<T> : ScriptableObject
{
    public delegate void Event(T arg);
    [System.NonSerialized] public List<Event> events = new List<Event>();

    public void invoke(T args)
    {
        for (int i = 0; i < events.Count; i++)
        {
            events[i](args);
        }
    }
}

[CreateAssetMenu(fileName = "soEventWithVec3Args", menuName = "soEventWithVec3Args")]
public class soEventWithVec3Args : soEventWithArgs<Vector3>
{

}

[CreateAssetMenu(fileName = "soEventWithStatsArgs", menuName = "soEventWithStatsArgs")]
public class soEventWithStatsArgs : soEventWithArgs<stats>
{

}
