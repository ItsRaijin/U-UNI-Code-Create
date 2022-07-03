using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame


    [SerializeField] private Rigidbody2D rgbd;

    [SerializeField] private AudioSource sfx;

    public float speed;
    void Update()
    {
        
        Jump();
        
        CheckMove();
    }
    
    
    private void Jump()
    {

        //rgbd.AddForce(new Vector2(), ForceMode2D.Impulse);
        
        //sfx.Play();
        
    }
    

    private void CheckMove()
    {

        float dir = 0f;
        if(Input.GetKey(KeyCode.A))
        {
            dir = -1f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            dir = 1f;
        }
        
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            dir = 0f;
        }
        
        Move(dir * Time.deltaTime * speed);

    }

    private void Move(float dir)
    {
        rgbd.transform.Translate(new Vector3(dir, rgbd.velocity.y,0));
    }
}
