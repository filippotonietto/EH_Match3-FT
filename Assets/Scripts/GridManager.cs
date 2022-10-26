using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridHeight, gridWidth;

    public GameObject cellObject;
    public float scaleMultiplier;

    public List<GameObject> cells = new List<GameObject>();

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
        for(int i = 0; i < gridHeight; i++)
        {
            for(int j = 0; j < gridWidth; j++)
            {
                GameObject newCell = Instantiate(cellObject, GameObject.Find("Cells").transform);
                newCell.transform.localPosition = new Vector3(i * scaleMultiplier, j * -scaleMultiplier, 0);
                cells.Add(newCell);
            }
        }

        AdjustCamera();
    }

    public void AdjustCamera()
    {
        Vector3 firstCellPos = cells[0].transform.position;
        int n = cells.Count;
        Vector3 lastCellPos = cells[n - 1].transform.position;
        float zoom = Mathf.Max(gridWidth, gridHeight);

        Vector3 midPoint = new Vector3((firstCellPos.x + (lastCellPos.x - firstCellPos.x) / 2), (firstCellPos.y + (lastCellPos.y - firstCellPos.y) / 2), -1f);
        Camera.main.transform.position = midPoint;
        Camera.main.orthographicSize = zoom;
    }

    public void PlaceCell()
    {

    }
}
