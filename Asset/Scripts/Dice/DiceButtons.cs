using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceButtons : MonoBehaviour
{
    [SerializeField] Button reroll;
    [SerializeField] Button go;
    DiceRoller diceRoller;

    void Awake()
    {
        diceRoller = FindObjectOfType<DiceRoller>();
    }

    void Start()
    {
        SetButtonsActive(false);
    }

    public void SetButtonsActive(bool active)
    {
        reroll.gameObject.SetActive(active);
        go.gameObject.SetActive(active);
    }

}
