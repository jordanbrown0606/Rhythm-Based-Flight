using System.Collections;
using UnityEngine;

public class SpawnTester : MonoBehaviour
{
    public float timeToDespawn;
    public GameObject prefab;
    public Transform[] spawns;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.001f, 0.3f);   
    }

    private void Spawn()
    {
        GameObject go = ObjectPooling.Spawn(prefab, spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity);
        StartCoroutine(Despawn(go));
    }

    IEnumerator Despawn(GameObject go)
    {
        yield return new WaitForSeconds(timeToDespawn);
        ObjectPooling.Despawn(go);
    }
}
