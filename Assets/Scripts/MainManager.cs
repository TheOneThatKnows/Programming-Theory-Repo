using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private int vehicleType = 0;
    public int VehicleType
    {
        get
        {
            return vehicleType;
        }
        set
        {
            vehicleType = value;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // LoadRecord();
    }
}
