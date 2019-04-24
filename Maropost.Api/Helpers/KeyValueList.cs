using System;
using System.Collections.Generic;
using System.Text;

namespace Maropost.Api.Helpers
{
    /// <remarks>
    /// Derived from code published by phoog: https://stackoverflow.com/users/385844/phoog.
    /// Originally published at https://stackoverflow.com/a/11695018/83852 under Creative Commons (cc by-sa 3.0) license.
    /// </remarks>
    internal class KeyValueList : List<KeyValuePair<string, object>>
    {
        public void Add(string key, object value)
        {
            Add(new KeyValuePair<string, object>(key, value));
        }
    }
}
