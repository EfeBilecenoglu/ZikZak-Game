using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    private Rigidbody rb;
    private bool walkingRight;


    //ANIMATION AREA
    public Transform rayStart;
    private Animator anim;

    //GAME START

    public GameManager gameManager;

    //EFFECT AREA

    public GameObject crystalEffect;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Switch();
            
        }

        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position,-transform.up,out hit,Mathf.Infinity))
        {
            anim.SetTrigger("isFalling");
        }
        else
        {
            anim.SetTrigger("notFalling");
        }


        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }


    }
    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else 
        {
            anim.SetTrigger("startRunning");
        }
       
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
        
    }

    private void Switch()
    {
        if(!gameManager.gameStarted)
        { return; }
        if (walkingRight)
        {
            transform.rotation= Quaternion.Euler(0, 45, 0);  //Rotation change
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        walkingRight = !walkingRight;
    }

    private void OnTriggerEnter(Collider other) //when hit something, run this method
    {
        if (other.tag == "Crystal")
        {     
            gameManager.IncreaseScore();
            GameObject g=Instantiate(crystalEffect,rayStart.transform.position,Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
        
    }

}
