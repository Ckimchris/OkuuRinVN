using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandler : MonoBehaviour, IDropHandler
{
    public string currentText;
    [SerializeField]
    private int slotIndex;

    //DEBUG Purposes mainly
    [SerializeField]
    private string currentMessage;

    //This act as a between stop for the TextBox's answer no inside because I can't access directly
    [SerializeField]
    private int currentTextBoxAnswerNumber;

    //Check if this emptySlot is filled or not
    [SerializeField]
    private bool hasTextBox;

    public int SlotIndex
    {
        get { return slotIndex; }
    }

    public bool HasTextBox
    {
        get { return hasTextBox; }
        set { hasTextBox = value; }
    }

    public int CurrentTextBoxAnswerNumber
    {
        get { return currentTextBoxAnswerNumber; }
        set { currentTextBoxAnswerNumber = value; }
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            currentText = eventData.pointerDrag.GetComponent<DragDropHandler>().ItemMessage;
            currentMessage = eventData.pointerDrag.GetComponent<DragDropHandler>().ItemMessage;
            currentTextBoxAnswerNumber = eventData.pointerDrag.GetComponent<DragDropHandler>().TextBoxAnswerNumber;
            hasTextBox = true;
            eventData.pointerDrag.GetComponent<DragDropHandler>().isLocked = true;
            //Debug.Log(currentMessage);
        }

    }
}
