using UnityEngine;

public class UpgradeDoc : MonoBehaviour {

    private UiManger uiManger;
    private ShipManager shipManager;
    
    public bool playerInRange = false;

    private void Awake()
    {
        uiManger = FindObjectOfType<UiManger>();
        shipManager = FindObjectOfType<ShipManager>();
    }

    private void Update()
    {
        if (playerInRange)
        {
            uiManger.OpenUpgradeDoc();
        }
        else if(!playerInRange)
        {
            uiManger.CloseUpgradeDoc();
        }

        if (shipManager.currentLevel == 2)
        {
            uiManger.shipUpgrade.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    
}
