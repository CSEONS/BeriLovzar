using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleTrainCard : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private SimpleTrainCardScriptableObject _card;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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