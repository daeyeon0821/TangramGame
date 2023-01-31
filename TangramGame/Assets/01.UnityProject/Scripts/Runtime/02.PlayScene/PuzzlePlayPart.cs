using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, 
    IPointerUpHandler, IDragHandler
{ 
    private bool isClicked = false;
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.
            gameObject.GetComponentMust<PuzzleInitZone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //! ���콺 ��ư�� ������ �� �����ϴ� �Լ�
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }       // OnPointerDown()

    //! ���콺 ��ư���� ���� ���� �� �����ϴ� �Լ�
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }       // OnPointerUp()

    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�
    public void OnDrag(PointerEventData eventData)
    {
        if(isClicked == true)
        {
            // ������ǥ�� �����ϴ� ���� ->
            // ����� �������� ���� �����ǿ� ���ϴ� �������� ����
            // eventData.delta

            // ĵ���� scaleFactor ��ŭ �߻��ϴ� ������ �����ϴ� ����
            gameObject.AddAnchoredPos(
                eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);

            //GFunc.Log($"���콺�� �������� ������ Ȯ�� : ({objRect.anchoredPosition.x}, {objRect.anchoredPosition.y})");
        }       // if: ���� ������Ʈ�� ������ ���
    }       // OnDrag()
}