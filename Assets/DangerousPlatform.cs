using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousPlatform : MonoBehaviour
{
    MeshRenderer meshRend;

    [SerializeField] List<Material> materials = new List<Material>();
    bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        meshRend.material = materials[0];
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && !cooldown)
        {
            Debug.Log(collision.collider.gameObject);
            StartCoroutine(MakeDamage());
            cooldown = true;
        }
    }

    IEnumerator MakeDamage()
    {
        meshRend.material = materials[1];
        yield return new WaitForSeconds(1f);
        meshRend.material = materials[2];
        yield return new WaitForSeconds(0.1f);
        meshRend.material = materials[0];
        yield return new WaitForSeconds(5f);
        cooldown = false;
    }
}
