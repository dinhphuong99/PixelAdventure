using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    private Image[] healthImages;
    private int currentHealth;
    private PlayerLife playerLife;
    [SerializeField] private Sprite heathUI; // Ảnh cho trạng thái máu còn
    [SerializeField] private Sprite heathUIDisable; // Ảnh cho trạng thái máu hết

    // Start is called before the first frame update
    void Start()
    {
        // Lấy tất cả các đối tượng Image trong GameObject
        // và lưu trữ chúng trong mảng healthImages
        healthImages = GetComponentsInChildren<Image>();

        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
    }

    void Update()
    {
        currentHealth = playerLife.GetCurrentHealth();
        ImageRender(currentHealth);
    }

    private void ImageRender(int currentHealth)
    {
        if(currentHealth == 0)
        {
            foreach (var healthImage in healthImages)
            {
                healthImage.enabled = false;
            }
        }else if (currentHealth > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                if(i < currentHealth)
                {
                    healthImages[i].enabled = true;
                    healthImages[i].sprite = heathUI;
                }
                else
                {
                    healthImages[i].enabled = true;
                    healthImages[i].sprite = heathUIDisable;
                }
            }
        }
    }
}
