﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AbstractAbility : MonoBehaviour
{

    public KeyCode defaultKey = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void activate();

}
