using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource gameAudio;
    public AudioClip audioPickedUpCoin, audioPickedUpKey, audioDestroyBox, audioDeathEnemy, audioGameOver, audioOpenDoor, audioAddHealth, audioHitEnemy, audioHitPlayer, audioPlayerCast, audioEnemyCast;

    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    public void PlayerPickedUpCoin() // воспроизведение звука подбора коина
    {
        gameAudio.PlayOneShot(audioPickedUpCoin, 0.3f);
    }

    public void PlayerPickedUpKey() // воспроизведение звука подбора ключа
    {
        gameAudio.PlayOneShot(audioPickedUpKey, 0.3f);
    }

    public void PlayerPickedUpHeart()
    {
        gameAudio.PlayOneShot(audioAddHealth, 0.3f); // воспроизведение звука подбора жизней
    }

    public void PlayerDestroyBox() // воспроизведение звука разрушения ящика
    {
        gameAudio.PlayOneShot(audioDestroyBox, 0.3f);
    }

    public void PlayerDeathEnemy() // воспроизведение звука убийства врага
    {
        gameAudio.PlayOneShot(audioDeathEnemy, 0.3f);
    }

    public void GameOver()
    {
        gameAudio.PlayOneShot(audioGameOver, 0.3f); // воспроизведение звука когда игрок умирает
    }

    public void PlayerWinLevel()
    {
        gameAudio.PlayOneShot(audioOpenDoor, 0.3f); // воспроизведение звука когда игрок прошел уровень
    }

    public void PlayerHitEnemy()
    {
        gameAudio.PlayOneShot(audioHitEnemy, 0.3f); // воспроизведение звука удара по врагу шариком
    }

    public void EnemyHitPlayer()
    {
        gameAudio.PlayOneShot(audioHitPlayer, 0.3f); // воспроизведение звука удара по игроку шариком
    }

    public void PlayerCastBall()
    {
        gameAudio.PlayOneShot(audioPlayerCast, 0.3f); // воспроизведение звука броска шарика игроком
    }

    public void EnemyCastBall()
    {
        gameAudio.PlayOneShot(audioEnemyCast, 0.3f); // воспроизведение звука броска шарика врагом
    }
}
