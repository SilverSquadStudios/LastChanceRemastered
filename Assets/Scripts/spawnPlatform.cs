using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour {

    //Constants
    public int maxPlatforms = 20;
    private float coinSpawnHeightDiv = 1.85f;
    private int coinXBuffer = 3;
    private float xCorBuffer = 2.4f;

    //The actuall game platform itself
    public GameObject platform;

    //Convert to RECT
    private RectTransform _platformRectTrans;

    //Horizontal discrepency min
    public float horizontalMin = 7.5f;

    //Horizontal discrepency max
    public float horizontalMax = 14f;

    //Vertical discrepency min
    public float verticalMin = -6f;

    //Vertical discrepency max
    public float verticalMax = 6;

    //Vector to base the platforms off of.
    private Vector2 originPosition;

    //The x coordinate of the platform.
    private float xCor = 0;

    //The y coordinate of the platform.
    private float yCor = 0;

    //Coin object to refrence.
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;

    void Start()
    {
        originPosition = transform.position;
        Spawn();

    }

    void Spawn()
    {
        //For loop form 0 --> number set to be as max platforms.
        for (int i = 0; i < maxPlatforms; i++)
        {
            spawnPlatformCoin();
        }
    }

    private void spawnPlatformCoin()
    {
        float height = platform.GetComponent<SpriteRenderer>().bounds.size.y;
        
        xCor = Random.Range(horizontalMin, horizontalMax);
        yCor = Random.Range(verticalMin, verticalMax) - originPosition.y;

        //Creates a new vector within the ranges of horizontal min/max and vertical min/max
        Vector2 pos = originPosition + new Vector2(xCor, yCor);

        //Creates a new object with properties from the vector.
        Instantiate(platform, pos, Quaternion.identity);

        int rnd = 1;//Random.Range(1, 10);
            
        //Height the yCor is offset by height / scale factor to get the proportion of where it would be based on how big the platform is.
        Vector2 posCoin1 = originPosition + new Vector2(xCor - xCorBuffer, yCor + (height / coinSpawnHeightDiv));
        Vector2 posCoin2 = originPosition + new Vector2(xCor - xCorBuffer + coinXBuffer, yCor + (height / coinSpawnHeightDiv));
        Vector2 posCoin3 = originPosition + new Vector2(xCor - xCorBuffer + (coinXBuffer + coinXBuffer), yCor + (height / coinSpawnHeightDiv));


        if (rnd == 1)
        {
            //Create a new coin object with same location as the platform.
            Instantiate(coin1, posCoin1, Quaternion.identity);
            Instantiate(coin2, posCoin2, Quaternion.identity);
            Instantiate(coin3, posCoin3, Quaternion.identity);
        }

        //Sets original position as vector.
        originPosition = pos;
    }
}
