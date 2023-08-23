using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fungus = 0;
    [SerializeField] private Text fungsText; //fung - � ���� ����
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision) // ����������, ����� ������ ������ ������ � ������� �������������� � ������� ������
    {
        if (collision.gameObject.CompareTag("�������"))  //� ���� ����� ������ ������� ������� �������� ��� ��
        {
            collectSound.Play();
            Destroy(collision.gameObject);  // ��� �� ������� �������
            fungus++;
            fungsText.text = "Fungs: " + fungus;

        }
    }
}
