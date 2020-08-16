using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        ActivateFalling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateFalling()
    {
        this.gameObject.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            
            Invoke("ActivateFalling", 2f);
            print("THE FUNCTION HAS ENTRRYYYYYYYYYYY");
        }
    }

}
