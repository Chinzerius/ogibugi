using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_move : MonoBehaviour
{
    [SerializeField] private GameObject[] wayp;
    private int currentWaypIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(wayp[currentWaypIndex].transform.position, transform.position)< .1f)
        {
            currentWaypIndex++;
            if (currentWaypIndex >= wayp.Length)
            {
                currentWaypIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayp[currentWaypIndex].transform.position, Time.deltaTime * speed);
    }
}
