using UnityEngine;

public class DestroyAfterTimeAmount : SelfDestroy
{
    [SerializeField] public float Seconds;
    
    private void OnEnable()
    {
        //if (transform.parent != null) transform.parent = null;
        StartCoroutine(DestroyAfterTimeAmount(Seconds,gameObject));
    }
}
