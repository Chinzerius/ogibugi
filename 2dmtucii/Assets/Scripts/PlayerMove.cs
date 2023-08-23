using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rbb;
    private Animator anim;
    private BoxCollider2D zona;
    private float dvizghX = 0f;
    private SpriteRenderer tudasuda;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private LayerMask jumpTravka;

    [SerializeField] private AudioSource jumpSound; // переменная для музыки при прыжке
    // Start is called before the first frame update
    private void Start()
    {
        rbb = GetComponent<Rigidbody2D>();   // создали переменную, сделал так тк легче и правильно
        anim = GetComponent<Animator>();
        tudasuda = GetComponent<SpriteRenderer>(); //туда сюда это что бы анимация туда сюда менялась когда он двигается
        zona = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        dvizghX = Input.GetAxisRaw("Horizontal");    //сделал с Raw что бы движениене было плывучей
        rbb.velocity = new Vector2(dvizghX * moveSpeed, rbb.velocity.y); // туда сюда делает

        if (Input.GetButtonDown("Jump") && IsZona())  // взяли с Инпута Юнити
        {
            jumpSound.Play();  // а это я прописал в прыжок звук
            rbb.velocity = new Vector2(rbb.velocity.x, jumpForce); // прыжки
        }

        UpdateAnimationUpdate();
        //новизна
        if (transform.position.y < -6f)
            RestartLevel();
    }

    private void UpdateAnimationUpdate()
    {
        if (dvizghX > 0f)      //если условие в переменной больше 0 значит он бегит следственно надо использовать другую анимацию
        {
            anim.SetBool("running", true);               //используем наш булин из Аниматора
            tudasuda.flipX = false;
        }
        else if (dvizghX < 0f)
        {
            anim.SetBool("running", true);
            tudasuda.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private bool IsZona() // что бы не убегал из деревни скрытого листа 
    {
        return Physics2D.BoxCast(zona.bounds.center, zona.bounds.size, 0f, Vector2.down, .1f, jumpTravka);
    }
    //new
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
