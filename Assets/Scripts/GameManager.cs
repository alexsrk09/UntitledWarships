using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] private int coins = 0;
    [Header("Game Objects")]
    [SerializeField] private GameObject coinsObject;
    [Header("Camera Variables")]
    [SerializeField] private GameObject VMship;
    [SerializeField] private GameObject VMmenu;
    [SerializeField] private float VMshipmaxZoom;
    [SerializeField] private float VMshipminZoom;
    [SerializeField] private GameObject[] VMs;
    private GameObject actualCamera;
    private static GameManager instance;
    private state currentState;
    public enum state
    {
        All,
        Mid,
        Low,
        Stop
    }
    private void Start()
    {
        instance = this;
        // desactivate all cameras unles the first one
        for (int i = 1; i < VMs.Length; i++)
        {
            VMs[i].SetActive(false);
            VMmenu.SetActive(false);
        }
    }
    void Update()
    {
        // coinsObject has as child x coins, we have to show as many coins as the player has
        for (int i = 0; i < coinsObject.transform.childCount; i++)
        {
            if (i < coins) coinsObject.transform.GetChild(i).gameObject.SetActive(true);
            else coinsObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        // Debug.Log(Time.timeScale);
        // if the camera is in VMmenu position
        if (GameObject.Find("Main Camera").transform.position == VMmenu.transform.position && VMmenu.activeSelf) Time.timeScale = 0;
        else Time.timeScale = 1;
        // key escape to open the menu
        if (Input.GetKeyDown(InputManager.openMenu)) Menu();
        // key f to change the camera
        if (Input.GetKeyDown(InputManager.changeCamera)) ChangeCamera();
        // if the wheel is scrolled up and the zoom is not at the max (rueda hacia atras)
        if (VMship.activeSelf && Input.GetAxis("Mouse ScrollWheel") < 0 && VMship.transform.position.y < VMshipminZoom) VMship.transform.position += new Vector3(0, 1, 0);
        // if the wheel is scrolled down and the zoom is not at the min (rueda hacia adelante)
        else if (VMship.activeSelf && Input.GetAxis("Mouse ScrollWheel") > 0 && VMship.transform.position.y > VMshipmaxZoom) VMship.transform.position -= new Vector3(0, 1, 0);
        if (Input.GetKeyDown(InputManager.upState)) UpState();
        if (Input.GetKeyDown(InputManager.downState)) DownState();
    }
    private void Menu()
    {
        // if time is not stopped, stop it
        if (!VMmenu.activeSelf)
        {
            VMmenu.SetActive(true);
            // desactivate the camera and store it
            for (int i = 0; i < VMs.Length; i++)
            {
                if (VMs[i].activeSelf)
                {
                    actualCamera = VMs[i];
                    VMs[i].SetActive(false);
                    break;
                }
            }

        }
        // if time is stopped, start it
        else
        {
            VMmenu.SetActive(false);
            // activate the first camera
            actualCamera.SetActive(true);
        }
    }
    private void ChangeCamera()
    {
        for (int i = 0; i < VMs.Length; i++)
        {
            if (VMs[i].activeSelf)
            {
                VMs[i].SetActive(false);
                if (i == VMs.Length - 1) VMs[0].SetActive(true);
                else VMs[i + 1].SetActive(true);
                break;
            }
        }
    }
    private void UpState()
    {
        switch (currentState)
        {
            case state.Stop:
                currentState = state.Low;
                break;
            case state.Low:
                currentState = state.Mid;
                break;
            case state.Mid:
                currentState = state.All;
                break;
        }
    }
    private void DownState()
    {
        switch (currentState)
        {
            case state.All:
                currentState = state.Mid;
                break;
            case state.Mid:
                currentState = state.Low;
                break;
            case state.Low:
                currentState = state.Stop;
                break;
        }
    }

    public state GetState()
    {
        return currentState;
    }
    public int GetCoins()
    {
        return coins;
    }
    public static GameManager GetInstance()
    {
        return instance;
    }
}
