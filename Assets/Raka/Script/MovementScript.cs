using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan
    private Vector2 direction; // Arah gerakan
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChooseRandomDirection(); // Pilih arah awal secara acak
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Flip gambar berdasarkan arah horizontal
        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ubah arah ketika bertabrakan
        if (collision.collider != null)
        {
            ReflectDirection(collision.contacts[0].normal);
        }
    }

    private void ReflectDirection(Vector2 collisionNormal)
    {
        // Pantulkan arah berdasarkan normal tabrakan
        direction = Vector2.Reflect(direction, collisionNormal).normalized;
    }

    private void ChooseRandomDirection()
    {
        // Pilih arah acak ke kanan, kiri, atas, bawah, atau diagonal
        int randomChoice = Random.Range(0, 8);
        switch (randomChoice)
        {
            case 0: direction = Vector2.up; break;         // Atas
            case 1: direction = Vector2.down; break;       // Bawah
            case 2: direction = Vector2.left; break;       // Kiri
            case 3: direction = Vector2.right; break;      // Kanan
            case 4: direction = new Vector2(1, 1).normalized; break;  // Diagonal kanan atas
            case 5: direction = new Vector2(1, -1).normalized; break; // Diagonal kanan bawah
            case 6: direction = new Vector2(-1, 1).normalized; break; // Diagonal kiri atas
            case 7: direction = new Vector2(-1, -1).normalized; break; // Diagonal kiri bawah
        }
    }
}
