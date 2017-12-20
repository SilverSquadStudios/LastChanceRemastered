﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour {

    //Max number of platforms to be in the game at once.
    public int maxPlatforms = 20;
    //The actuall game platform itself
    public GameObject platform;
    //Horizontal discrepency min
    public float horizontalMin = 7.5f;
    //Horizontal discrepency max
    public float horizontalMax = 14f;
    //Vertical discrepency min
    public float verticalMin = -6f;
    //Vertical discrepency max
    public float verticalMax = 6;


    private Vector2 originPosition;


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
            //Creates a new vector within the ranges of horizontal min/max and vertical min/max
            Vector2 pos = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            //Creates a new object with properties from the vector.
            Instantiate(platform, pos, Quaternion.identity);
            //Sets original position as vector.
            originPosition = pos;
        }
    }
}
