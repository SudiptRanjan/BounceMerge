using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public Transform ballBounce;
    private Vector3 origSize, bounceSize; 
    
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(2, 2, 2);
        bounceSize = new Vector3(1f, 0.8f, 2);
        OnScale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScale()
    {
        //transform.DOScale(bounceSize, 1f).SetEase(Ease.OutSine).OnComplete(() => { transform.DOScale(origSize, 1f).SetEase(Ease.OutSine).SetDelay(1).OnComplete(OnScale); });
        transform.DOScale(bounceSize, 0.5f).SetEase(Ease.OutSine).SetLoops((int)LoopType.Yoyo).OnComplete(() => {transform.DOScale(origSize, 0.5f); }); 

    }

}
