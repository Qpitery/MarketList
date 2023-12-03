using MarketList.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarketList.VM
{
    public class AddPageVM : BaseViewModel
    {
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private string _entryText;
        private string _messageLabel;

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public string EntryText
        {
            get => _entryText;
            set
            {
                _entryText = value;
                OnPropertyChanged();
            }
        }

        public string MessageLabel
        {
            get => _messageLabel;
            set
            {
                _messageLabel = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public AddPageVM()
        {
            Categories = new ObservableCollection<Category>(App.DB.GetCategories());

            AddCommand = new Command(ExecuteAddCommand);
            EditCommand = new Command(ExecuteEditCommand);
            DeleteCommand = new Command(ExecuteDeleteCommand);
        }

        private void ExecuteAddCommand()
        {
            Category category = new Category { Name = EntryText };
            App.DB.EditCategory(category);

            Categories = new ObservableCollection<Category>(App.DB.GetCategories());
            MessageLabel = "Добавлено!";
        }

        private void ExecuteEditCommand()
        {   
            if (SelectedCategory != null)
            {
                if (!string.IsNullOrEmpty(EntryText))
                {
                    SelectedCategory.Name = EntryText;

                    Categories = new ObservableCollection<Category>(App.DB.GetCategories());
                    MessageLabel = "Сохранено!!!";
                }
                else
                {
                    MessageLabel = "Введите Имя!!!";
                }
            }
            else
            {
                MessageLabel = "Выберите категорию!!!";
            }
        }

        private void ExecuteDeleteCommand()
        {
            if (SelectedCategory != null)
            {
                App.DB.DeleteCategory(SelectedCategory);

                Categories = new ObservableCollection<Category>(App.DB.GetCategories());
                MessageLabel = "Удалено!!!";
            }
            else
            {
                MessageLabel = "Выберите категорию для удаления";
            }
        }
    }
}
