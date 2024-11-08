using System.Collections.ObjectModel;
using System.Linq;

namespace wordslearn
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<WordView> Words { get; set; }

        private int _learnedCount;
        public int LearnedCount
        {
            get => _learnedCount;
            set
            {
                _learnedCount = value;
                OnPropertyChanged(nameof(LearnedCount));
            }
        }

        private int _notLearnedCount;
        public int NotLearnedCount
        {
            get => _notLearnedCount;
            set
            {
                _notLearnedCount = value;
                OnPropertyChanged(nameof(NotLearnedCount));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            Words = new ObservableCollection<WordView>();
            BindingContext = this;
            LoadWords(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadWords();  
        }

        private async void LoadWords()
        {
            try
            {
                var words = await App.Database.GetWordsAsync();
                Words.Clear();
                foreach (var word in words)
                {
                    Words.Add(word);
                }
                UpdateWordCounts(); 
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK"); 
            }
        }

        private void UpdateWordCounts()
        {
            int learnedCount = Words.Count(w => w.Category == "Learned");
            int notLearnedCount = Words.Count(w => w.Category == "Not learned");

            LearnedCount = learnedCount;
            NotLearnedCount = notLearnedCount;
            totalWordsCountLabel.Text = Words.Count.ToString(); 
        }

        private async void OnAddWordClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void OnEditWordClicked(object sender, EventArgs e)
        {
            if (WordsCarousel.CurrentItem is WordView currentWord)
            {
                await Navigation.PushAsync(new EditPage(currentWord));
            }
        }

        private async void OnDeleteWordClicked(object sender, EventArgs e)
        {
            if (WordsCarousel.CurrentItem is WordView currentWord)
            {
                bool confirm = await DisplayAlert("Confirmation", $"Delete '{currentWord.Name}'?", "Yes", "No");
                if (confirm)
                {
                    await App.Database.DeleteWordAsync(currentWord);
                    Words.Remove(currentWord);  
                    UpdateWordCounts(); 
                }
            }
        }
    }
}
