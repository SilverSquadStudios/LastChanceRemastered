using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour {

    //Max number of platforms to be in the game at once.
    public int maxPlatforms = 20;

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
    public GameObject coin;

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
        Vector2 pos3 = originPosition + new Vector2(xCor, yCor + (height / 1.85f));

        if (rnd == 1)
        {
            //Create a new coin object with same location as the platform.
            Instantiate(coin, pos3, Quaternion.identity);
        }

        //Sets original position as vector.
        originPosition = pos;
    }
}
