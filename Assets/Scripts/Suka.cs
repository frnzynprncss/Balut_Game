using UnityEngine;

public class Suka : Collectable
{
    public float time_addition = 5f;

    public override void ApplyEffect()
    {
        EventManager.Instance.add_time.Invoke(time_addition);
        balut_attainer.IncreaseSuka();
    }
}