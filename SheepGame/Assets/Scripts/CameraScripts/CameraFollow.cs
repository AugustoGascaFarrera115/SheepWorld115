using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    float damping = 2f;
    float height = 10f;

    Vector3 startPosition;

    bool canFollow;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        canFollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }


    void Follow()
    {
        if(canFollow)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(player.position.x + 10f, player.position.y + height, player.position.z -10f), Time.deltaTime * damping);
        }
    }

    public bool CanFollow
    {
        get{
            return canFollow;
        }
        set{
            canFollow = value;
        }
    }
}
