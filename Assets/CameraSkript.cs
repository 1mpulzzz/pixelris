using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSkript : MonoBehaviour
{
    private Transform hero;

    private void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = hero.position.x;
        temp.y = hero.position.y;

        transform.position = temp;
    }
}
