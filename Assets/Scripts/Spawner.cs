using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] groundPrefabs; // rocks, jeepney, tricycle, trampolines
    public float game_timer = 60f;
    public float spawnInterval = 2f;

    private float timer = 0f;
    private float groundTopY;

    void Start()
    {
        // find the ground in the scene
        GameObject ground = GameObject.FindWithTag("ground");
        if (ground != null)
        {
            Collider2D col = ground.GetComponent<Collider2D>();
            if (col != null)
                groundTopY = ground.transform.position.y + col.bounds.extents.y;
            else
                groundTopY = ground.transform.position.y; // fallback
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnOnGround();
        }
    }

    void SpawnOnGround()
    {
        if (groundPrefabs.Length == 0) return;

        GameObject prefab = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        SpriteRenderer sr = prefab.GetComponent<SpriteRenderer>();

        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
