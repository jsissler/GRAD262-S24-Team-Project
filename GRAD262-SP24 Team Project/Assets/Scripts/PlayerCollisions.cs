using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"collided with {collision.gameObject.name}");
        //UIManager.Instance.ShipHealth();
        GetComponent<PlayerHealth>().TakeDamage(1);
    }
}
