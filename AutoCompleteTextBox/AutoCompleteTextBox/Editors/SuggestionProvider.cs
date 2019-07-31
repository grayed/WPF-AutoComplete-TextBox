using System;
using System.Collections;
using System.Threading.Tasks;

namespace AutoCompleteTextBox.Editors
{
    public class SuggestionProvider : ISuggestionProvider, ISuggestionProviderAsync
    {


        #region Private Fields

        private readonly Func<string, IEnumerable> _method;

        #endregion Private Fields

        #region Public Constructors

        public SuggestionProvider(Func<string, IEnumerable> method)
        {
            _method = method ?? throw new ArgumentNullException(nameof(method));
        }

        #endregion Public Constructors

        #region Public Methods

        public IEnumerable GetSuggestions(string filter)
        {
            return _method(filter);
        }

        public async Task<IEnumerable> GetSuggestionsAsync(string filter)
        {
            return await Task<IEnumerable>.Run(() => _method(filter));
        }

        #endregion Public Methods

    }
}