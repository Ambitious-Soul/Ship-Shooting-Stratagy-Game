using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManger : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI currentWaveUi;

    [Header("Insert Buy Button Texts of all Upgrade Ui")]
    public TextMeshProUGUI lootText;
    public TextMeshProUGUI lootButtonText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthButtonText;
    public TextMeshProUGUI shipText;
    public TextMeshProUGUI shipUpgradeButtonText;
    
    public GameObject shipUpgrade;   
    public GameObject gameOverPannel;
    public GameObject gameWinPannel;
    [SerializeField] private GameObject upgradePanel;
    

   
    private WaveSpawner waveSpawner;
    private Animator UpgradePanelAnimator;
    
    private int i = 0;
    private void Awake()
    {
        UpgradePanelAnimator = upgradePanel.GetComponent<Animator>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }
    private void Start()
    {
        currentWaveUi.text = "Wave : " + waveSpawner.currentWaveIndex.ToString();
    }
    private void Update()
    {
       
        coinText.text = GameManager.instance.pirateCoins.ToString();
        
        if (waveSpawner.currentWaveIndex != i)
        {
            GameManager.instance.Hover(currentWaveUi.gameObject,.5f);
            currentWaveUi.text = "Wave : " + waveSpawner.currentWaveIndex.ToString();
            i = waveSpawner.currentWaveIndex;
        }
        
    }
    public void OpenUpgradeDoc()
    {
        UpgradePanelAnimator.SetBool("Open", true);
    }
    public void CloseUpgradeDoc()
    {
        UpgradePanelAnimator.SetBool("Open", false);
    }

    public void retry()
    {
        SceneManager.LoadScene(1);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }

}
