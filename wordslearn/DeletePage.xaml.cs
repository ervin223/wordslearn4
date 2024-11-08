using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordslearn
{
    public partial class DeletePage : ContentPage
    {
        private WordView _word;

        public DeletePage(WordView word)
        {
            InitializeComponent();
            _word = word;
            labelWord.Text = $"Are you sure you want to delete '{word.Name}'?";
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            await App.Database.DeleteWordAsync(_word);

            await Navigation.PopAsync();
        }


        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}