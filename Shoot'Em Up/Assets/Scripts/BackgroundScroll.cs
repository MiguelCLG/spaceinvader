﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float xVelocity, yVelocity;

    private Material material;

    private Vector2 offset;

    private void Awake()
    {

        material = GetComponent<Renderer>().material;
    }

    // Use this for initialization
    void Start () {
        offset = new Vector2(xVelocity, yVelocity);

    }

    // Update is called once per frame
    void Update () {

        material.mainTextureOffset += offset * Time.deltaTime;

	}
}
