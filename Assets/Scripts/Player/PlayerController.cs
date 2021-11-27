using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float movementSpeed = 4f;
    private float JumpForce = 8f;
    private Rigidbody2D _rigidbody2D;
    private Animator _anim;
    private bool direction;
    [SerializeField]
    private GameObject Vaccine;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardActions();
    }

    private void KeyboardActions()
    {
        var movement = Input.GetAxis("Horizontal");

        if (movement > 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            direction = true;
            _anim.Play("Walker");
        }
        else if (movement < 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            direction = false;
            _anim.Play("Walker");
        }
        else
        {
            _anim.Play("Idle");
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _anim.Play("Jumper");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shootVaccine(direction);
        }

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
    }

    public void shootVaccine(bool direction)
    {
        GameObject new_vaccine;
        var position = new Vector2(this.transform.position.x, this.transform.position.y);
        if (direction)
        {
            position.x = this.transform.position.x + 0.5f;
            new_vaccine = Instantiate(Vaccine, position, Quaternion.identity);
            Rigidbody2D bodyBullet = new_vaccine.AddComponent<Rigidbody2D>();
            bodyBullet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            bodyBullet.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
        }
        else
        {
            position.x = this.transform.position.x - 0.5f;
            new_vaccine = Instantiate(Vaccine, position, Quaternion.identity);
            Rigidbody2D bodyBullet = new_vaccine.AddComponent<Rigidbody2D>();
            bodyBullet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            bodyBullet.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

    }

}
