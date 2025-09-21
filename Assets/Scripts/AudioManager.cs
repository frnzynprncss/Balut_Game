using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audio_obj;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip audio_clip, Transform spawn_transform, float volume = 1f)
    {
        AudioSource audio_source = Instantiate(audio_obj, spawn_transform.position, Quaternion.identity);
        audio_source.clip = audio_clip;
        audio_source.volume = volume;
        audio_source.Play();

        float clip_lenght = audio_source.clip.length;
        Destroy(audio_source.gameObject, clip_lenght);
        DontDestroyOnLoad(audio_source.gameObject);
    }

    public void PlayRandomSound(AudioClip[] audio_array, Transform spawn_transform, float volume)
    {
        if (audio_array.Length <= 0)
        {
            return;
        }

        int rand_index = Random.Range(0, audio_array.Length);
        PlaySound(audio_array[rand_index], spawn_transform, volume);
    }
}
