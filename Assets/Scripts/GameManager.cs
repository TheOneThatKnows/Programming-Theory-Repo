using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vehicle[] vehicles;
    [SerializeField] private Car car;
    [SerializeField] private Plane plane;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject yearFieldPanel;
    [SerializeField] private TMP_InputField yearField;
    [SerializeField] private TMP_Text yearText;
    [SerializeField] private AudioClip[] horns;

    private int vTyoe;
    private Vehicle vehicle;
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
        vehicle = Instantiate(vehicles[vTyoe]);
        ground.gameObject.SetActive(vTyoe == 1);
    }

    public void InitialAdjustments()
    {

        zPos = vehicle.transform.position.z + 30;
        zPosGround = vehicle.transform.position.z + 90;
        cloudObject = Instantiate(cloud, vehicle.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), 10, 10), cloud.transform.rotation);
    }

    public void CloudTransform()
    {
        if (vehicle.transform.position.z > zPos)
        {
            zPos = vehicle.transform.position.z + 30;
            cloudObject.transform.position = vehicle.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), (1 - vTyoe) * Random.Range(0, 10.0f) + vTyoe * 10, 20);
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
        vehicle.Year = yearOfVehicle;

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
        audio.clip = horns[vehicle.Horn()];

        audio.Play();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
