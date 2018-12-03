using UnityEngine;

public class LiftBehaviour : MonoBehaviour
{
    private readonly int _liftSpeed = 3;
    private bool _ptrOnButton;
    private bool _lifting;
    private int _phase;
    private Vector3? _finalPos;

    public void OnEnter()
    {
        _ptrOnButton = true;
    }

    public void OnLeave()
    {
        _ptrOnButton = false;
    }

    private void AnimateTo(string gameObject, Vector3 finalPositionAddition, bool resetPhase = false)
    {
        var obj = GameObject.Find(gameObject);
        if (_finalPos == null)
        {
            _finalPos = obj.transform.position + finalPositionAddition;
        }

        float step = _liftSpeed * Time.deltaTime;
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, (Vector3) _finalPos, step);
        if (obj.transform.position == _finalPos)
        {
            _phase++;
            _finalPos = null;
            if (resetPhase)
            {
                _phase = 0;
                _lifting = false;
            }
        }
    }

    public void Update()
    {
        if (_ptrOnButton && Input.inputString.Length > 0 && Input.inputString[0] == 10 && !_lifting)
        {
            _lifting = true;
        }

        if (_lifting)
        {
            if (_phase == 0)
            {
                AnimateTo("HorizontalLift", Vector3.up * 1.4f);
            }
            else if (_phase == 1)
            {
                AnimateTo("Pusher", Vector3.forward * 2f);
            }
            else if (_phase == 2)
            {
                AnimateTo("Pusher", -Vector3.forward * 2f);
            }
            else
            {
                AnimateTo("HorizontalLift", -Vector3.up * 1.4f, true);
            }
        }
    }
}