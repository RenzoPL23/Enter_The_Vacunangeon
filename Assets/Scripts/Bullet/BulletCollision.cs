using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            UIController.instance.reduceEnemies();
        }
    }
}
