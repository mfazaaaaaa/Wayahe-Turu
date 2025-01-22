using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Tooltip("Waktu dalam detik sebelum objek dihancurkan")]
    public float destroyTime = 5f; // Nilai default 5 detik

    void Start()
    {
        // Hancurkan game object ini setelah waktu yang ditentukan
        Destroy(gameObject, destroyTime);
    }
}