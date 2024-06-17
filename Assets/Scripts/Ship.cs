using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Ship Cannon Objects")]
    [SerializeField] private GameObject leftCannon;
    [SerializeField] private GameObject rightCannon;
    [Header("Ship Decor Objects")]
    [SerializeField] private GameObject sail_closed;
    [SerializeField] private GameObject sail_opened;
    [SerializeField] private GameObject anchor;
    [Header("Ship Variables")]
    [SerializeField]private int velocity;
    [SerializeField]private int rotationSpeed;
    void Update()
    {
        // ship movement
        switch (GameManager.GetInstance().GetState())
        {
            case GameManager.state.All:
                transform.Translate(Vector3.right * Time.deltaTime * -3 * velocity);
                break;
            case GameManager.state.Mid:
                transform.Translate(Vector3.right * Time.deltaTime * -2 * velocity);
                break;
            case GameManager.state.Low:
                transform.Translate(Vector3.right * Time.deltaTime * -1 * velocity);
                break;
            case GameManager.state.Stop:
                
                break;
        }
        switch (GameManager.GetInstance().GetState())
        {
            case GameManager.state.All:
                sail_closed.SetActive(false);
                sail_opened.SetActive(true);
                anchor.SetActive(true);
                break;
            case GameManager.state.Mid:
                sail_closed.SetActive(false);
                sail_opened.SetActive(true);
                anchor.SetActive(true);
                break;
            case GameManager.state.Low:
                sail_closed.SetActive(true);
                sail_opened.SetActive(false);
                anchor.SetActive(true);
                break;
            case GameManager.state.Stop:
                sail_closed.SetActive(true);
                sail_opened.SetActive(false);
                anchor.SetActive(false);
                break;
        }
        if (Input.GetKey(InputManager.rotateLeft))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(InputManager.rotateRight))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(InputManager.aim))
        {
            // if the pointer is over the right side of the screen
            if (Input.mousePosition.x > Screen.width / 2)
            {
                rightCannon.SetActive(true);
                leftCannon.SetActive(false);
            }
            else
            {
                leftCannon.SetActive(true);
                rightCannon.SetActive(false);
            }
        }
        if (Input.GetKeyUp(InputManager.aim))
        {
            rightCannon.SetActive(false);
            leftCannon.SetActive(false);
        }
    }
}
