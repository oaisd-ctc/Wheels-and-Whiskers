using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public FollowCamera cam;
    public GameObject currentCar;
    public GameObject[] cars;
    public GameObject menu;
    public Button cabrioButton;
    public Button hatchButton;
    public Button targaButton;
    public GameObject spawner;
    public Button instructButton;
    public GameObject instructionsScreen;

    // Start is called before the first frame update
    void Start()
    {
        instructionsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !menu.activeSelf)
        {
            menu.SetActive(true);
        }
    }
    public void SelectCabrio()
    {
        if (currentCar != null)
        {
            Destroy(currentCar);
        }
        GameObject instantiatedCar = Instantiate(cars[0], spawner.transform);
        currentCar = instantiatedCar;
        cam.car = currentCar;
        menu.SetActive(false);
    }
    public void SelectHatch()
    {
        if (currentCar != null)
        {
            Destroy(currentCar);
        }
        GameObject instantiatedCar = Instantiate(cars[1], spawner.transform);
        currentCar = instantiatedCar;
        cam.car = currentCar;
        menu.SetActive(false);
    }
    public void SelectTarga()
    {
        if (currentCar != null)
        {
            Destroy(currentCar);
        }
        GameObject instantiatedCar = Instantiate(cars[2], spawner.transform);
        currentCar = instantiatedCar;
        cam.car = currentCar;
        menu.SetActive(false);
    }
    public void OpenInstructionsScreen()
    {
        instructionsScreen.SetActive(true);
        menu.SetActive(false);
    }
    public void CloseInstructionsScreen()
    {
        instructionsScreen.SetActive(false);
        menu.SetActive(true);
    }
}
