using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [System.Serializable] public class AddTime : UnityEvent<float> { };
    [System.Serializable] public class AddScore : UnityEvent<int> { };
    public AddTime add_time;
    public AddScore add_score;

    public UnityEvent game_over;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
