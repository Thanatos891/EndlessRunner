using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_Controller : MonoBehaviour {

    public int speed = 1;
    private float speedCounter = 5;
    [SerializeField]
    private Vector3 jump;

    public bool isRunning = false;
    public static float distanceTraveled;
    [SerializeField]
    private bool isTouchingPlatform = false;
    public Vector3 startPosition;
    public delegate void returnToStart(Vector3 startPosition);
    public returnToStart rs;

    public Rigidbody rb;
    void Start()
    {
        
        startPosition = transform.position;
        isRunning = true;
        isTouchingPlatform = true;
        StartCoroutine(IncreaseSpeed());
        distanceTraveled = transform.localPosition.x;
        rs += ResetToStart;
    }
	void Update () {
        Debug.Log(speed);
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(x, 0, 0);
        if (isTouchingPlatform && Input.GetButtonDown("Jump"))
        {
           rb.AddForce(jump,ForceMode.VelocityChange);
           isTouchingPlatform = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rs(startPosition);
            speed = 3;
        }
	}

    IEnumerator IncreaseSpeed()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(speedCounter);
            if (speed < 7)
            {
                speed++;
            }
        }
        StartCoroutine(IncreaseSpeed());
    }
    private void OnCollisionEnter(Collision other)
    {
        isTouchingPlatform = true;
    }
    private void OnCollisionExit(Collision other)
    {
        isTouchingPlatform = false;
    }
    private void ResetToStart(Vector3 startPosition)
    {
        transform.position = startPosition;
    }
}
