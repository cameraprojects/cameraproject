using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwaKinoController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _triggerRadius = 1f;

    private List<Transform> _players = new List<Transform>();

    private static readonly int s_hashAwaLevel = Animator.StringToHash("AwaLevel");
    private static readonly int s_hashJump     = Animator.StringToHash("Jump");

    private const string TAG_PLAYER = "Player";

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _triggerRadius);
    }
#endif

    private void Start()
    {
        var col = gameObject.AddComponent<SphereCollider>();
        col.radius = _triggerRadius;
        col.isTrigger = true;
    }

    private void Update()
    {
        if (_players.Count == 0)
            return;


        //TODO: AwaLevel��3�i�K
        // level1: �v���C���[�̕���������
        // level2: ���킠�킷��
        // level3: �n�ʂɐ���

        // �ŋߖTPlayer�Ƃ̋������擾
        (float Dist, Transform Player) closest = (float.MaxValue, null);
        Vector3 myPos = transform.position;
        foreach(var player in _players)
        {
            float dist = Vector3.Distance(myPos, player.position);
            if(dist < closest.Dist)
            {
                closest = (dist, player);
            }
        }

        // �����ɉ�����AwaLevel���X�V
        float awaLevel = 1f - closest.Dist / _triggerRadius;
        _animator.SetFloat(s_hashAwaLevel, awaLevel);
        Debug.Log(awaLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");

        if (!other.CompareTag(TAG_PLAYER))
            return;

        var otherTRS = other.transform;
        if (!_players.Contains(otherTRS))
            _players.Add(otherTRS);
    }

    private void OnTriggerExit(Collider other)
    {
        var otherTRS = other.transform;
        if (_players.Contains(otherTRS))
            _players.Remove(otherTRS);
    }
}
