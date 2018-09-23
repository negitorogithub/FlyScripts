using UnityEngine;
using System.Collections;

public class LevaragesHolderByDifficuly : MonoBehaviour
{
    public Levarages currentLevarages { private set; get; }

    [SerializeField]
    Levarages easyLevarages;
    [SerializeField]
    Levarages normalLevarages;
    [SerializeField]
    Levarages hardLevarages;

    // Use this for initialization
    void Awake()
    {
        switch (DifficultyHolder.Difficulty)
        {
            case Difficulty.Easy:
                currentLevarages = easyLevarages;
                break;
            case Difficulty.Normal:
                currentLevarages = normalLevarages;
                break;
            case Difficulty.Hard:
                currentLevarages = hardLevarages;
                break;
            case Difficulty.Lunatic:
                currentLevarages = hardLevarages;
                break;
            default:
                currentLevarages = normalLevarages;
                break;
        }
    }
}
