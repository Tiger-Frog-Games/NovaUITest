using System;
using UnityEngine;

namespace TigerFrogGames
{
    [CreateAssetMenu(menuName = "EventChannel/Base")]
    public class EventChannel : ScriptableObject
    {
        public event Action<GameObject> OnEvent;

        public void RaiseEvent(GameObject g)
        {
            OnEvent?.Invoke(g);
        }
        
    }
}