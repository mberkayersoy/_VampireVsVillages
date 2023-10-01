using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Route : MonoBehaviour
{
    Router router;
    UIDocument document;
    public RouterPaths Path;

    void Start()
    {
        document = GetComponent<UIDocument>();
        router = gameObject.GetComponentInParent<Router>();
        router.OnPathChange += OnRouteChanged;
        ApplyRoute();
    }

    private void OnDestroy()
    {
        router.OnPathChange -= OnRouteChanged;
    }

    public void OnRouteChanged(object sender, RouteChangedEvent e)
    {
        if (e.newPath == Path)
        {
            Show();
        } else
        {
            Hide();
        }
    }

    public void ApplyRoute()
    {
        if (router.path == Path)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public virtual void Show()
    {
        document.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public virtual void Hide()
    {
        document.rootVisualElement.style.display = DisplayStyle.None;
    }

}
