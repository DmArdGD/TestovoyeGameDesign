using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentPoint;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    public GameObject Player;

   
    private void Update()
    {
        if (Vector3.Distance(waypoints[currentPoint].transform.position, transform.position) < WPradius)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].transform.position, Time.deltaTime * speed);

       
    }
    private void OnTriggerEnter(Collider other)
    {

        Player.transform.Rotate(0, -90, 0);
       
    }

}
