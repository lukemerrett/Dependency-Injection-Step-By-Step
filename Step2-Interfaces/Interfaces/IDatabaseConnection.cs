﻿namespace StepTwo_Interfaces.Interfaces
{
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Dummy method representing a query against a data store.
        /// </summary>
        /// <typeparam name="T">Type of item to return</typeparam>
        /// <param name="identifier">Dummy identifier representing the parameter we'd pass to the data store.</param>
        /// <returns>A default instance of the type provided.</returns>
        T Get<T>(string identifier);
    }
}
