using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DargonController : MonoBehaviour
{

   public bool selfkill = false;
    Rigidbody Rigidbody;
   public float speed;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(1 ,4);
        Rigidbody.velocity = (transform.forward * speed* 100 * Time.fixedDeltaTime);
        StartCoroutine(dews());
    }

    IEnumerator dews()
    {
       
        
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
        selfkill = true;
    }
}
