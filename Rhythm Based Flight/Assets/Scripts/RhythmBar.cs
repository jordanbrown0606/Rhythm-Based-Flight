using UnityEngine;
using UnityEngine.UI;

public class RhythmBar : MonoBehaviour
{
    [SerializeField] private GameObject _hitBar;
    [SerializeField] private float _speed;
    private Vector3 _startPosition;
    private float _screenWidth = Screen.width;
    private float _lowGoodHitZone, _highGoodHitZone;
    private float _lowPerfectHitZone, _highPerfectHitZone;

    public ActionEffectiveness curActionEffectivness;

    float _t = 0;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _hitBar.transform.position;
        _lowGoodHitZone = 0.4f;
        _highGoodHitZone = 0.6f;
        _lowPerfectHitZone = 0.48f;
        _highPerfectHitZone = 0.52f;
    }

    // Update is called once per frame
    void Update()
    {
     
        _t += Time.deltaTime;

        if((_t > _lowGoodHitZone && _t < _lowPerfectHitZone) || (_t > _highPerfectHitZone && _t < _highGoodHitZone))
        {
            curActionEffectivness = ActionEffectiveness.Good;
            _hitBar.GetComponent<Image>().color = Color.yellow;
        }
        else if(_t >= _lowPerfectHitZone && _t <= _highPerfectHitZone)
        {
            curActionEffectivness = ActionEffectiveness.Perfect;
            _hitBar.GetComponent<Image>().color = Color.green;
        }
        else
        {
            curActionEffectivness = ActionEffectiveness.Ineffective;
            _hitBar.GetComponent<Image>().color = Color.white;
        }

        _hitBar.transform.position = Vector3.Lerp(_startPosition, _startPosition + new Vector3(_screenWidth, 0, 0), _t / 1);

        _t = _t > 1 ? 0 : _t;
    }
}


public enum ActionEffectiveness
{
    Ineffective,
    Good,
    Perfect
}

