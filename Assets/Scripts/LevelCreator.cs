using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    #region Prefabs' parent
    [SerializeField] GameObject stages;
    [SerializeField] GameObject platforms;
    [SerializeField] GameObject points;
    #endregion
    #region Prefabs
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject stagePrefab;
    [SerializeField] GameObject pointPrefab;//+1 point
    [SerializeField] GameObject redPointPrefab;//-1 point
    #endregion

    private Vector3 whereToAdd = Vector3.zero;//where to add platform,stage checker
    private float whereToAddPoint = 10;//required for locate points

    private float[] pointHorizontalPositions;

    DataManager dataManager;

    void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

        CalculatePointHorizontalPositions();

        //after first 10 level completed player can play same levels but faster (endless)
        //level calculate formula: divide current level to 10 to get game speed, current level mod 10 gives which level is it
        Invoke("Level" + (dataManager.currentLevel%10 + 1),0f);
        Time.timeScale = 1f + (int)(dataManager.currentLevel / 10) * 0.1f;
        print("timescale:" + Time.timeScale);
    }

    private void CalculatePointHorizontalPositions()//point horizontal placement
    {
        pointHorizontalPositions = new float[17];
        for (int i = -8; i <= 8; i++)
        {
            pointHorizontalPositions[i+8] = 0.5f * i;
        }
        //17 state
        //4 3.5 3 2.5 2 1.5 1 0.5 positive
        //4 3.5 3 2.5 2 1.5 1 0.5 negative 
        //0
    }

    #region Levels
    private void Level1()
    {
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(5);

        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        ChangeStage(2);
        AddPointLine(5, pointHorizontalPositions[4], 2, 5);
        AddPointLine(5, pointHorizontalPositions[4], 2, 5);
        AddPointLine(5, pointHorizontalPositions[4], 2, 5);
        ChangeStage(3);
        AddPointLine(5, pointHorizontalPositions[12], 2, 5);
        AddPointLine(5, pointHorizontalPositions[12], 2, 5);
        AddPointLine(5, pointHorizontalPositions[12], 2, 5);
    }
    private void Level2()
    {
        AddPlatform(10);
        AddStage(7);
        AddPlatform(10);
        AddStage(7);
        AddPlatform(10);
        AddStage(7);

        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        ChangeStage(2);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        ChangeStage(3);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
    }
    private void Level3()
    {
        AddPlatform(10);
        AddStage(9);
        AddPlatform(10);
        AddStage(9);
        AddPlatform(10);
        AddStage(9);

        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        ChangeStage(2);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        ChangeStage(3);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
    }
    private void Level4()
    {
        AddPlatform(10);
        AddStage(8);
        AddPlatform(10);
        AddStage(9);
        AddPlatform(10);
        AddStage(10);

        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        ChangeStage(2);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        ChangeStage(3);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
    }
    private void Level5()
    {
        AddPlatform(10);
        AddStage(20);
        AddPlatform(10);
        AddStage(15);
        AddPlatform(10);
        AddStage(10);

        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[6], 2, 5);
        AddPointLine(5, pointHorizontalPositions[4], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[6], 2, 5);
        AddPointLine(5, pointHorizontalPositions[10], 2, 5);
        ChangeStage(2);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[4], 2, 5);
        AddPointLine(5, pointHorizontalPositions[10], 2, 5);
        AddPointLine(5, pointHorizontalPositions[6], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        ChangeStage(3);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(4, pointHorizontalPositions[14], 2, 5);
        AddPointLine(3, pointHorizontalPositions[2], 2, 5);
        AddPointLine(2, pointHorizontalPositions[8], 2, 5);
        AddPointLine(1, pointHorizontalPositions[14], 2, 5);
    }
    private void Level6()
    {
        AddPlatform(10);
        AddStage(25);
        AddPlatform(10);
        AddStage(25);
        AddPlatform(10);
        AddStage(25);

        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);
        AddPointWall(2);

        ChangeStage(2);

        AddPointLine(2, pointHorizontalPositions[2], 2, 2);
        AddPointLine(2, pointHorizontalPositions[3], 2, 2);
        AddPointLine(2, pointHorizontalPositions[4], 2, 2);
        AddPointWall(2);
        AddPointLine(2, pointHorizontalPositions[6], 2, 2);
        AddPointLine(2, pointHorizontalPositions[7], 2, 2);
        AddPointLine(2, pointHorizontalPositions[8], 2, 2);
        AddPointWall(2);
        AddPointLine(2, pointHorizontalPositions[10], 2, 2);
        AddPointLine(2, pointHorizontalPositions[11], 2, 2);
        AddPointLine(2, pointHorizontalPositions[12], 2, 2);
        AddPointWall(2);
        AddPointLine(2, pointHorizontalPositions[14], 2, 2);
        AddPointLine(2, pointHorizontalPositions[15], 2, 2);
        AddPointLine(2, pointHorizontalPositions[16], 2, 2);

        ChangeStage(3);

        AddPointLine(2, pointHorizontalPositions[2], 2, 2);
        AddPointLine(2, pointHorizontalPositions[6], 2, 2);
        AddPointLine(2, pointHorizontalPositions[10], 2, 2);
        AddPointLine(2, pointHorizontalPositions[14], 2, 2);
        AddPointWall(2);
        AddPointLine(2, pointHorizontalPositions[3], 2, 2);
        AddPointLine(2, pointHorizontalPositions[7], 2, 2);
        AddPointLine(2, pointHorizontalPositions[11], 2, 2);
        AddPointLine(2, pointHorizontalPositions[15], 2, 2);
        AddPointWall(2);
        AddPointLine(2, pointHorizontalPositions[4], 2, 2);
        AddPointLine(2, pointHorizontalPositions[8], 2, 2);
        AddPointLine(2, pointHorizontalPositions[12], 2, 2);
        AddPointLine(2, pointHorizontalPositions[16], 2, 2);
        AddPointWall(2);
    }
    private void Level7()
    {
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(6);
        AddPlatform(10);
        AddStage(7);

        AddPointLine(1, pointHorizontalPositions[2], 2, 10);
        AddPointWall(2);
        ChangeStage(2);
        AddPointLine(1, pointHorizontalPositions[15], 2, 5);
        AddPointWall(2);
        ChangeStage(3);
        AddPointLine(2, pointHorizontalPositions[8], 2, 5);
        AddPointWall(2);
    }

    private void Level8()
    {
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(5);

        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddRedPointLine(5, pointHorizontalPositions[14], 2, 5);
        ChangeStage(2);
        AddRedPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        ChangeStage(3);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddRedPointLine(5, pointHorizontalPositions[8], 2, 5);
    }
    private void Level9()
    {
        AddPlatform(10);
        AddStage(6);
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(5);

        AddPointLine(5, pointHorizontalPositions[4], 2, 5);
        AddRedPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[12], 2, 5);
        ChangeStage(2);
        AddRedPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddPointLine(5, pointHorizontalPositions[2], 2, 5);
        AddRedPointLine(5, pointHorizontalPositions[8], 2, 5);
        ChangeStage(3);
        AddRedPointLine(5, pointHorizontalPositions[8], 2, 5);
        AddRedPointLine(5, pointHorizontalPositions[14], 2, 5);
        AddPointLine(5, pointHorizontalPositions[8], 2, 5);
    }
    private void Level10()
    {
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(5);
        AddPlatform(10);
        AddStage(10);

        AddPointWall(10);
        AddRedPointLeftWall(10);
        AddRedPointLeftWall(10);
        AddPointWall(10);
        AddRedPointLeftWall(10);

        ChangeStage(2);

        AddPointWall(10);
        AddRedPointRightWall(10);
        AddRedPointRightWall(10);
        AddPointWall(10);
        AddRedPointRightWall(10);
        ChangeStage(3);

        AddPointWall(10);
        AddRedPointLeftWall(10);
        AddRedPointRightWall(10);
        AddPointWall(10);
        AddRedPointLeftWall(10);
        AddPointWall(10);
        AddRedPointRightWall(10);
    }
    #endregion
    #region Level Creation Methods
    private void AddPlatform()
    {
        Instantiate(platformPrefab,whereToAdd,Quaternion.identity,platforms.transform);
        whereToAdd += Vector3.forward * 10;
    }
    private void AddPlatform(int numberToCreate)
    {
        for (int i = 0; i < numberToCreate; i++)
        {
            Instantiate(platformPrefab, whereToAdd, Quaternion.identity, platforms.transform);
            whereToAdd += Vector3.forward * 10;
        }
    }
    private void AddStage(int requiredBallForPassStage)
    {
        GameObject stage= Instantiate(stagePrefab, whereToAdd, Quaternion.identity, stages.transform);
        stage.GetComponent<StageCheck>().RequiredBall = requiredBallForPassStage;
        
        whereToAdd += Vector3.forward * 10;
    }

    private void AddPointLine(int createCount, float horizontalPosition, float spaceBetweenPoints,float spaceAfterCreatePoints)
    {
        for (int i = 0; i < createCount; i++)
        {
            Instantiate(pointPrefab, new Vector3(horizontalPosition,0.25f,whereToAddPoint), Quaternion.identity, points.transform);
            whereToAddPoint += spaceBetweenPoints;
        }
        whereToAddPoint += spaceAfterCreatePoints;
    }
    private void AddRedPointLine(int createCount, float horizontalPosition, float spaceBetweenPoints, float spaceAfterCreatePoints)
    {
        for (int i = 0; i < createCount; i++)
        {
            Instantiate(redPointPrefab, new Vector3(horizontalPosition, 0.25f, whereToAddPoint), Quaternion.identity, points.transform);
            whereToAddPoint += spaceBetweenPoints;
        }
        whereToAddPoint += spaceAfterCreatePoints;
    }
    private void AddPointWall(float spaceAfterCreatePoints)
    {
        for (int i = 0; i < pointHorizontalPositions.Length; i++)
        {
            Instantiate(pointPrefab, new Vector3(pointHorizontalPositions[i], 0.25f, whereToAddPoint), Quaternion.identity, points.transform);
        }
        whereToAddPoint += spaceAfterCreatePoints;
    }
    private void AddRedPointLeftWall(float spaceAfterCreatePoints)
    {
        for (int i = 0; i <= pointHorizontalPositions.Length/2; i++)
        {
            Instantiate(redPointPrefab, new Vector3(pointHorizontalPositions[i], 0.25f, whereToAddPoint), Quaternion.identity, points.transform);
        }
        whereToAddPoint += spaceAfterCreatePoints;
    }

    private void AddRedPointRightWall(float spaceAfterCreatePoints)
    {
        for (int i = pointHorizontalPositions.Length-1; i >= pointHorizontalPositions.Length / 2; i--)
        {
            Instantiate(redPointPrefab, new Vector3(pointHorizontalPositions[i], 0.25f, whereToAddPoint), Quaternion.identity, points.transform);
        }
        whereToAddPoint += spaceAfterCreatePoints;
    }
    private void ChangeStage(int stage)
    {
        stage--;
        whereToAddPoint = 10 + (110 * stage);
    }
    #endregion
}
