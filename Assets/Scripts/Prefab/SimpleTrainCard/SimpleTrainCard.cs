using System;
using UnityEngine;

public class SimpleTrainCard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AudioSource _audioSource;

    private SimpleTrainCardScriptableObject _card;

    private void Start()
    {
       _audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public void SetCard(SimpleTrainCardScriptableObject card)
    {
        if (card == null)
            throw new NotImplementedException();

        _card = card;
        _spriteRenderer.sprite = card.Image;
    }

    public float PlaySound()
    {
        _audioSource.clip = _card.Audio;

        _audioSource.Play();

        return _card.Audio.length;
    }
}