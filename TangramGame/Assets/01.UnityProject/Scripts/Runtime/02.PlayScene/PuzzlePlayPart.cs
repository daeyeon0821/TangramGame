using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, 
    IPointerUpHandler, IDragHandler
{
    public PuzzleType puzzleType = PuzzleType.NONE;
    private Image puzzleImage = default;

    private bool isClicked = false;
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    private PlayLevel playLevel = default;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.
            gameObject.GetComponentMust<PuzzleInitZone>();

        playLevel = GameManager.Instance.
            gameObjs[GData.OBJ_NAME_CURRENT_LEVEL].
            GetComponentMust<PlayLevel>();

        puzzleImage = gameObject.
            FindChildObj("PuzzleImage").GetComponentMust<Image>();

        // ���� �̹��� �̸��� ���� ������ Ÿ���� ��������.
        switch (puzzleImage.sprite.name)
        {
            case "Puzzle_BigTriangle1":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            case "Puzzle_BigTriangle2":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            default:
                puzzleType = PuzzleType.NONE;
                break;
        }       // switch
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

        // ���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ�
        // ���� ����� ������ ã�ƿ´�.
        PuzzleLvPart closeLvPuzzle = 
        playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        if(closeLvPuzzle == null || closeLvPuzzle == default)
        {
            return;
        }

        transform.position = closeLvPuzzle.transform.position;
        GFunc.Log($"{closeLvPuzzle.name}�� ���� �����̿� �ֽ��ϴ�.");
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
