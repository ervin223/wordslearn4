using System;

namespace wordslearn
{
    public partial class EditPage : ContentPage
    {
        private WordView _word;

        public EditPage(WordView word)
        {
            InitializeComponent();
            _word = word;
            BindingContext = _word;  // Bind the word to the page for easy data access
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _word.Name = entryName.Text;
            _word.Translation = entryTranslation.Text;
            _word.Explanation = entryExplanation.Text;
            _word.Category = categoryPicker.SelectedItem?.ToString();  // Get the selected category from the Picker

            await App.Database.SaveWordAsync(_word);
            
            await Navigation.PopAsync();
        }


    }
}
