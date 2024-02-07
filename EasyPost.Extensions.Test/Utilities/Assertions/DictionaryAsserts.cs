using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyPost.Extensions.Test.Utilities.Assertions
{
    internal class NotADictionaryException : Exception
    {
    }
    
    public abstract partial class Assert
    {
        private static void GuardArgumentNotNull(string argName, object argValue)
        {
            if (argValue == null)
                throw new ArgumentNullException(argName);
        }
        
        /// <summary>
        ///     Gets the value of a key in a dictionary, or null if the key does not exist.
        /// </summary>
        /// <param name="dictionary">The dictionary to parse.</param>
        /// <param name="key">The key to get the value of.</param>
        /// <returns>The value of the key, or null if the key does not exist.</returns>
        private static object? GetDictionaryValue(IReadOnlyDictionary<string, object> dictionary, string key)
        {
            return !dictionary.ContainsKey(key) ? null : dictionary[key];
        }
        
        /// <summary>
        ///     Gets the sub-dictionary of a key in a dictionary, or throws a NotADictionaryException if the key does not exist or the value is not a dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary to parse.</param>
        /// <param name="key">The key to get the value of.</param>
        /// <returns>The sub-dictionary of the key.</returns>
        /// <exception cref="NotADictionaryException">Thrown when the key does not exist or the value is not a dictionary.</exception>
        private static Dictionary<string, object> GetSubDictionary(IReadOnlyDictionary<string, object> dictionary, string key)
        {
            var value = GetDictionaryValue(dictionary, key);

            if (value is not Dictionary<string, object> dict)
                throw new NotADictionaryException();

            return dict;
        }
        
        /// <summary>
        ///     Verifies that the key path exists in the dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary to step through</param>
        /// <param name="path">The path of keys to follow</param>
        /// <exception cref="KeyPathExistsException">Thrown when the key path does not exist.</exception>
        public static void KeyPathExists(Dictionary<string, object> dictionary, string[] path)
        {
            GuardArgumentNotNull(nameof(dictionary), dictionary);
            GuardArgumentNotNull(nameof(path), path);

            // Collect the key and the index of the key in the path
            var keyPath = path.Select((t, i) => (t, i)).ToList();
            var usedKeys = new List<string>();
            
            foreach (var (key, index) in keyPath)
            {
                usedKeys.Add(key);
                
                if (!dictionary.ContainsKey(key))
                    throw new KeyPathExistsException(usedKeys.ToArray());

                // Past this point, we know the key exists
                
                // If we're at the end of the path, we're done
                if (index == keyPath.Count - 1)
                    return;
                
                // If we're not at the end of the path, we need to step into the dictionary
                try
                {
                    dictionary = GetSubDictionary(dictionary, key);
                } catch (NotADictionaryException)
                {
                    // If the value is null or not a dictionary, we can't step into it and the key path doesn't exist
                    throw new KeyPathExistsException(usedKeys.ToArray());
                }
            }
        }

        public static void KeyPathValueEquals<TValue>(Dictionary<string, object> dictionary, string[] path, TValue? value)
        {
            GuardArgumentNotNull(nameof(dictionary), dictionary);
            GuardArgumentNotNull(nameof(path), path);

            // Collect the key and the index of the key in the path
            var keyPath = path.Select((t, i) => (t, i)).ToList();
            var usedKeys = new List<string>();

            foreach (var (key, index) in keyPath)
            {
                usedKeys.Add(key);
                
                if (!dictionary.ContainsKey(key))
                    throw new KeyPathValueEqualsException(usedKeys.ToArray());

                // Past this point, we know the key exists
                
                // If we're at the end of the path, we're done
                if (index == keyPath.Count - 1)
                {
                    if (!dictionary[key].Equals(value))
                        throw new KeyPathValueEqualsException(usedKeys.ToArray(), value, dictionary[key]);
                    
                    return;
                }
                
                // If we're not at the end of the path, we need to step into the dictionary
                try
                {
                    dictionary = GetSubDictionary(dictionary, key);
                } catch (NotADictionaryException)
                {
                    // If the value is null or not a dictionary, we can't step into it and the key path doesn't exist
                    throw new KeyPathValueEqualsException(usedKeys.ToArray());
                }
            }
        }
    }
}
