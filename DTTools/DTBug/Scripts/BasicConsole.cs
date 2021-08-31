using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(IFormatter))]

public class BasicConsole : MonoBehaviour,IConsole
{
    public KeyCode openCloseKey = KeyCode.Tab;

    public RectTransform content;
    public ScrollRect scrollRect;

    bool scrollRequired;
    float scrollTimer;

    [HideInInspector] public IFormatter formatter;
    [HideInInspector] public GenericObjectPool<Text> textPrefabPool;
    public void Init()
    {
        formatter = GetComponent<IFormatter>();
        formatter.Init();

        textPrefabPool = GetComponent<GenericObjectPool<Text>>();

        Hide();
        //Debug.Log("DTBug console initialised");
    }

    public void AddLine(LogType type, string line)
    {
        var prefab = textPrefabPool.Get();
        prefab.transform.SetParent(null);
        prefab.gameObject.SetActive(true);
        prefab.text = formatter.Format(type, line);
        prefab.transform.SetParent(content);
        EraseOldLogs();
        scrollRequired = true;
    }

    void EraseOldLogs()
    {
        if (content.childCount > 100) {
            for (int i = 0; i < 10; i++)
                textPrefabPool.ReturnToPool(content.GetChild(i).GetComponent<Text>());
        }
    }

    void ScrollToBottom()
    {
        scrollRect.verticalNormalizedPosition = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(openCloseKey)) {
            if (scrollRect.gameObject.activeSelf)
                Hide();
            else
                Show();
        }

        if (scrollRequired) {
            scrollTimer -= Time.deltaTime;

            if(scrollTimer <= 0) {
                ScrollToBottom();
                scrollRequired = false;
                scrollTimer = 0.1f;
            }
        }
    }

    void Hide()
    {
        scrollRect.gameObject.SetActive(false);
    }
    void Show()
    {
        scrollRect.gameObject.SetActive(true);
        scrollRequired = true;
    }
}
