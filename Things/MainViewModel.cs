using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Things
{
    class MainViewModel : INotifyPropertyChanged
    {
        readonly INavigation _navigation;


        public string InboxTitle
        {
            get { return "Inbox"; }
        }

        public ObservableCollection<TodoItem> Items
        {
            get { return _items; }
        }

        public ICommand AddCommand
        {
            get { return _addItemCommand ?? (_addItemCommand = new Command(AddCommandHandler)); }
        }

		async void AddCommandHandler()
        {

			DependencyService.Get<ITextToSpeech> ().Speak ("Hello all");

//			var addPage = new AddItemPage {
//				BindingContext = this
//			};
//			await _navigation.PushAsync(addPage);
        }


		#region AddItemViewModel
        public string AddItemPageTitle
        {
            get { return "Add/Edit Items"; }
        }

        public string ItemText
        {
            get { return _itemText; }
            set
            {
                _itemText = value;
                _saveItem.ChangeCanExecute();
            }
        }

        public bool IsDone { get; set; }

        public ICommand SaveItem
        {
            get
            {
                return _saveItem ?? (_saveItem = new Command(SaveHandler, () => !string.IsNullOrWhiteSpace(ItemText)));
            }
        }

		async void SaveHandler()
        {
            Items.Add(new TodoItem
            {
                ItemText = this.ItemText, 
                IsDone = this.IsDone
            });

			await _navigation.PopAsync();
        }

		#endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<TodoItem> _items = new ObservableCollection<TodoItem>();
        Command _addItemCommand;
        string _itemText;
        Command _saveItem;

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}
