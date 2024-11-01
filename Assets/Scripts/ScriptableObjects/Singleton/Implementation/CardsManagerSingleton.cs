using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsManagerSingleton", menuName = "Singleton/CardsManagerSingleton")]
public class CardsManagerSingleton : SingletonScriptableObject<CardsManagerSingleton>
{
    public string PathToCards => _pathToCards;
    public List<string> AllCardTags => _allTags;

    [SerializeField] private string _pathToCards;
    [SerializeField] private List<string> _allTags;

    public IReadOnlyList<SimpleTrainCardScriptableObject> SimpleTrainCards => GetAllSimpleTrainCards();

    private IReadOnlyList<SimpleTrainCardScriptableObject> GetAllSimpleTrainCards()
    {
        string relativePath = _pathToCards;

        List<SimpleTrainCardScriptableObject> cards = new List<SimpleTrainCardScriptableObject>();

        var dirtCards = Resources.LoadAll<SimpleTrainCardScriptableObject>(relativePath);
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