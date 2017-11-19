using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public bool Debugging;
    public int PointsThreshold = 150;

    [Header("Initial Difficulty")]
    public float InitialDistanceBetweenObstacles = 30f;
    public float InitialSpeed = 20;

    [Header("Difficulty Caps")]
    public float DistanceCap = 20f;
    public float SpeedCap = 70f;

    [Header("Difficulty Elements, as Percentages")]
    [Range(0, 25)]
    public int DistanceDecrease = 5;
    [Range(0, 25)]
    public int SpeedIncrease = 5;

    private TileSpawner spawner;
    private ScoreKeeper score;
    private DifficultyLevel currentDifficulty;

    // Use this for initialization
    void Start()
    {
        spawner = GetComponent<TileSpawner>();
        score = GetComponent<ScoreKeeper>();
        ResetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        if (score.Score > PointsThreshold * currentDifficulty.Level)
        {
            IncreaseDifficulty(currentDifficulty.Level + 1);
            SetDifficulty();
        }
    }

    public void ResetDifficulty()
    {

        currentDifficulty = new DifficultyLevel(InitialDistanceBetweenObstacles, InitialSpeed, 1);
        SetDifficulty();


        if (Debugging)
        {
            Debug.Log("DifficultyManager: Resetting difficulty back to " + currentDifficulty.Level + " , Speed = " + currentDifficulty.Speed + " , Distance between blocks = " + currentDifficulty.Distance);
        }

    }

    private void IncreaseDifficulty(int currentLevel)
    {
        float newDistance = Mathf.Clamp(InitialDistanceBetweenObstacles - ((currentLevel - 1) * ((DistanceDecrease / 100f) * InitialDistanceBetweenObstacles)), DistanceCap, InitialDistanceBetweenObstacles);
        float newSpeed = Mathf.Clamp(InitialSpeed + (currentLevel - 1) * (SpeedIncrease * InitialSpeed / 100f), InitialSpeed, SpeedCap);

        currentDifficulty = new DifficultyLevel(newDistance, newSpeed, currentLevel);

        if (Debugging)
        {
            Debug.Log("DifficultyManager: Increasing difficulty to " + currentDifficulty.Level + " , Speed = " + currentDifficulty.Speed + " , Distance between blocks = " + currentDifficulty.Distance);
        }
    }

    private void SetDifficulty()
    {
        spawner.DistanceInterval = currentDifficulty.Distance;
        spawner.TileSpeed = currentDifficulty.Speed;
        spawner.UpdateExistingTiles();
    }

    private struct DifficultyLevel
    {
        public float Distance;
        public float Speed;
        public int Level;

        public DifficultyLevel(float distance, float speed, int level)
        {
            Distance = distance;
            Speed = speed;
            Level = level;
        }
    }
}



