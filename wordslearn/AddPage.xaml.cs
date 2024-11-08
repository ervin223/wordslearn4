namespace wordslearn
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent(); 
        }

        private async void OnSaveWordClicked(object sender, EventArgs e)
        {
            var newWord = new WordView
            {
                Name = entryName.Text,
                Translation = entryTranslation.Text,
                Explanation = entryExplanation.Text,
                Category = "Not learned"
            };

            await App.Database.SaveWordAsync(newWord);


            await Navigation.PopAsync();
        }




    }
}
