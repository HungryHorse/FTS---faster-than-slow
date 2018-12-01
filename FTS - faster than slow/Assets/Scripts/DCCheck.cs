using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCCheck
{
    public bool doCheck(float DC)
    {
        int rand = Random.Range(0, 1);

        if (rand >= DC)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
