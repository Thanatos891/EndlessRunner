using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class ObstacleCubeData : ScriptableObject {

    public new string name;
    [Range(-1,30)]
    
    public int length= 0;
   
    [Range(-1, 30)]
    public int width = 0;
    [Range(-1, 30)]
    public int height = 0;
  
    public Material obstacleColor;

    public GameObject spawnCube;
}
