using System.Collections.Generic;
using Enum;
using Trade;
using UnityEngine.Events;

namespace Events
{
    public class EventManager 
    {
        static BuyEnergy buyEnergyEventInvoker;
        static UnityAction<int, TradeName> buyEnergyEventListener;

        static Dictionary<EventName, List<ZeroInvokerEvent>> zeroInvokers =
            new Dictionary<EventName, List<ZeroInvokerEvent>>();
        static Dictionary<EventName, List<UnityAction>> zeroListeners =
            new Dictionary<EventName, List<UnityAction>>();

        static Dictionary<EventName, List<IntInvokerEvent>> intInvokers =
            new Dictionary<EventName, List<IntInvokerEvent>>();
        static Dictionary<EventName, List<UnityAction<int>>> intListeners =
            new Dictionary<EventName, List<UnityAction<int>>>();
    
        public static void AddBuyEnergyInvoker(BuyEnergy invoker)
        {
            buyEnergyEventInvoker = invoker;
            if (buyEnergyEventListener != null)
            {
                buyEnergyEventInvoker.AddBuyEnergyEventListener(buyEnergyEventListener);
            }
        }
        public static void AddBuyEnergyListener(UnityAction<int, TradeName> buyEnergyEventHandler)
        {
            buyEnergyEventListener = buyEnergyEventHandler;
            if (buyEnergyEventInvoker != null)
            {
                buyEnergyEventInvoker.AddBuyEnergyEventListener(buyEnergyEventListener);
            }
        }
    
        public static void Initialize()
        {
            foreach (EventName name in System.Enum.GetValues(typeof(EventName)))
            {	
                if (!intInvokers.ContainsKey(name))
                {
                    intInvokers.Add(name, new List<IntInvokerEvent>());
                    intListeners.Add(name, new List<UnityAction<int>>());
                }
                else
                {
                    intInvokers[name].Clear();
                    intListeners[name].Clear();
                }
            }
        
            foreach (EventName name in System.Enum.GetValues(typeof(EventName)))
            {
                if (!zeroInvokers.ContainsKey(name))
                {
                    zeroInvokers.Add(name, new List<ZeroInvokerEvent>());
                    zeroListeners.Add(name, new List<UnityAction>());
                }
                else
                {
                    zeroInvokers[name].Clear();
                    zeroListeners[name].Clear();
                }
            }
        }
    
        public static void AddZeroInvoker(EventName eventName, ZeroInvokerEvent invoker)
        {
            // add listeners to new invoker and add new invoker to dictionary
            foreach (UnityAction listener in zeroListeners[eventName])
            {
                invoker.AddListener(eventName, listener);
            }
            zeroInvokers[eventName].Add(invoker);
        }
        public static void AddZeroListener(EventName eventName, UnityAction listener)
        {
            // add as listener to all invokers and add new listener to dictionary
            foreach (ZeroInvokerEvent invoker in zeroInvokers[eventName])
            {
                invoker.AddListener(eventName, listener);
            }
            zeroListeners[eventName].Add(listener);
        }
    
        public static void AddIntInvoker(EventName eventName, IntInvokerEvent invoker)
        {
            // add listeners to new invoker and add new invoker to dictionary
            foreach (UnityAction<int> listener in intListeners[eventName])
            {
                invoker.AddListener(eventName, listener);
            }
            intInvokers[eventName].Add(invoker);
        }
        public static void AddIntListener(EventName eventName, UnityAction<int> listener)
        {
            // add as listener to all invokers and add new listener to dictionary
            foreach (IntInvokerEvent invoker in intInvokers[eventName])
            {
                invoker.AddListener(eventName, listener);
            }
            intListeners[eventName].Add(listener);
        }
    }
}
