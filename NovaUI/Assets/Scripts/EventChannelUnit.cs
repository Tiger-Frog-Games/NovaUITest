using System;
using UnityEngine;

namespace TigerFrogGames
{
    [CreateAssetMenu(menuName = "EventChannel/Unit")]
    public class EventChannelUnit : ScriptableObject
    {
        public event Action<Unit> OnEvent;

        public void RaiseEvent(Unit u)
        {
            OnEvent?.Invoke(u);
        }
        
    }
}