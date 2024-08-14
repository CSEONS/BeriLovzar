using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugSingleton", menuName = "Singleton/DebugSingleton")]
public class DebugSingleton : SingletonScriptableObject<DebugSingleton>
{
    public string PathToCSimpleCards => _pathToSimpleTrainCardsScriptableObjects;
    public IReadOnlyList<string> SimpleCardsTags => _simpleTrainCardTags;
    public IReadOnlyList<SimpleTrainCardScriptableObject> SimpleTrainCards => GetAllSimpleTrainCards();

    [SerializeField] private string _pathToSimpleTrainCardsScriptableObjects;
    [SerializeField] private List<string> _simpleTrainCardTags;

    private IReadOnlyList<SimpleTrainCardScriptableObject> GetAllSimpleTrainCards()
    {
        string relativePath = PathToCSimpleCards;
        var tags = SimpleCardsTags;

        List<SimpleTrainCardScriptableObject> cards = new List<SimpleTrainCardScriptableObject>();

        var dirtCards = Resources.LoadAll<SimpleTrainCardScriptableObject>(relativePath); //WIth meta files
        if (dirtCards != null && dirtCards.Length > 0)
        {
            cards.AddRange(dirtCards);

            cards.RemoveAll(c => c == null);
        }
        else
        {
            Debug.LogError($"<color=red>No cards found at path: {relativePath}</color>");
        }

        return cards;
    }

}