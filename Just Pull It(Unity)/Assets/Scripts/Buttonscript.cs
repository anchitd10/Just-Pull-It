using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Buttonscript : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    [SerializeField] float upForce = 0.0f;

    public void ForceonClick()
    {
        if (playerRigidbody != null)
        {
            playerRigidbody.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Player Rigidbody not assigned to the button!");
        }
    }
}
