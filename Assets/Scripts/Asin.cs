using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asin : Collectable
{
    public int score_addition = 1;

    public override void ApplyEffect()
    {
        EventManager.Instance.add_score.Invoke(score_addition);
        balut_attainer.IncreaseAsin();
    }
}
