using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.velocity = new Vector3(0f, 10f, 0f);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -50f) // left off-screen
            Destroy(gameObject);
    }
}
