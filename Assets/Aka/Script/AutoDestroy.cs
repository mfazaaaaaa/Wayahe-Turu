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
        var game = gameObject;
        if (game != null)
        //Halo dek sini sama mas
        Destroy(gameObject, destroyTime);


        if (game == null)
        {
            Debug.Log("game is null");
        }
        else
        {
            Debug.Log("game is present");
        }
    }

    public void DestroyMagelang()
    {
        Destroy(gameObject, destroyTime);
    }
}