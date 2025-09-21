using UnityEngine;

public class Balut_Attain : MonoBehaviour
{
    [SerializeField] private int asin_max;
    [SerializeField] private int suka_max;

    private int asin_amt = 0;
    private int suka_amt = 0;

    public float GetBalut()
    {
        float asin = (float)asin_amt / asin_max;
        float suka = (float)suka_amt / asin_max;
        float percentage = asin + suka * 100;

        Debug.Log($"Asin {asin} : Suka {suka}");
        Debug.Log($"Percentage {percentage}");

        return percentage;
    }

    public void IncreaseAsin()
    {
        asin_amt++;
        Debug.Log(asin_amt);
    }

    public void IncreaseSuka()
    {
        suka_amt++;
        Debug.Log(suka_amt);
    }
}
