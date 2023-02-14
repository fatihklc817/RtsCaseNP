using UnityEngine;

public interface IShooting
{
    void Shoot(Transform targetTransform);
    void StopShooting();
    void Update();
}