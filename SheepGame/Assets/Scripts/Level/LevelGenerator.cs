using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject startPlatform;
    [SerializeField]
    public GameObject platform;
    [SerializeField]
    public GameObject endPlatform;



    private float blockWidth = 0.5f;
    private float blockHeight = 0.2f;


    [SerializeField]
    public int amountToSpawn = 100;
    private int beginAmount = 0;


    private Vector3 lastPosition = Vector3.zero;


    private List<GameObject> spawnedPlatforms = new List<GameObject>();


    [SerializeField]
    private GameObject playerPrefab;


    // Start is called before the first frame update
    void Awake()
    {
        InstantiateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateLevel()
    {
        for (float i = beginAmount; i < amountToSpawn; i++)
        {
            GameObject newPlatform;

            if (i == 0)
            {
                newPlatform = Instantiate(startPlatform, transform.position, Quaternion.identity);
            } else if (i == amountToSpawn - 1)
            {
                newPlatform = Instantiate(endPlatform, transform.position, Quaternion.identity);
                newPlatform.tag = "EndPlatform";
            }
            else
            {
                newPlatform = Instantiate(platform, transform.position, Quaternion.identity);
            }

            newPlatform.transform.parent = transform;

            spawnedPlatforms.Add(newPlatform);



            if (i == 0)
            {
                lastPosition = newPlatform.transform.position;

                //instantiate player
                continue;
            }


            int left = Random.Range(0, 2);

            if (left == 0)
            {
                newPlatform.transform.position = new Vector3(lastPosition.x - blockWidth, lastPosition.y + blockHeight, lastPosition.z);
            }
            else
            {
                newPlatform.transform.position = new Vector3(lastPosition.x, lastPosition.y + blockHeight, lastPosition.z + blockWidth);
            }


            lastPosition = newPlatform.transform.position;

            //fancy animation
            if (i < 25)
            {
                float endPosition = newPlatform.transform.position.y;

                newPlatform.transform.position = new Vector3(newPlatform.transform.position.x,newPlatform.transform.position.y - blockHeight * 5f,newPlatform.transform.position.z);


                //newPlatform.transform.DOLocalMoveY(endPosition, 0.3f).SetDelay(i * 0.1f);
            }


        } // loop 
    }
}
