using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private float hor, ver;

    [SerializeField]private Animator anim;
    [SerializeField]private Transform graphic;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (hor > 0)
        {
            graphic.localScale = new Vector3(-1,1,1); 
        }

        rb.velocity = new Vector2(hor * speed * Time.deltaTime, ver * speed * Time.deltaTime);

       
    }

  
}
