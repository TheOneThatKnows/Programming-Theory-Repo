using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private Plane plane;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject yearFieldPanel;
    [SerializeField] private TMP_InputField yearField;
    [SerializeField] private TMP_Text yearText;
    [SerializeField] private AudioClip[] horns;

    private int vTyoe;
    private GameObject vehicle;
    private Plane planeObject;
    private Car carObject;
    private GameObject cloudObject;
    private float zPos;
    private float zPosGround;

    private AudioSource audio;

    public bool gameIsActive;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        gameIsActive = true;

        // ABSTRACTION
        VehicleInstantiate();

        // ABSTRACTION
        InitialAdjustments();
    }

    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        CloudTransform();

        // ABSTRACTION
        GroundTransform();
    }

    public void VehicleInstantiate()
    {
        vTyoe = MainManager.Instance.VehicleType;

        if (vTyoe == 0)
        {
            planeObject = Instantiate(plane);
            ground.gameObject.SetActive(false);
        }
        else
        {
            carObject = Instantiate(car);
            ground.gameObject.SetActive(true);
        }
    }

    public void InitialAdjustments()
    {
        vehicle = GameObject.FindGameObjectWithTag("Vehicle");
        zPos = vehicle.transform.position.z + 30;
        zPosGround = vehicle.transform.position.z + 90;
        cloudObject = Instantiate(cloud, vehicle.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), 10, 10), cloud.transform.rotation);
    }

    public void CloudTransform()
    {
        if (vehicle.transform.position.z > zPos)
        {
            zPos = vehicle.transform.position.z + 30;
            if (vTyoe == 0)
                cloudObject.transform.position = vehicle.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(0, 10.0f), 20);
            else
                cloudObject.transform.position = vehicle.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), 10, 20);
        }
    }

    public void GroundTransform()
    {
        if (vTyoe == 1 && vehicle.transform.position.z > zPosGround)
        {
            zPosGround = vehicle.transform.position.z + 90;
            ground.transform.position = ground.transform.position + new Vector3(0, 0, 90);
        }
    }

    public void Year()
    {
        yearFieldPanel.gameObject.SetActive(gameIsActive);
        gameIsActive = !gameIsActive;
    }

    public void OK()
    {
        float yearOfVehicle = float.Parse(yearField.text);

        if (vTyoe == 0)
            planeObject.Year = yearOfVehicle;
        else
            carObject.Year = yearOfVehicle;

        if (yearOfVehicle < 0)
            yearText.text = "Year cannot be negative";
        else
            yearText.text = yearOfVehicle + "";

        yearFieldPanel.gameObject.SetActive(false);

        yearText.gameObject.SetActive(true);
        gameIsActive = true;
    }

    public void Horn()
    {
        if (vTyoe == 0)
        {
            audio.clip = horns[planeObject.Horn()];
        }
        else
        {
            audio.clip = horns[carObject.Horn()];
        }
        audio.Play();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
