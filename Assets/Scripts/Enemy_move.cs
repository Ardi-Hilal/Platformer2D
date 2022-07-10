using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool lastMoveRight;
    private Health enemyHP;
    private bool moveActivated;
    private bool isMoving;
    [HideInInspector]public bool isEncounterPlayer;
    
    [SerializeField] private float moveDuration;
    [SerializeField] private float stayDuration;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHP = GetComponent<Health>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEncounterPlayer)
        {
            activateMove();
        }
        else
        {
            stay();
        }

        

        if (isMoving && enemyHP.currHealth > 0)
        {
            if (lastMoveRight)
            {
                rb.velocity = new Vector2(-9, rb.velocity.y);

            }
            else
            {
                rb.velocity = new Vector2(9, rb.velocity.y);

            }
        }

        if(rb.velocity.x > 0.1f)
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
            gameObject.transform.localScale = new Vector3(2, 2, 2);
        }else if(rb.velocity.x < -0.1f)
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
            gameObject.transform.localScale = new Vector3(-2, 2, 2);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", false);
        }
        
    }

    public void activateMove()
    {
        if (!moveActivated)
        {
            moveActivated = true;
            StartCoroutine(delayMove());
        } 
    }

    public void isNotEncounter()
    {
        isEncounterPlayer = false;
    }

    public void deactivateMove()
    {
        isEncounterPlayer = true;
        moveActivated = false;
    }

    private void move()
    {
        isMoving = true;
        
    }
    public void stay()
    {
        
        isMoving = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        
    }

    private void changeDirection()
    {
        if (lastMoveRight)
        {
            lastMoveRight = false;

        }
        else
        {
            lastMoveRight = true;
        }
    }

    private IEnumerator delayMove()
    {
        while(enemyHP.currHealth > 0 && moveActivated)
        {
            changeDirection();
            yield return new WaitForSeconds(stayDuration);
            move();
            yield return new WaitForSeconds(moveDuration);

            stay();
        }
        //yield return new WaitForSeconds(1f);
    }
/*    private IEnumerator oldMove()
    {    
        while(enemyHP.currHealth > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);

            yield return new WaitForSeconds(2f);

            rb.velocity = new Vector2(0, rb.velocity.y);

            yield return new WaitForSeconds(2f);

            rb.velocity = new Vector2(-5, rb.velocity.y);

            yield return new WaitForSeconds(2f);

            rb.velocity = new Vector2(0, rb.velocity.y);

            yield return new WaitForSeconds(2f);
        }

    }*/
    
}
