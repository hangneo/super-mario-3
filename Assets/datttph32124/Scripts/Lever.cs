using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private Transform rockSpawner;

    private bool isSpawn = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (isSpawn)
            {
                Instantiate(rockPrefab, rockSpawner.transform.position, Quaternion.identity);
                StartCoroutine(Respawn());
                Debug.Log("inside");
            }
        }
    }

    public IEnumerator Respawn()
    {
        isSpawn = false;
        yield return new WaitForSeconds(3f);
        isSpawn = true;
    }
}
