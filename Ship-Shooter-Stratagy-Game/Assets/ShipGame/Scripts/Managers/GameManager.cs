using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int pirateCoins;

    [SerializeField] private iTween.EaseType ease;

    
    [SerializeField]private WaveSpawner waveSpawner;
    [SerializeField]private ShipPlayer shipPlayer;
    [SerializeField]private UiManger uiManger;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CreditCoins(int coins)
    {
        pirateCoins += coins;
    }
    public void DebitCoins(int coins)
    {
        if (pirateCoins >= coins)
        {
            pirateCoins -= coins;
        }
        else
        {
            Debug.Log("Dont have sufficient coins");
        }
        
    }

    private IEnumerator HoverEffect(GameObject ob,float time)
    {
        iTween.ScaleTo(ob, iTween.Hash("scale", new Vector3(2f, 2f, 2f), "time", .5f, "easeType", ease));
        yield return new WaitForSeconds(time);
        iTween.ScaleTo(ob, iTween.Hash("scale", new Vector3(1f, 1f, 1f), "time", .5f, "easeType", ease));

    }

    public void Hover(GameObject obj,float time)
    {
        StartCoroutine(HoverEffect(obj,time));
    }

    public void StopGame()
    {
        FindObjectOfType<CanonTurret>().enabled = false;
        waveSpawner.enabled = false;
        shipPlayer.enabled = true;
    }

    public void GameWin()
    {
        StartCoroutine(Win());
    }
    public void GameLose()
    {
        StartCoroutine(Lose());
    }
    IEnumerator Win()
   {
        StopGame();
        yield return new WaitForSeconds(2f);
        uiManger.gameWinPannel.SetActive(true);
    }
    IEnumerator Lose()
    {
        StopGame();
        yield return new WaitForSeconds(2f);
        uiManger.gameOverPannel.SetActive(true);
    }

}
