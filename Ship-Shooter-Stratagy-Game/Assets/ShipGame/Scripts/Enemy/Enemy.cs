using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private int damage = 2;
    [SerializeField] private GameObject damageUi;
    public int lootCoins = 2;

    private Transform target;
    private ShipManager shipManager;
    private CameraManager cameraManager;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        cameraManager = FindObjectOfType<CameraManager>();
    }
    private void Start()
    {
        
        shipManager = FindObjectOfType<ShipManager>();
        target = shipManager.gameObject.transform;
    }
    private void Update()
    {


        Vector2 targetPos = target.position;
        //float distanceFromBoat = Vector2.Distance(target.position, transform.position);
        Vector2 moveDirection = targetPos - (Vector2)transform.position;
        transform.up = moveDirection;

       
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            soundManager.source_shipCollisionSfx.PlayOneShot(soundManager.shipCollisionSfx);
            GameObject damageTxt= Instantiate(damageUi, transform.position, Quaternion.identity);
            damageTxt.GetComponentInChildren<TextMeshPro>().text = "-" + damage.ToString();
            damageTxt.GetComponentInChildren<TextMeshPro>().color = Color.red;
            
            shipManager.ResuceHealth(damage);
            cameraManager.Shake(0.7f,0.7f,0.3f);
            Destroy(gameObject);
            
        }
    }

    
}



