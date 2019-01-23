using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    private Player p;
    private Rigidbody rb;
    private AudioSource source;

    public float maxSpeed, acceleration, turnSpeed;
    private float speed;

    public AudioClip carStart, carDrive, carStop;
    
	void Start ()
    {
        p = ReInput.players.GetPlayer(0);
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        speed = Mathf.Clamp(p.GetAxis("drive") * (Time.deltaTime * acceleration), -maxSpeed, maxSpeed);
        transform.Translate(Vector3.forward * speed);
        //Vector3 worldVelocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        //rb.velocity = transform.TransformDirection(worldVelocity);
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);

        float rotation = p.GetAxis("turn") * turnSpeed;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + rotation, 0);
    }
}
