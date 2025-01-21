using UnityEngine;

public class ClickMekanik : MonoBehaviour
{
    public int clickThreshold = 3; // Jumlah klik yang dibutuhkan untuk menghilangkan objek
    private int currentClickCount = 0; // Hitung jumlah klik yang sudah terjadi
    public GameObject exploxion; // explotion effect
    public GameObject sfxDie;

    private RandomSpawn randomSpawn; // Reference ke RandomSpawn

    void Start()
    {
        // Cari RandomSpawn di scene
        randomSpawn = FindObjectOfType<RandomSpawn>();
    }

    void OnMouseDown()
    {
        currentClickCount++; // Menambah jumlah klik

        if (currentClickCount >= clickThreshold)
        {
            // Laporkan ke RandomSpawn bahwa objek ini dihancurkan
            if (randomSpawn != null)
            {
                randomSpawn.RegisterEnemyDestroyed(gameObject);
            }

            GameObject spawnedObject = Instantiate(exploxion, transform.position, Quaternion.identity);
            GameObject spawnedaudio = Instantiate(sfxDie, transform.position, Quaternion.identity);
            // Hancurkan objek
            Destroy(gameObject);
        }
    }
}
