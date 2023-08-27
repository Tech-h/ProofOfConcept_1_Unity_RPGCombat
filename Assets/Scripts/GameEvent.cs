using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("GameEvent"))]
public class GameEvent : ScriptableObject
    
{
    public List<GameEventListner> listners = new List<GameEventListner>();

    // Raise event through different method signatures

    public void Raise(Component sender, object data)
    {
        for (int i = 0; i < listners.Count; i++)
            listners[i].OnEventRaised(sender, data);
    }

    // Manage Listeners

    public void RegisterListners(GameEventListner listener)
    {
        if (!listners.Contains(listener))
            listners.Add(listener);
    }

    public void UnregisterListner(GameEventListner Listener)
    {
        if (listners.Contains(Listener));
            listners.Remove(Listener);
    }
}
