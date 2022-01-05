using Enum;
using UnityEngine.Events;

namespace Events
{
    public class BuyEnergyEvent : UnityEvent<int, TradeName>
    {
    }
}
