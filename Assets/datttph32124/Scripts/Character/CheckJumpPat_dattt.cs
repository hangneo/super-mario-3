using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CheckJumpPat_dattt : MonoBehaviour
{
    [SerializeField] private Transform targetPos;

    [SerializeField] private int speed;

    private bool isPat = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && isPat)
        {
            Debug.Log("inside");
            transform.position = Vector3.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeadPat"))
        {
            isPat = true;
        }
    }
}
