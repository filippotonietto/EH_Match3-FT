using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    #region Singleton
    public static GridCreator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public int gridWidth, gridHeight;

    public GameObject cellObject;
    public GameObject row;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        int counter = 0;
        for(int i = 0; i < gridHeight; i++)
        {
            Row newRow = Instantiate(row, GameObject.Find("Grid").transform).GetComponent<Row>();
            newRow.gameObject.name = $"Row_{i}";
            for(int j = 0; j < gridWidth; j++)
            {
                GameObject newCell = Instantiate(cellObject, GameObject.Find($"Row_{i}").transform);
                newCell.transform.localPosition = new Vector3(j * 1, i * -1, 0);
                newCell.name = $"Cell_{counter}";
                newRow.tiles.Add(newCell.GetComponent<Tile>());
                counter++;
            }
        }

        AdjustCamera();
    }

    public void AdjustCamera()
    {
        Vector3 firstCellPos = GameObject.Find("Row_0").GetComponent<Row>().tiles[0].transform.position;
        Vector3 lastCellPos = GameObject.Find($"Row_{gridHeight - 1}").GetComponent<Row>().tiles[gridWidth - 1].transform.position;
        float zoom = Mathf.Max(gridWidth, gridHeight);

        Vector3 midPoint = new Vector3((firstCellPos.x + (lastCellPos.x - firstCellPos.x) / 2), (firstCellPos.y + (lastCellPos.y - firstCellPos.y) / 2), -1f);
        Camera.main.transform.position = midPoint;
        Camera.main.orthographicSize = zoom;
    }
}
