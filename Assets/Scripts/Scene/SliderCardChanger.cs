using DG.Tweening;
using UnityEngine;

public class SliderCardChanger : MonoBehaviour
{
    [SerializeField] private Transform _moveObject;

    [SerializeField] private SimpleTrainCard _cardTemplate;

    [SerializeField] private float _cardChangeDuration;

    [SerializeField] private float _moveDistance;

    [SerializeField] private float _beforeSoundWaitDuratio;

    [SerializeField] private float _afterSoundWaitDuratio;

    [SerializeField] private SimpleTrainCardScriptableObject[] _cards;

    [SerializeField] private bool _loop;

    private Sequence _sequence;
    private int _currentCardIndex;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        if (_sequence == null || !_sequence.IsPlaying())
        {
            PlaySequence(_currentCardIndex);
        }
    }

    public void Stop()
    {
        if (_sequence != null && _sequence.IsPlaying())
        {
            _sequence.Pause();
        }
    }

    public void Reset()
    {
        _sequence?.Kill();
        _currentCardIndex = 0;
        PlaySequence(0);
    }

    private void PlaySequence(int startIndex)
    {
        _sequence = DOTween.Sequence();

        for (int i = startIndex; i < _cards.Length; i++)
        {
            var card = _cards[i];
            int cardIndex = i; // Ћокальна€ копи€ дл€ использовани€ в замыкании

            _sequence.Append(
                _moveObject.transform.DOMove(transform.position + Vector3.down * _moveDistance, _cardChangeDuration)
                .OnComplete(() =>
                {
                    _cardTemplate.SetCard(card);
                    _currentCardIndex = cardIndex + 1;
                })
            );

            _sequence.AppendInterval(_beforeSoundWaitDuratio);

            _sequence.Append(
                _moveObject.transform.DOMove(Vector3.zero, _cardChangeDuration)
                .OnComplete(() =>
                {
                    _cardTemplate.PlaySound();
                })
            );

            _sequence.AppendInterval(card.Audio.length + _afterSoundWaitDuratio);
        }

        if (_loop)
        {
            _sequence.AppendCallback(() => PlaySequence(0));
        }

        _sequence.Play();
    }
}