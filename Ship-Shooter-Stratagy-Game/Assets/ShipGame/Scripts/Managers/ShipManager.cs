using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public int shipMaxHealth = 100;
    public int shipcurrentHealth = 0;
    public int loot;
    public int currentLevel = 0;
    private int i;
    
    [SerializeField]private GameObject[] ships;
    private UiManger uiManger;
    private void Awake()
    {
        shipcurrentHealth = Mathf.Clamp(shipcurrentHealth, 0, 1000);
        uiManger = FindObjectOfType<UiManger>();
    }
    void Start()
    {

        i = currentLevel;
        ships[i].SetActive(true);
        shipcurrentHealth = shipMaxHealth;
    }
    private void Update()
    {
        UpgradeShipGraphics();
        if (shipcurrentHealth <= 0)
        {
            GameManager.instance.GameLose();
        }
    }
    public int ResuceHealth(int damage)
    {
        if (shipcurrentHealth > 0)
        {
            shipcurrentHealth -= damage;
        }
        return shipcurrentHealth;
    }

    void UpgradeShipGraphics()
    {
        
        if (currentLevel > i)
        {
            ships[currentLevel].SetActive(true);
            ships[i].SetActive(false);
            i++;
        }
    }

 
}
