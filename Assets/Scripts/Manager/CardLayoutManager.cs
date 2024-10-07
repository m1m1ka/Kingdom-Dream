using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CardLayoutManager : MonoBehaviour
{
    public bool isHorizontal; //�Ƿ��������
    public float maxWidth = 10f;
    public float cardSpacing = 2f;

    public Vector3 centerPoint;
    [SerializeField]
    private List<Vector3> cardPositions= new();
    private List<Quaternion> cardRotations=new();

    public CardTransform GetCardTransform(int index, int totalCards)
    {
        CalculatePositions(totalCards, isHorizontal);

        return new CardTransform(cardPositions[index], cardRotations[index]);
    }
    private void CalculatePositions(int numberOfCards , bool horizontal)
    {
        cardPositions.Clear();
        cardRotations.Clear();
        if (horizontal)
        {
            //���㵱ǰ�������ƵĿ���
            float currentWidth = (numberOfCards-1)* cardSpacing;
            //��������ȡ��С
            float totalWidth = Mathf.Min(currentWidth, maxWidth);

            //һ�������Ͼ͸��¼��
            float currentSpacing = totalWidth > 0 ? totalWidth / (numberOfCards - 1) : 0;
            for (int i = 0; i < numberOfCards;i++)
            { 
                float xPost = 0-(totalWidth/2)+(i* currentSpacing);
                var position = new Vector3(xPost, centerPoint.y, 0);
                var rotation = Quaternion.identity;
                cardPositions.Add(position);
                cardRotations.Add(rotation);
            }
        }
    }
}