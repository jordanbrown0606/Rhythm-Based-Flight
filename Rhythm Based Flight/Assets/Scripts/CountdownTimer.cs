using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

[Serializable]
public class ControlsEvent : UnityEvent { }
public class CountdownTimer : MonoBehaviour
{

    [SerializeField] private float _timeLeft = 60f;
    [SerializeField] private float _endTime;
    [SerializeField] private TMP_Text _timer;

    public bool keepTime = true;

    public ControlsEvent disableControls;

    // Update is called once per frame
    void Update()
    {
        _timer.text = _timeLeft.ToString("F2");

        if (keepTime)
        {
            _timeLeft -= Time.deltaTime;
            _timer.text = _timeLeft.ToString("F2");
        }

        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            disableControls.Invoke();
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
