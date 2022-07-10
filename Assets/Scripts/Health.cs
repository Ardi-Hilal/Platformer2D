using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float staringHealth;
    public float currHealth {get; private set;}
    private Animator anim;
    [SerializeField] private  GameObject LoseUI;

    // Start is called before the first frame update
    void Awake()
    {
        currHealth = staringHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

       if(currHealth == 0){
           LoseUI.SetActive(true);
       }
    }

    public void TakeDamage (float _damage)
    {


        currHealth = Mathf.Clamp(currHealth - _damage,0, staringHealth);
       
        if(currHealth > 0)
        {
            anim.SetTrigger("hurt");
            //currHealth -= _damage;
        } 

        else
        {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false; 
            //darah abis
            
        }
    }

    public void AddHealth(float _value)
    {
        currHealth = Mathf.Clamp(currHealth + _value,0, staringHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Fireball")
        {
            TakeDamage(1);
        }
    }
    
}
