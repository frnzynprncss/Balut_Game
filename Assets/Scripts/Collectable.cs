using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Balut_Attain balut_attainer;
    public AudioClip audio_sfx;

    private void Start()
    {
        balut_attainer = GameObject.FindFirstObjectByType<Balut_Attain>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound(audio_sfx, transform, 1f);

            ApplyEffect();
            Destroy(gameObject);
        }
    }

    public virtual void ApplyEffect()
    {

    }
}
