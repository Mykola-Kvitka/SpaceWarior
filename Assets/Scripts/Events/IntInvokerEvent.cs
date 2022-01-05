using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class IntInvokerEvent : MonoBehaviour
    {
        protected Dictionary<EventName, UnityEvent<int>> unityEvents =
            new Dictionary<EventName, UnityEvent<int>>();

        /// <summary>
        /// Adds the given listener for the given event name
        /// </summary>
        /// <param name="eventName">event name</param>
        /// <param name="listener">listener</param>
        public void AddListener(EventName eventName, UnityAction<int> listener)
        {
            // only add listeners for supported events
            if (unityEvents.ContainsKey(eventName))
            {
                unityEvents[eventName].AddListener(listener);
            }
        }
    }
}
