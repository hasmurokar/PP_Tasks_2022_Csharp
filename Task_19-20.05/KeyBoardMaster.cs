namespace Task_19_20._05
{
    public class KeyBoardMaster
    {
        public event Action wKeyPressedEvent = null;
        public event Action sKeyPressedEvent = null;
        public event Action aKeyPressedEvent = null;
        public event Action dKeyPressedEvent = null;
        public event Action fKeyPressedEvent = null;

        public void WKeyPressedEvent()
        {
            wKeyPressedEvent?.Invoke();
        }
        public void SKeyPressedEvent()
        {
            sKeyPressedEvent?.Invoke();
        }
        public void AKeyPressedEvent()
        {
            aKeyPressedEvent?.Invoke();
        }
        public void DKeyPressedEvent()
        {
            dKeyPressedEvent?.Invoke();
        }
        public void FKeyPressedEvent()
        {
            fKeyPressedEvent?.Invoke();
        }
    }
}
