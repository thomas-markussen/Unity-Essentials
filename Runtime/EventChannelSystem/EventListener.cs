using UnityEngine;
using UnityEngine.Events;

namespace Thimas.Events
{
    public abstract class EventListener<T> : MonoBehaviour
    {
        [SerializeField]
        EventChannel<T> _eventChannel;

        [SerializeField]
        UnityEvent<T> _unityEvent;

        protected void Awake()
        {
            _eventChannel.Register(this);
        }

        protected void OnDestroy()
        {
            _eventChannel.DeRegister(this);
        }

        public void Raise(T value)
        {
            _unityEvent?.Invoke(value);
        }
    }

    public class EventListener : EventListener<Empty> { }
}