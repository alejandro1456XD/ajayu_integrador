using System.Collections;
using UnityEngine;

public class Entiy_VFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("On Damage VFX")]

    [SerializeField] private Material OnDamageMaterial;
    [SerializeField] private float OnDamageVfxDuration = .2f;

    private Material originalMaterial;
    private Coroutine onDamageVfxCoroutine;


    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = sr.material;

    }
    public void PlayOnDamageVfx()
    {
        if(onDamageVfxCoroutine != null)
        {
            StopCoroutine(onDamageVfxCoroutine);
        }


         onDamageVfxCoroutine=StartCoroutine(OnDamageVfxCo());
    }


    private IEnumerator OnDamageVfxCo()
    {
        sr.material = OnDamageMaterial;
        yield return new WaitForSeconds(OnDamageVfxDuration);
        sr.material = originalMaterial;
    }


}
