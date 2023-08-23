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

    [SerializeField] private AudioSource jumpSound; // ���������� ��� ������ ��� ������
    // Start is called before the first frame update
    private void Start()
    {
        rbb = GetComponent<Rigidbody2D>();   // ������� ����������, ������ ��� �� ����� � ���������
        anim = GetComponent<Animator>();
        tudasuda = GetComponent<SpriteRenderer>(); //���� ���� ��� ��� �� �������� ���� ���� �������� ����� �� ���������
        zona = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        dvizghX = Input.GetAxisRaw("Horizontal");    //������ � Raw ��� �� ���������� ���� ��������
        rbb.velocity = new Vector2(dvizghX * moveSpeed, rbb.velocity.y); // ���� ���� ������

        if (Input.GetButtonDown("Jump") && IsZona())  // ����� � ������ �����
        {
            jumpSound.Play();  // � ��� � �������� � ������ ����
            rbb.velocity = new Vector2(rbb.velocity.x, jumpForce); // ������
        }

        UpdateAnimationUpdate();
        //�������
        if (transform.position.y < -6f)
            RestartLevel();
    }

    private void UpdateAnimationUpdate()
    {
        if (dvizghX > 0f)      //���� ������� � ���������� ������ 0 ������ �� ����� ����������� ���� ������������ ������ ��������
        {
            anim.SetBool("running", true);               //���������� ��� ����� �� ���������
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

    private bool IsZona() // ��� �� �� ������ �� ������� �������� ����� 
    {
        return Physics2D.BoxCast(zona.bounds.center, zona.bounds.size, 0f, Vector2.down, .1f, jumpTravka);
    }
    //new
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
