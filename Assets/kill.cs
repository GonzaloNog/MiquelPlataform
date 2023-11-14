using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    public EnemyMovement target;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SuperGirl")
        {
            target.isLive = false;
            target.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            target.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
