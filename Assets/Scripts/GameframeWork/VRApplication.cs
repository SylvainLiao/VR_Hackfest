using UnityEngine;
using System.Collections;

public class VRApplication: MonoBehaviour
{
    private static VRApplication m_instance;
    public static VRApplication Instance
    {
        get
        {
            return (m_instance == null) ? new VRApplication() : m_instance;
        }
    }

    public UICanvas UiCanvas;

    private bool m_IsAllDataReady = false;
    [HideInInspector]
    public bool IsAllDataReady { get { return m_IsAllDataReady; } }

    public bool GamePause = false;
    //--------------------------------------------------------------------------------------
    private void Awake()
    {
        m_instance = this;
        Initial();
    }
    //--------------------------------------------------------------------------------------
    // Use this for initialization
    private void Start()
    {
        //Add All State At Here 

        m_IsAllDataReady = true;
    }
    //--------------------------------------------------------------------------------------
    private void Initial()
    {
    }
    //--------------------------------------------------------------------------------------
    private void Update()
    {
        if (GamePause)
            return;
    }
}
