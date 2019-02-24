using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float xlimitmin = -6.5f;
    public float xlimitmax = 6.5f;
    public void Movement(float xdir, float zdir, float MoveSpeed, float Titl)
    {
        var moveVelocity = new Vector3(xdir, 0, zdir);
        GetComponent<Rigidbody>().velocity = moveVelocity * MoveSpeed;
        GetComponent<Transform>().position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, xlimitmin, xlimitmax),
            0,
            gameObject.transform.position.z
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, -GetComponent<Rigidbody>().velocity.x * Titl);
    }
}
