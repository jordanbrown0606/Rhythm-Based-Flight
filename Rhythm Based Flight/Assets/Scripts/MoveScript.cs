using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class MoveScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;

    private Rigidbody rb;

    public RhythmBar rhythmBar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 targetPosition = rb.position + transform.forward * v * _speed * Time.deltaTime;
        Vector3 lerpedPosition = Vector3.Lerp(rb.position, targetPosition, 0.2f);
        Quaternion targetRotation = rb.rotation * Quaternion.Euler(new Vector3(0, h * _turnSpeed, 0) * Time.deltaTime);
        Quaternion slerpRotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.2f);

        if (Input.GetKey(KeyCode.A))
        {
            rb.MoveRotation(slerpRotation);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.MoveRotation(slerpRotation);
        }

        if(Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(lerpedPosition);
        }

        if(Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(lerpedPosition);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if( rhythmBar.curActionEffectivness == ActionEffectiveness.Perfect)
            {
                Vector3 pump = new Vector3(0, 70, 20);
                rb.AddRelativeForce(pump, ForceMode.Impulse);
            }
            else if (rhythmBar.curActionEffectivness == ActionEffectiveness.Good)
            {
                Vector3 halfPump = new Vector3(0, 35, 10);
                rb.AddRelativeForce(halfPump, ForceMode.Impulse);
            }
            else if (rhythmBar.curActionEffectivness == ActionEffectiveness.Ineffective)
            {
                Vector3 miss = new Vector3(0, -10, 0);
                rb.AddRelativeForce(miss, ForceMode.Impulse);
            }
        }
    }
}
