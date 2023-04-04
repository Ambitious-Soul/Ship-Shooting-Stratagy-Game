using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTurret : MonoBehaviour
{
    [SerializeField,Range(1,100)] private float rotationSpeed = 10;

    [Header("x = min , y = max Clamp")]
    [SerializeField] private bool shouldClamp = false;
    [SerializeField] private Vector2 xClamp;
    [SerializeField] private Vector2 yClamp;
    [SerializeField] private float range;

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    private Camera cam;
    
    private bool playerInRange;
    void Awake()
    {
        cam = Camera.main;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        if (!playerInRange)
            return;

        moveTurret();
    }
        
    void moveTurret()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (shouldClamp)
        {
            mousePosition = new Vector2(Mathf.Clamp(mousePosition.x, xClamp.x, xClamp.y), Mathf.Clamp(mousePosition.y, yClamp.x, yClamp.y));
        }
        mousePosition.z = 0;

        //transform.up = mousePosition;
        transform.up = Vector3.MoveTowards(transform.up, mousePosition, rotationSpeed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity).Init(transform.up);
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
