using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
