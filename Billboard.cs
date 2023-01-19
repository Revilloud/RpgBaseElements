using UnityEngine;

/// <summary>
/// Makes the item look straight at the player camera.
/// </summary>
public class Billboard : MonoBehaviour
{
    private void Update()
    {
        this.transform.LookAt(Camera.main.transform.position);
    }
}