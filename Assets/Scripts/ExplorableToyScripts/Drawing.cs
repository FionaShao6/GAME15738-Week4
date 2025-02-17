using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public GameObject pointPrefab;        // 点预制体
    public float minDistance = 0.1f;      // 点间距阈值
    public bool canDraw = false;

    private GameObject currentLineParent; // 当前线条的父物体
    private bool isDrawing = false;       // 绘制状态
    private Vector3 lastPointPosition;    // 上一个点位置

    void Update()
    {
        if(canDraw)
        {
            HandleDrawingInput();
        }
        
    }

    void HandleDrawingInput()
    {
        // 鼠标按下开始绘制
        if (Input.GetMouseButtonDown(0))
        {
            StartNewLine();
        }

        // 鼠标按住时持续检测
        if (Input.GetMouseButton(0))
        {
            if (isDrawing)
            {
                UpdateLineDrawing();
            }
        }

        // 鼠标释放结束绘制
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }

    void StartNewLine()
    {
        isDrawing = true;
        // 创建新父物体存放当前线条的点
        currentLineParent = new GameObject("Line");
        // 生成初始点
        Vector3 mousePos = GetMouseWorldPosition();
        CreatePoint(mousePos);
        lastPointPosition = mousePos;
    }

    void UpdateLineDrawing()
    {
        Vector3 currentMousePos = GetMouseWorldPosition();
        // 当移动距离超过阈值时生成新点
        if (Vector3.Distance(currentMousePos, lastPointPosition) > minDistance)
        {
            CreatePoint(currentMousePos);
            lastPointPosition = currentMousePos;
        }
    }

    void CreatePoint(Vector3 position)
    {
        GameObject newPoint = Instantiate(pointPrefab, position, Quaternion.identity);
        newPoint.transform.SetParent(currentLineParent.transform);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        // 正交相机处理（2D场景）
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);


    }
   
    
}