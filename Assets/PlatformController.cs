using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd;
    public float dir;
    public float timeD;
    public float timer;
    public float speed;

    void Start() {
        timer = timeD;
    }

    void Update() {
        rgbd.transform.Translate(  rgbd.velocity.x, dir * speed * Time.deltaTime,0);
        timer -= Time.deltaTime; // timer = timer - time.deltaTImer;
        if(timer < 0){
            dir *= -1; // dir = dir * -1;
            timer = timeD;
        }

    }
}
