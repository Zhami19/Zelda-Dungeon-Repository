using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideKey()
    {
        Key k = FindObjectOfType<Key>();
        k.gameObject.SetActive(false);

        Destroy(this);
    }
}
