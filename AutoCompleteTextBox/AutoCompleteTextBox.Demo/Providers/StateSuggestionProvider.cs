using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoCompleteTextBox.Demo.Model;
using AutoCompleteTextBox.Editors;

namespace AutoCompleteTextBox.Demo.Providers
{

    public class StateSuggestionProvider : ISuggestionProvider, ISuggestionProviderAsync
    {
        public IEnumerable<State> ListOfStates { get; set; }

        public IEnumerable GetSuggestions(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) return ListOfStates;
            return
                ListOfStates
                    .Where(state => state.Name.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    .ToList();

        }

        public async Task<IEnumerable> GetSuggestionsAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) return ListOfStates;
            return
                await Task<IEnumerable>.Run(() => ListOfStates
                    .Where(state => state.Name.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    .ToList());

        }

        public StateSuggestionProvider()
        {
            var states = StateFactory.CreateStateList(true);
            ListOfStates = states;
        }
    }    
}