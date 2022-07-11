using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -10);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Vehicle");

        if (MainManager.Instance.VehicleType == 0)
        {
            offset = new Vector3(0, 6, -18);
        }
        else
        {
            offset = new Vector3(0, 4, -10);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
