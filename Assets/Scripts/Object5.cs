﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object5 : Object
{
    int[,] curMap = new int[4, 4] { { 0, 0, 0, 0 },
                                    { 0, 0, 1, 0 },
                                    { 1, 1, 1, 0 },
                                    { 0, 0, 0, 0 }, };
    protected override void SetBlockMap()
    {
        map = curMap;
    }
}
