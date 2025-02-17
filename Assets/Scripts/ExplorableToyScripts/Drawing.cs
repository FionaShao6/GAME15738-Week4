using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public GameObject pointPrefab;        // ��Ԥ����
    public float minDistance = 0.1f;      // ������ֵ
    public bool canDraw = false;

    private GameObject currentLineParent; // ��ǰ�����ĸ�����
    private bool isDrawing = false;       // ����״̬
    private Vector3 lastPointPosition;    // ��һ����λ��

    void Update()
    {
        if(canDraw)
        {
            HandleDrawingInput();
        }
        
    }

    void HandleDrawingInput()
    {
        // ��갴�¿�ʼ����
        if (Input.GetMouseButtonDown(0))
        {
            StartNewLine();
        }

        // ��갴סʱ�������
        if (Input.GetMouseButton(0))
        {
            if (isDrawing)
            {
                UpdateLineDrawing();
            }
        }

        // ����ͷŽ�������
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }

    void StartNewLine()
    {
        isDrawing = true;
        // �����¸������ŵ�ǰ�����ĵ�
        currentLineParent = new GameObject("Line");
        // ���ɳ�ʼ��
        Vector3 mousePos = GetMouseWorldPosition();
        CreatePoint(mousePos);
        lastPointPosition = mousePos;
    }

    void UpdateLineDrawing()
    {
        Vector3 currentMousePos = GetMouseWorldPosition();
        // ���ƶ����볬����ֵʱ�����µ�
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
        // �����������2D������
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);


    }
   
    
}