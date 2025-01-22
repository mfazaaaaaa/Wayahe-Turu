using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;

    // Start is called before the first frame update
    void Start()
    {
        // Menambahkan prefab ke dalam list
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);

        // Mulai coroutine spawn dengan waktu acak
        StartCoroutine(SpawnSoundsWithRandomInterval());
    }

    // Coroutine untuk spawn sound dengan interval acak
    IEnumerator SpawnSoundsWithRandomInterval()
    {
        while (true) // Loop terus-menerus
        {
            // Pilih waktu spawn acak antara 1 detik hingga 5 detik
            float randomTime = UnityEngine.Random.Range(1f, 10f);

            // Tunggu selama waktu acak
            yield return new WaitForSeconds(randomTime);

            // Spawn sound
            spawnSounds();
        }
    }

    // Fungsi untuk spawn prefab
    public void spawnSounds()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count); // Pilih prefab acak
        GameObject spawnedPrefab = Instantiate(prefabList[prefabIndex], transform.position, Quaternion.identity); // Spawn prefab di posisi objek ini
        StartCoroutine(DestroyAfterDelay(spawnedPrefab, 15f)); // Mulai coroutine untuk menghancurkan prefab
    }

    // Coroutine untuk menghancurkan prefab setelah delay tertentu
    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}