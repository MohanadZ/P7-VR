using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] float m_DefaultLength = 5.0f;
    [SerializeField] GameObject m_Dot;
    [SerializeField] VRInputModule m_InputModule;

    private LineRenderer m_LineRenderer = null;
 
    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        float targetLength = m_DefaultLength;

        // Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // Default end
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // Or based on hit
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        // Set position of the dot
        m_Dot.transform.position = endPosition;

        // Set linerenderer
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
