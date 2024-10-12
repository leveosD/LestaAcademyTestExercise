using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlatform : MonoBehaviour
{
    float windForce = 7000f;
    Vector3 direction;
    bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.zero;
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log(collision.rigidbody.velocity);
            //direction.y = collision.rigidbody.velocity.y;
            collision.rigidbody.velocity = new Vector3(0, collision.rigidbody.velocity.y, 0);
            collision.rigidbody.AddForce(direction, ForceMode.Force);
            if (!cooldown)
                StartCoroutine(ChangeDirection());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.rigidbody.velocity = new Vector3(0, collision.rigidbody.velocity.y, 0);
        }
    }

    IEnumerator ChangeDirection() 
    {
        cooldown = true;
        float x = Random.Range(-windForce, windForce);
        float z = -windForce + Mathf.Abs(x);
        x = x >= 0 ? Mathf.Sqrt(x) : -Mathf.Sqrt(Mathf.Abs(x));
        z = z >= 0 ? Mathf.Sqrt(z) : -Mathf.Sqrt(Mathf.Abs(z));
        direction = new Vector3(x, 0, z);
        //Debug.Log(cooldown + " " + direction);
        
        yield return new WaitForSeconds(2f);
        cooldown = false;
    }
}
