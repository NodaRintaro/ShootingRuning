using UnityEngine;

/// <summary>
/// �w�i���X�N���[�����邽�߂̃R���|�[�l���g�B
/// �K���ȃI�u�W�F�N�g�ɃA�^�b�`���Ďg���B
/// �w�i���w�肷��ƁA������������������B���ƕ����������̂����ɃX�N���[�����A��ʉ��ɏ�����Əォ��o�Ă���悤�ɂȂ�B
/// �]���āA�w�i�摜�͏㉺�Ɍq���Ă��悢���̂łȂ��Ă͂Ȃ�Ȃ��B
/// </summary>
public class BackgroundController : MonoBehaviour
{
    /// <summary>�w�i</summary>
    [SerializeField] SpriteRenderer m_backgroundSprite = null;
    /// <summary>�w�i�̃X�N���[�����x</summary>
    [SerializeField] float m_scrollSpeedX = -1f;
    /// <summary>�w�i���N���[���������̂����Ă����ϐ�</summary>
    SpriteRenderer m_backgroundSpriteClone;
    /// <summary>�w�i���W�̏����l</summary>
    float m_initialPositionX;
    Vector3 instantiatePosition;

    void Start()
    {
        m_initialPositionX = m_backgroundSprite.transform.position.x;   // ���W�̏����l��ۑ����Ă���

        // �w�i�摜�𕡐����ĉE�ɕ��ׂ�
        instantiatePosition = new Vector3( m_backgroundSprite.bounds.size.x, 0f, 0f);
        m_backgroundSpriteClone = Instantiate(m_backgroundSprite,instantiatePosition, new Quaternion(),gameObject.transform);
    }

    void Update()
    {
        // �w�i�摜���X�N���[������
        m_backgroundSprite.transform.Translate(m_scrollSpeedX * Time.deltaTime, 0f, 0f);
        m_backgroundSpriteClone.transform.Translate(m_scrollSpeedX * Time.deltaTime, 0f, 0f);

        // �w�i�摜��������x�E�ɍ~�肽��A���ɖ߂�
        if (m_backgroundSprite.transform.position.x < m_initialPositionX - m_backgroundSprite.bounds.size.x)
        {
            m_backgroundSprite.transform.Translate(m_backgroundSprite.bounds.size.x * 2, 0f, 0f);
        }

        // �w�i�摜�̃N���[����������x�E�ɍ~�肽��A���ɖ߂�
        if (m_backgroundSpriteClone.transform.position.x < m_initialPositionX - m_backgroundSpriteClone.bounds.size.x)
        {
            m_backgroundSpriteClone.transform.Translate(m_backgroundSpriteClone.bounds.size.x * 2, 0f, 0f);
        }
    }
}