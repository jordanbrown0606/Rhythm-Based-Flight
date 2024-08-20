using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePOD : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<IDamageable>().TakeDamage(2);
        }
    }
}
