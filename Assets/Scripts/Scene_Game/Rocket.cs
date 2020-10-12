using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///主人公
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D m_Rigidbody = default;
    [SerializeField]
    ParticleSystem m_ParticleSystem = default;
    [SerializeField]
    private float explosionStrength = 8;
    [SerializeField]
    private float explosionRange = 4;

    [SerializeField]
    private SpriteRenderer m_SpriteRenderer = default;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_Rigidbody.AddExplosionForce(explosionStrength, pos, explosionRange, 0, ForceMode2D.Impulse);
            Vector3 pos3 = new Vector3(pos.x, pos.y, 0);
            m_ParticleSystem.transform.position = pos3;
            m_ParticleSystem.Emit(50);
            
            m_Rigidbody.velocity = Vector2.zero;
            m_Rigidbody.AddExplosionForce(explosionStrength, pos, explosionRange, 0, ForceMode2D.Impulse);
            
        }

        m_Rigidbody.velocity = new Vector2(Mathf.Clamp(m_Rigidbody.velocity.x, -10, 10), m_Rigidbody.velocity.y);
        float phi = -Mathf.Atan2(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y) * 360 / 2 / Mathf.PI;
        //m_SpriteRenderer.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, phi);
        m_SpriteRenderer.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, phi);

    }
}
