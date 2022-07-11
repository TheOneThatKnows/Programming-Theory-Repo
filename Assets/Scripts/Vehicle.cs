using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    protected float speed = 0.4f;
    protected float rotationSpeed = 20.0f;

    private float year;
    public float Year
    {
        get
        {
            return year;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Year of the vehicle cannot be a negative number");
            }
            else
            {
                year = value;
            }
        }
    }

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
