using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定したゲームオブジェクトについていく
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_PlayerTransform = default;

    private Camera m_Camera = default;
    private Vector3 m_DeltaPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        m_DeltaPosition = gameObject.transform.position - m_PlayerTransform.position;
        m_Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = m_PlayerTransform.position + m_DeltaPosition;
    }

    public void SetCameraSize(float size)
    {
        m_Camera.orthographicSize = size;
    }
}
