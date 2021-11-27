using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        int targetLayer = 1 << 6;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position,
                                (transform.localScale.x * Vector2.right) + (Vector2.down * 1.5f),
                                1, targetLayer);
        Debug.DrawRay(transform.position, (transform.localScale.x * Vector2.right) + (Vector2.down * 1.5f), Color.red);
        ChangeDirectionOnNoGround(hit2D);
        MoveCharacter();
    }

    private void ChangeDirectionOnNoGround(RaycastHit2D hit2D)
    {
        if (!hit2D)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1.0f;
            transform.localScale = scale;
        }
    }

    private void MoveCharacter()
    {
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.Lerp(currentPosition, currentPosition + (transform.localScale.x * Vector3.right), Time.deltaTime);
    }
}
