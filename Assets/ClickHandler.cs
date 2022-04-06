using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var hit = Physics2D.Raycast(Input.mousePosition, transform.TransformDirection(Vector2.up));
        if (!hit.transform.TryGetComponent(out Weapon weapon)) return;
        weapon.Shoot();
    }
}
