namespace Classwork_12._01._24_cookies_sessions_.Models
{
    public class ClickState
    {
        public bool IsClicked { get; set; }
        public ClickState(bool state)
        {
            IsClicked = state == false ? true : false;
        }
    }
}
