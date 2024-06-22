using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private AIAgent agent;
    [SerializeField] private float drag = 0.3f;

    private Vector2 dampingVelocity;
    private Vector2 impact;

    public Vector2 Movement => impact;

    private void Update()
    {

        impact = Vector2.SmoothDamp(impact, Vector2.zero, ref dampingVelocity, drag);

        if (agent != null)
        {
            if (impact.sqrMagnitude < 0.2f * 0.2f)
            {
                impact = Vector2.zero;
                agent.enableAgent = true;
            }
        }
    }

    public void Reset()
    {
        impact = Vector2.zero;
    }

    public void AddForce(Vector2 force)
    {
        impact += force;
        if (agent != null)
        {
            agent.enableAgent = false;
        }
    }
}
