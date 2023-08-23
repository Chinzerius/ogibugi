using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fungus = 0;
    [SerializeField] private Text fungsText; //fung - с англ гриб
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision) // Передается, когда другой обьект входит в триггер присоединенный к данному обьект
    {
        if (collision.gameObject.CompareTag("Мухомор"))  //в Теге юнити указал мухомор поэтому вызываем тут ее
        {
            collectSound.Play();
            Destroy(collision.gameObject);  // Что бы исчезал элемент
            fungus++;
            fungsText.text = "Fungs: " + fungus;

        }
    }
}
