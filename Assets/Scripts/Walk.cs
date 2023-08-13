using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private float walkSpeed = 2.0f;
    public float gravity = 9.81f;
    Animator animator;
    private CharacterController characterController;
    public GameObject Player;

    public GameObject[] waypoints;
    int currentPoint;
    float rotSpeed;
    float WPradius = 1;


    private void Start()
    {
       animator = GetComponent<Animator>();
       characterController = GetComponent<CharacterController>();
        Player.GetComponent<Animator>().SetBool("Walk", true);
    }

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
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].transform.position, Time.deltaTime * walkSpeed);
       

    }

    private void FixedUpdate()
    {    
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * gravity * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("1"))
        {
            Player.GetComponent<Animator>().SetBool("Walk", true);
            Player.GetComponent<Animator>().SetBool("Run", false);
            walkSpeed = 2.0f;
        }
        if (other.gameObject.CompareTag("FirstTurn"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }


        if (other.gameObject.CompareTag("2"))
        {
            Player.GetComponent<Animator>().SetBool("Walk", false);
            Player.GetComponent<Animator>().SetBool("Run", true);
            walkSpeed = 5.0f;
        }
        if (other.gameObject.CompareTag("SecondTurn"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (other.gameObject.CompareTag("3"))
        {
            Player.transform.rotation = Quaternion.Euler(0, -90, 0);
            Player.GetComponent<Animator>().SetBool("Walk", true);
            Player.GetComponent<Animator>().SetBool("Run", false);
            walkSpeed = 2.0f;
        }

        if (other.gameObject.CompareTag("4"))
        {
            Player.GetComponent<Animator>().SetBool("Walk", false);
            Player.GetComponent<Animator>().SetBool("Run", true);
            walkSpeed = 5.0f;
        }
        if (other.gameObject.CompareTag("FourthTurn"))
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }


    }

    
}
