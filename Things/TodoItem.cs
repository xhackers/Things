namespace Things
{

    class TodoItem
    {
        public bool IsDone { get; set; }
        public string  ItemText { get; set; }

        public string IsCheck
        {
            get { return IsDone ? "☑️" : "◻️"; }
        }
    }
}
