using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SimpleCardTagsValidateTest : MonoBehaviour, ISceneTest
{
    [SerializeField] private CardsManagerSingleton _cardsManager;
    public string Name => nameof(SimpleCardTagsValidateTest);

    public bool IsPassed()
    {
        var cards = _cardsManager.SimpleTrainCards;

        foreach (var card in cards)
        {
            foreach (var tag in card.Tags)
            {
                if (_cardsManager.AllCardTags.Contains(tag))
                    continue;

                Debug.LogError($"<color=red>Card name: \"{card.PrefabName}\".\nTag \"{tag}\", not exist in debugManager</color>");
                return false;
            }
        }

        return true;
    }
}
