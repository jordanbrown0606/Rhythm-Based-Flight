using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class TimerEvent : UnityEvent { }

public class VictoryZone : MonoBehaviour
{
    public CountdownTimer timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            timer.keepTime = false;
            _timerEvent.Invoke();
        }
    }

    public TimerEvent _timerEvent;
}
