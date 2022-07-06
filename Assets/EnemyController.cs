using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd;
    public float dir;
    public float speed;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col) {


        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }


    }

    void OnCollisionEnter2D(Collision2D other) {
        dir = dir * -1;
    }

    void Update() {
        rgbd.transform.Translate(dir * speed * Time.deltaTime, rgbd.velocity.y,0);
    }
}
        