using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    // halo saya jawatengah
    [Tooltip("Waktu dalam detik sebelum objek dihancurkan")]
    public float destroyTime = 5f; // Nilai default 5 detik

    void Start()
    {
        // Hancurkan game object ini setelah waktu yang ditentukan
        Destroy(gameObject, destroyTime);
    }

    public void DestroyDelay()
    {
        Destroy(gameObject, destroyTime);
    }

    public void DestroyMagelang()
    {
        Destroy(gameObject, destroyTime);
    }
}