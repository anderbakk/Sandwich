using System.Collections.Generic;

namespace Sandwich.Core.Interface
{
    public interface IProvideSettings
    {
        IEnumerable<KeyValuePair<string, string>> GetSettings();
    }
}
