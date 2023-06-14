using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class ToolsManager : MonoBehaviour
{
    [SerializeField] private List<P3dPaintSphere> Tools = new List<P3dPaintSphere>();
    [SerializeField] private float radius = 0.05f;

    void Start()
    {
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<P3dPaintSphere>() != null)
            {
                Tools.Add(child.GetComponent<P3dPaintSphere>());
            }
        }
    }

    void Update()
    {
        HandleBrushRadius();
    }

    private void HandleBrushRadius()
    {
        radius += Input.GetAxis("Mouse ScrollWheel");
        radius = Mathf.Clamp(radius, 0.01f, 0.1f);

        foreach (P3dPaintSphere tool in Tools)
        {
            tool.Radius = radius;
        }
    }
}
