using System;
using UnityEngine;

public class ClickReader : MonoBehaviour
{
    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                
                if (cube != null)
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}
