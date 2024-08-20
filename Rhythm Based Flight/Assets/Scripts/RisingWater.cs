using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _movement = new Vector3(0, _speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _movement * Time.deltaTime;
    }
}
