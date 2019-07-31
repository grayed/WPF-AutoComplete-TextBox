using System.Collections;
using System.Threading.Tasks;

namespace AutoCompleteTextBox.Editors
{
    public interface ISuggestionProvider
    {
        #region Public Methods

        IEnumerable GetSuggestions(string filter);

        #endregion Public Methods
    }

    public interface ISuggestionProviderAsync
    {
        #region Public Methods

        Task<IEnumerable> GetSuggestionsAsync(string filter);

        #endregion Public Methods
    }
}
