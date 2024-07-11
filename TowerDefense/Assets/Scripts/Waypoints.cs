using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] route_0;

    public void Awake()
    {
        route_0 = new Transform[transform.childCount];

        for (int i = 0; i < route_0.Length; i++)
        {
            route_0[i] = transform.GetChild(i);
        }
    }

}
