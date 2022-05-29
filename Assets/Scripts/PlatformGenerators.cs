using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerators : MonoBehaviour
{
    [SerializeField] private Transform StartLevel;
    [SerializeField] private Transform StartLevel_2;
    public LanderNumbers landerNumbers;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Transform lastLevel;
        landerNumbers.CreateNumbers(StartLevel);
        lastLevel = SpawnNewPlatform(StartLevel.Find("EndingPoint").position);
        lastLevel = SpawnNewPlatform(lastLevel.Find("EndingPoint").position);
        lastLevel = SpawnNewPlatform(lastLevel.Find("EndingPoint").position);
        lastLevel = SpawnNewPlatform(lastLevel.Find("EndingPoint").position);
        
    }
    public Transform SpawnNewPlatform(Vector3 StartingPoint)
    {
        Transform NewLevel = Instantiate(StartLevel_2, StartingPoint, Quaternion.identity);
        landerNumbers.CreateNumbers(NewLevel);
        return NewLevel;
    }
    
}
