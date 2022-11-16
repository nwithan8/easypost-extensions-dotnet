using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyPost._base;

namespace EasyPost.Extensions;

public static class ExtensionMethods
{
    /*
     * This class houses all the extension methods (methods whose first parameter is preceded by the "this" keyword)
     * https://stackoverflow.com/a/846773
     *
     * This class must be static, but will not need to be referenced by name (the class name does not matter)
     * e.g. a user will call "myString.ToTitleCase()" instead of "General.ToTitleCase(myString)"
     */
    
    /// <summary>
    ///     Execute a service function as an instance method on a given EasyPost object.
    /// 
    ///     Example: rather than calling <c>myClient.Address.UpdateAddress(myAddress.Id, data)</c>, you can call <c>myAddress.InstanceMethodWithData(myClient.Address.Update, data)</c>
    ///
    ///     This method will only work on service methods expecting exactly two parameters: the first parameter is the ID of an object, and the second parameter is a dictionary.
    /// </summary>
    /// <param name="easyPostObject">EasyPost object to pass into service function.</param>
    /// <param name="func">Service function to execute using the object.</param>
    /// <param name="data">Data to pass into the service function.</param>
    /// <typeparam name="T">Type of object expected back from the service function.</typeparam>
    /// <returns>A T-type object.</returns>
    public static async Task<T> InstanceMethodWithData<T>(this EasyPostObject easyPostObject, Func<string, Dictionary<string, object?>, Task<T>> func, Dictionary<string, object?> data)
    {
        return await func(easyPostObject.Id!, data);
    }
    
    /// <summary>
    ///     Execute a service function as an instance method on a given EasyPost object.
    /// 
    ///     Example: rather than calling <c>myClient.Address.UpdateAddress(myAddress.Id, data)</c>, you can call <c>myAddress.InstanceMethodWithData(myClient.Address.Update, data)</c>
    ///
    ///     This method will only work on service methods expecting exactly two parameters: the first parameter is the ID of an object, and the second parameter is a dictionary.
    /// </summary>
    /// <param name="easyPostObject">EasyPost object to pass into service function.</param>
    /// <param name="func">Service function to execute using the object.</param>
    /// <param name="data">Data to pass into the service function.</param>
    /// <returns>None</returns>
    public static async Task InstanceMethodWithData(this EasyPostObject easyPostObject, Func<string, Dictionary<string, object?>, Task> func, Dictionary<string, object?> data)
    {
        await func(easyPostObject.Id!, data);
    }
    
    /// <summary>
    ///     Execute a service function as an instance method on a given EasyPost object.
    /// 
    ///     Example: rather than calling <c>myClient.Address.DeleteAddress(myAddress.Id)</c>, you can call <c>myAddress.InstanceMethod(myClient.Address.Delete)</c>
    ///
    ///     This method will only work on service methods expecting exactly one parameter: the ID of an object.
    /// </summary>
    /// <param name="easyPostObject">EasyPost object to update.</param>
    /// <param name="func">Service function to execute using the object.</param>
    /// <typeparam name="T">Type of object expected back from the service function.</typeparam>
    /// <returns>A T-type object.</returns>
    public static async Task<T> InstanceMethod<T>(this EasyPostObject easyPostObject, Func<string, Task<T>> func)
    {
        return await func(easyPostObject.Id!);
    }
    
    /// <summary>
    ///     Execute a service function as an instance method on a given EasyPost object.
    /// 
    ///     Example: rather than calling <c>myClient.Address.DeleteAddress(myAddress.Id)</c>, you can call <c>myAddress.InstanceMethod(myClient.Address.Delete)</c>
    ///
    ///     This method will only work on service methods expecting exactly one parameter: the ID of an object.
    /// </summary>
    /// <param name="easyPostObject">EasyPost object to update.</param>
    /// <param name="func">Service function to execute using the object.</param>
    /// <returns>None</returns>
    public static async Task InstanceMethod(this EasyPostObject easyPostObject, Func<string, Task> func)
    {
        await func(easyPostObject.Id!);
    }
    
    /// <summary>
    ///     Execute a service update function as an instance method on a given EasyPost object.
    /// 
    ///     Example: rather than calling <c>myClient.Address.UpdateAddress(myAddress.Id, data)</c>, you can call <c>myAddress.Update(myClient.Address.Update, data)</c>
    ///
    ///     This method will only work on service methods expecting exactly two parameters: the first parameter is the ID of an object, and the second parameter is a dictionary.
    ///
    ///     While you could potentially use this method to trigger other service methods (anything that meets the parameter requirements above), it is recommended to use this method exclusively for update functions.
    ///
    ///     Do not pass in anything other than <c>myClient.X.Update</c> as the first parameter.
    /// </summary>
    /// <param name="easyPostObject">EasyPost object to update.</param>
    /// <param name="func">Service function to execute using the object.</param>
    /// <param name="data">Data to pass into the service function.</param>
    /// <typeparam name="T">Type of object expected back from the service function.</typeparam>
    /// <returns>A T-type object.</returns>
    public static async Task<T> Update<T>(this EasyPostObject easyPostObject, Func<string, Dictionary<string, object?>, Task<T>> func, Dictionary<string, object?> data)
    {
        return await easyPostObject.InstanceMethodWithData<T>(func, data);
    }
    
    /// <summary>
    ///     Execute a service delete function as an instance method on a given EasyPost object.
    /// 
    ///     Example: rather than calling <c>myClient.Address.DeleteAddress(myAddress.Id)</c>, you can call <c>myAddress.Delete(myClient.Address.Delete)</c>
    ///
    ///     This method will only work on service methods expecting exactly one parameter: the ID of an object.
    ///
    ///     While you could potentially use this method to trigger other service methods (anything that meets the parameter requirements above), it is recommended to use this method exclusively for delete functions.
    ///
    ///     Do not pass in anything other than <c>myClient.X.Delete</c> as the first parameter.
    /// </summary>
    /// <param name="easyPostObject">EasyPost object to update.</param>
    /// <param name="func">Service function to execute using the object.</param>
    /// <returns>None</returns>
    public static async Task Delete(this EasyPostObject easyPostObject, Func<string, Task> func)
    {
        await easyPostObject.InstanceMethod(func);
    }
}