using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControl : MonoBehaviour
{
    private string smackTrigger;
    public GameObject OkRoach;
    public GameObject DeadRoach;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(smackTrigger))
        {
            Debug.Log("Collision with target object detected!");
            // Perform additional actions or logic here
            OkRoach.SetActive(false);
            DeadRoach.SetActive(true);
        }
    }
}
