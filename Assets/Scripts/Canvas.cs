using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] private GameObject coinsText;
    void Update()
    {
        coinsText.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.GetInstance().GetCoins().ToString();
    }
}
