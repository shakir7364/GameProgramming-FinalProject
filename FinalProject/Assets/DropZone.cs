using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Draggable.Type type = Draggable.Type.MONSTER;

    bool turn;
    bool phase;

    [SerializeField]
    GameObject gameMaster;

    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        turn = gameMaster.GetComponent<GameMaster>().getTurn();
        phase = gameMaster.GetComponent<GameMaster>().getPhase();
        
        if (d != null)
        {
            if (type == d.type)
                if (turn)
                {
                    if (phase)
                    {
                        d.parentToReturnTo = this.transform;
                        d.GetComponent<RectTransform>().sizeDelta = new Vector2(d.GetComponent<RectTransform>().sizeDelta.x * .237f, 50);
                        if (d.type.Equals(Draggable.Type.MONSTER))
                        {
                            d.GetComponent<MonsterCard>().attackButton.GetComponent<RectTransform>().sizeDelta = new Vector2(d.GetComponent<RectTransform>().sizeDelta.x, 50);
                            d.GetComponent<MonsterCard>().points.transform.position = new Vector3(d.GetComponent<MonsterCard>().points.transform.position.x, d.GetComponent<MonsterCard>().points.transform.position.y - 80, d.GetComponent<MonsterCard>().points.transform.position.z);
                        }
                        else
                        {
                            d.GetComponent<SpellCard>().effectButton.GetComponent<RectTransform>().sizeDelta = new Vector2(d.GetComponent<RectTransform>().sizeDelta.x, 50);
                            d.GetComponent<SpellCard>().points.transform.position = new Vector3(d.GetComponent<SpellCard>().points.transform.position.x, d.GetComponent<SpellCard>().points.transform.position.y - 80, d.GetComponent<SpellCard>().points.transform.position.z);
                        }
                    }
                }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
