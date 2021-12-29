using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource gameAudio;
    public AudioClip audioPickedUpCoin, audioPickedUpKey, audioDestroyBox, audioDeathEnemy, audioGameOver, audioOpenDoor, audioAddHealth, audioHitEnemy, audioHitPlayer, audioPlayerCast, audioEnemyCast;
    private float audioVolume = 1.0f;

    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    public void PlayerPickedUpCoin() // воспроизведение звука подбора коина
    {
        gameAudio.PlayOneShot(audioPickedUpCoin, audioVolume);
    }

    public void PlayerPickedUpKey() // воспроизведение звука подбора ключа
    {
        gameAudio.PlayOneShot(audioPickedUpKey, audioVolume);
    }

    public void PlayerPickedUpHeart()
    {
        gameAudio.PlayOneShot(audioAddHealth, audioVolume); // воспроизведение звука подбора жизней
    }

    public void PlayerDestroyBox() // воспроизведение звука разрушения ящика
    {
        gameAudio.PlayOneShot(audioDestroyBox, audioVolume);
    }

    public void PlayerDeathEnemy() // воспроизведение звука убийства врага
    {
        gameAudio.PlayOneShot(audioDeathEnemy, audioVolume);
    }

    public void GameOver()
    {
        gameAudio.PlayOneShot(audioGameOver, audioVolume); // воспроизведение звука когда игрок умирает
    }

    public void PlayerWinLevel()
    {
        gameAudio.PlayOneShot(audioOpenDoor, audioVolume); // воспроизведение звука когда игрок прошел уровень
    }

    public void PlayerHitEnemy()
    {
        gameAudio.PlayOneShot(audioHitEnemy, audioVolume); // воспроизведение звука удара по врагу шариком
    }

    public void EnemyHitPlayer()
    {
        gameAudio.PlayOneShot(audioHitPlayer, audioVolume); // воспроизведение звука удара по игроку шариком
    }

    public void PlayerCastBall()
    {
        gameAudio.PlayOneShot(audioPlayerCast, audioVolume); // воспроизведение звука броска шарика игроком
    }

    public void EnemyCastBall()
    {
        gameAudio.PlayOneShot(audioEnemyCast, audioVolume); // воспроизведение звука броска шарика врагом
    }
}
