using UnityEngine;

public class IgnoreCollisionScript : MonoBehaviour
{
    public Collider colliderA;
    public Collider colliderB;

    void Start()
    {
        // Игнорировать столкновения между двумя конкретными коллайдерами
        Physics.IgnoreCollision(colliderA, colliderB, true);
    }
}

