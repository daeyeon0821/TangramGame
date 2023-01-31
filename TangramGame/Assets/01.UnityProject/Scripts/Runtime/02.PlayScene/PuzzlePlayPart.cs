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

        // 퍼즐 이미지 이름에 따라서 퍼즐의 타입이 정해진다.
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

    //! 마우스 버튼을 눌렀을 때 동작하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }       // OnPointerDown()

    //! 마우스 버튼에서 손을 뗐을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;

        // 여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서
        // 가장 가까운 퍼즐을 찾아온다.
        PuzzleLvPart closeLvPuzzle = 
        playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        if(closeLvPuzzle == null || closeLvPuzzle == default)
        {
            return;
        }

        transform.position = closeLvPuzzle.transform.position;
        GFunc.Log($"{closeLvPuzzle.name}이 가장 가까이에 있습니다.");
    }       // OnPointerUp()

    //! 마우스를 드래그 중일 때 동작하는 함수
    public void OnDrag(PointerEventData eventData)
    {
        if(isClicked == true)
        {
            // 절대좌표를 설정하는 로직 ->
            // 상대적 움직임을 현재 포지션에 더하는 로직으로 수정
            // eventData.delta

            // 캔버스 scaleFactor 만큼 발생하는 오차를 수정하는 로직
            gameObject.AddAnchoredPos(
                eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);

            //GFunc.Log($"마우스의 포지션을 눈으로 확인 : ({objRect.anchoredPosition.x}, {objRect.anchoredPosition.y})");
        }       // if: 현재 오브젝트를 선택한 경우
    }       // OnDrag()
}
