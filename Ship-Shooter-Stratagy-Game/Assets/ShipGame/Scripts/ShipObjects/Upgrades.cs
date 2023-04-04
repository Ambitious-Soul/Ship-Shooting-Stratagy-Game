using UnityEngine;

public class Upgrades : MonoBehaviour
{
    //COIN VALUES THAT WILL INCREASE ACORDING TO LEVEL
    [SerializeField] private int upgradeLootCoins = 40;
    [SerializeField] private int upgradeHealthCoins = 20;
    [SerializeField] private int upgradeShipCoins = 100;

    private int healthPoint = 5;
   
    
    private ShipManager shipManager;
    private UiManger uiManger;
    private HealthBar healthBar;
    private CameraManager cameraManager;

    private void Awake()
    {
        
        shipManager = GetComponent<ShipManager>();

        uiManger    = FindObjectOfType<UiManger>();
        healthBar   = FindObjectOfType<HealthBar>();
        cameraManager = FindObjectOfType<CameraManager>();
    }
    private void Start()
    {


        //Setting Basic Names 
        uiManger.lootText.text = "Loot : " + "x" + (shipManager.loot * 2).ToString();
        uiManger.healthText.text = "Health : " + (healthPoint).ToString();
        uiManger.shipText.text = "Ship : " + "Lv " + (shipManager.currentLevel+1).ToString();

        //Setting Basic value of buy buttons 
        uiManger.lootButtonText.text = upgradeLootCoins.ToString();
        uiManger.healthButtonText.text = upgradeHealthCoins.ToString();
        uiManger.shipUpgradeButtonText.text = upgradeShipCoins.ToString();

    }
    public void Upgrade_Loot()
    {

        if (GameManager.instance.pirateCoins >= upgradeLootCoins)
        {
            //DEBIT COINS
            GameManager.instance.DebitCoins(upgradeLootCoins);
            //UPGRADE lOOT POINTS
            shipManager.loot *= 2;
            //UPGRADE LOOT_COINS
            upgradeLootCoins = upgradeLootCoins * 2;

        }
        //SETTING UI ACCORDING
        uiManger.lootButtonText.text = upgradeLootCoins.ToString();
        uiManger.lootText.text = "Loot : " + "x " + (shipManager.loot * 2).ToString();

    }
    public void Upgrade_Health()
    {
        if (GameManager.instance.pirateCoins < upgradeHealthCoins)
            return;

        if (shipManager.shipcurrentHealth < shipManager.shipMaxHealth)
        {
            //DEBIT COINS
            GameManager.instance.DebitCoins(upgradeHealthCoins);
            //ADD HEALTH
            shipManager.shipcurrentHealth += healthPoint;
            //UPGRADE HEALTH_COIN,HEALTH_POINT,
            upgradeHealthCoins = upgradeHealthCoins * 2;
            healthPoint = healthPoint * 2;

        }
        //SETTING UI ACCORDING
        uiManger.healthButtonText.text = upgradeHealthCoins.ToString();
        uiManger.healthText.text = "Health : " + healthPoint.ToString();


    }
    public void Upgrade_Ship()
    {
        if (GameManager.instance.pirateCoins < upgradeShipCoins)
            return;


        if (shipManager.currentLevel < 3)
        {
            //DEBIT COINS
            GameManager.instance.DebitCoins(upgradeShipCoins);
            //UPGRADE SHIP HEALTH ACORDING TO LEVELS
            shipManager.shipMaxHealth *= 2;
            shipManager.shipcurrentHealth = shipManager.shipMaxHealth;
            //UPGRADE LEVEL COUNTER
            shipManager.currentLevel++;
            //SET HEALTHBAR SIZE TO MAX HEALTH
            healthBar.healthSlider.maxValue = shipManager.shipMaxHealth;
            upgradeShipCoins *= 2;

        }
        //SETTING UI ACCORDING
        uiManger.shipUpgradeButtonText.text = upgradeShipCoins.ToString();
        uiManger.shipText.text = "Ship : " + "Lv " + (shipManager.currentLevel+1).ToString();
        //setting Camera
        cameraManager.ChangeOrtho();
        //SETTING TRANSITION
       
    }
}
