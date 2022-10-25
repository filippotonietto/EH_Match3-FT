using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridHeight, gridWidth;

    public GameObject cellObject;
    public float scaleMultiplier;

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
        AdjustCamera();

        for(int i = 0; i < gridHeight; i++)
        {
            for(int j = 0; j < gridWidth; j++)
            {
                GameObject newCell = Instantiate(cellObject, GameObject.Find("Cells").transform);
                newCell.transform.localPosition = new Vector3(i * scaleMultiplier, j * -scaleMultiplier, 0);
            }
        }
    }

    public void AdjustCamera()
    {
    }

    public void PlaceCell()
    {

    }
}
