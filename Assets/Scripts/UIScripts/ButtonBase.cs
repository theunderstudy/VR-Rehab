using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    protected string Function;

    public GameObject LeftHand, RightHand, LeftHandMirror, RightHandMirror, LeftHandAugment, RightHandAugment;

    public Color Selected;
    private void Start()
    {
        if (Function == "")
        {
            Function = gameObject.name;
        }
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
      
        if (eventData.button == PointerEventData.InputButton.Left)
        {

            Invoke(Function ,0);
           ButtonBase[] buttons = FindObjectsOfType<ButtonBase>();//
            foreach (ButtonBase item in buttons)
            {
                item.GetComponent<Image>().color = Color.white;
            }
            GetComponent<Image>().color = Selected;
        }           
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("right click");
        }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //tweenUp
        transform.DOScale(Vector3.one*1.2f, 0.05f);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.05f);

        //TweenDown
    }

    private void Reset()
    {

    }

    private void MirrorLeftHand()
    {
        LeftHandMirror.SetActive(!LeftHandMirror.activeSelf);
    }

    private void MirrorRightHand()
    {
        RightHandMirror.SetActive(!RightHandMirror.activeSelf);
    }

    private void AugmentLeftHand()
    {
        LeftHandAugment.SetActive(!LeftHandAugment.activeSelf);
    }

    private void AugmentRightHand()
    {
        RightHandAugment.SetActive(!RightHandAugment.activeSelf);
    }

    private void AugmentBothHands()
    {
        LeftHandAugment.SetActive(!LeftHandAugment.activeSelf);
        RightHandAugment.SetActive(!RightHandAugment.activeSelf);
    }
}
