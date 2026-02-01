using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soEvent", menuName = "soEvent")]
public class soEvent : ScriptableObject
{
    public delegate void Event();
    [System.NonSerialized]public List<Event> events = new List<Event>();
    public void invoke()
    {
        for(int i = 0; i < events.Count; i++)
        {
            if (events[i] == null)
            {
                continue;
            }
            events[i]();
        }
    }
}
