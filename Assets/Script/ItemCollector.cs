using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    //[SerializeField] private Text cherriesText;
    private TextMeshProUGUI cherriesText;
    private int cherries = 0;

    [SerializeField] private AudioSource collectionSoundEffect;
    void Start()
    {
        // Lấy đối tượng TextMeshProUGUI từ hình ảnh đính kèm script này
        cherriesText = FindObjectOfType<TextMeshProUGUI>();

        // Đặt nội dung ban đầu của TextMeshProUGUI
        cherriesText.text = "x 0";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "x " + cherries;
        }
    }
}
