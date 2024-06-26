using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu]
public class MaterialSO : ScriptableObject
{
    [SerializeField]
    private Material _value;

    public Material Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
