using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerators : MonoBehaviour
{
    [SerializeField] private Transform StartLevel;
    [SerializeField] public List<Transform> Levels;
    public LanderNumbers landerNumbers;
    private const float DistanceBetweenPlayerAndLastPoint = 200f;
    private Vector3 LastPosition;
    public Transform Thruster;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Transform lastLevel;
        landerNumbers.CreateNumbers(StartLevel);
        LastPosition = StartLevel.Find("EndingPoint").position;
        int StartSpawnNumbers = 4;
            for(int i=0;i<StartSpawnNumbers;i++)
        {
            SpawnLevel();
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(Thruster.position, LastPosition);
        if(distance<DistanceBetweenPlayerAndLastPoint)
        {
            SpawnLevel();
        }
    }
    void SpawnLevel()
    {
        Transform NewRandomPlatform = Levels[Random.Range(0, Levels.Count)];
        Transform LastLevel = SpawnNewPlatform(LastPosition,NewRandomPlatform);
        LastPosition = LastLevel.Find("EndingPoint").position;
    }
    public Transform SpawnNewPlatform(Vector3 StartingPoint,Transform NewPlatform)
    {
        Transform NewLevel = Instantiate(NewPlatform, StartingPoint, Quaternion.identity);
        landerNumbers.CreateNumbers(NewLevel);
        return NewLevel;
    }
    
}
