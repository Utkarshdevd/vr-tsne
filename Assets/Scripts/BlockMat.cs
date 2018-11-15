using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMat : MonoBehaviour
{
    public Color Color1, Color2;
    public float Speed = 1, Offset;
 
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
 
    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {

    }
 
    public void AddColor(float percentage){
        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);
        // Assign our new value.
        _propBlock.SetColor("_Color", new Color(0, percentage, 0, 1));
        // Apply the edited values to the renderer.
        _renderer.SetPropertyBlock(_propBlock);
    }
    void Update()
    {
        
    }
}