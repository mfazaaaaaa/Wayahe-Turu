using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float timer = 3f; // Waktu dalam detik sebelum pindah scene
    public string nextSceneName = "Ingame"; // Nama scene yang akan dipindahkan

    private float timeRemaining;

    void Start()
    {
        timeRemaining = timer; // Set waktu timer
    }

    void Update()
    {
        // Mengurangi waktu setiap frame
        timeRemaining -= Time.deltaTime;

        // Cek jika waktu timer sudah habis
        if (timeRemaining <= 0)
        {
            // Pindah ke scene yang ditentukan
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
