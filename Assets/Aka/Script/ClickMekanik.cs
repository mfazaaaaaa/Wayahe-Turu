using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMekanik: MonoBehaviour
{
    public int clickThreshold = 3; // Jumlah klik yang dibutuhkan untuk menghilangkan objek
    private int currentClickCount = 0; // Hitung jumlah klik yang sudah terjadi

    void OnMouseDown()
    {
        currentClickCount++; // Menambah jumlah klik

        if (currentClickCount >= clickThreshold)
        {
            // Menghilangkan objek setelah mencapai jumlah klik yang diinginkan
            Destroy(gameObject);
        }
    }
}

