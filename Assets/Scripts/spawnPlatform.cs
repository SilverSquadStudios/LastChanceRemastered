using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour {

    //Constants
    public int maxPlatforms = 20;
    private static float coinSpawnHeightDiv = 1.85f;
    private static int coinXBuffer = 3;
    private static float xCorBuffer = 2.4f;
    public int platformSpawnTime = 30;

    //The actuall game platform itself
    public GameObject floorObject;
    public static GameObject platform;

    public GameObject coinObj1;
    public static GameObject coin1;
    
    public GameObject coinObj2;
    public static GameObject coin2;
    
    public GameObject coinObj3;
    public static GameObject coin3;
    
    private int spawnCounterTime = 0;

    //Convert to RECT
    private RectTransform _platformRectTrans;

    //Horizontal discrepency min
    public float horizontalCons;
    public static float horCons;

    //Vertical discrepency min
    public static float verticalMin = -6f;

    //Vertical discrepency max
    public static float verticalMax = 6;

    //Vector to base the platforms off of.
    private static Vector2 originPosition;

    //The x coordinate of the platform.
    private static float xCor = 0;

    //The y coordinate of the platform.
    private static float yCor = 0;


    void Start()
    {
        platform = floorObject;
        coin1 = coinObj1;
        coin2 = coinObj2;
        coin3 = coinObj3;
        horCons = horizontalCons;
        originPosition = transform.position;
        Spawn();

    }

    private void Update()
    {
        spawnCounterTime++;
        if (spawnCounterTime == platformSpawnTime)
        {
            //spawnPlatformCoin();
            spawnCounterTime = 0;

        }

    }

    void Spawn()
    {
        //For loop form 0 --> number set to be as max platforms.
        for (int i = 0; i < maxPlatforms; i++)
        {
            spawnPlatformCoin();
        }
    }

    public static void spawnPlatformCoin()
    {
        float height = platform.GetComponent<SpriteRenderer>().bounds.size.y;

        xCor = horCons;
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
