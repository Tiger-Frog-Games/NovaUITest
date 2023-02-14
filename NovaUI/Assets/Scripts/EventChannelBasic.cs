using System;
using UnityEngine;

namespace TigerFrogGames
{
    [CreateAssetMenu(menuName = "EventChannel/Basic")]
    public class EventChannelBasic : ScriptableObject
    {
        public event Action OnEvent;

        public void RaiseEvent()
        {
            OnEvent?.Invoke();
        }
        
    }
}
