using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd;

    [SerializeField] private AudioSource sfx;

    public float speed;

    public int x = 0;
    public int y;
    public Vector2 juping;
    public bool jumpAvail;
    public bool startprinting;

    public Animator anim;
    void Update()
    {
        
        Jump();     
        
        CheckMove();

        while(x<y)
        {
            Debug.Log("Print  ");
            x = x +1;

        }
        
    }
    
    
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && rgbd.velocity.y == 0  )
        {
            rgbd.AddForce(juping, ForceMode2D.Impulse);
            sfx.Play(); 
            jumpAvail = false;
        }

        //rgbd.AddForce(new Vector2(), ForceMode2D.Impulse);
        
        
    }
    

    private void CheckMove()
    {

        float dir = 0f;
        if(Input.GetKey(KeyCode.A))
        {
            dir = -1f;
            anim.SetBool("IsRunning", true);
        }
        if(Input.GetKey(KeyCode.D))
        {
            dir = 1f;
            anim.SetBool("IsRunning", true);
        }
        
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            dir = 0f;
            anim.SetBool("IsRunning", false);
        }
        
        Move(dir * Time.deltaTime * speed);

    }

    private void Move(float dir)
    {
        rgbd.transform.Translate(new Vector3(dir, rgbd.velocity.y,0));
        //Vector3(x,y,z)
    } 

    void OnCollisionEnter2D(Collision2D col) {


        if(col.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
        }

        if(col.gameObject.tag == "cat")
        {
            jumpAvail = true;
        }
    }
    
}
