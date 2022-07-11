using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private Plane plane;
    [SerializeField] private GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.VehicleType == 0)
        {
            Instantiate(plane);
            ground.gameObject.SetActive(false);
        }
        else
        {
            Instantiate(car);
            ground.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
