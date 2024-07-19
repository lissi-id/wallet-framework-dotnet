﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hyperledger.Indy.WalletApi;
using Newtonsoft.Json.Linq;

namespace Hyperledger.Aries.Storage
{
    /// <summary>
    /// Wallet record service.
    /// </summary>
    public interface IWalletRecordService
    {
        /// <summary>
        /// Adds the record async.
        /// </summary>
        /// <returns>The record async.</returns>
        /// <param name="wallet">Wallet.</param>
        /// <param name="record">Record.</param>
        /// <param name="encode">The func for encoding the record to JSON format</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task AddAsync<T>(Wallet wallet, T record, Func<T, JObject>? encode = null) where T : RecordBase, new();
        
        /// <summary>
        /// Searches the records async.
        /// </summary>
        /// <returns>The records async.</returns>
        /// <param name="wallet">Wallet.</param>
        /// <param name="query">Query.</param>
        /// <param name="options">Options.</param>
        /// <param name="count">The number of items to return</param>
        /// <param name="skip">The number of items to skip</param>
        /// <param name="decode">Func for decoding the JSON to the record</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<List<T>> SearchAsync<T>(
            Wallet wallet,
            ISearchQuery? query = null,
            SearchOptions? options = null,
            int count = 10,
            int skip = 0,
            Func<JObject, T>? decode = null) where T : RecordBase, new();

        /// <summary>
        /// Updates the record async.
        /// </summary>
        /// <returns>The record async.</returns>
        /// <param name="wallet">Wallet.</param>
        /// <param name="record">Credential record.</param>
        Task UpdateAsync(Wallet wallet, RecordBase record);
        
        /// <summary>
        /// Updates the record async.
        /// </summary>
        /// <returns>The record async.</returns>
        /// <param name="wallet">Wallet.</param>
        /// <param name="record">Credential record.</param>
        /// <param name="encode">The func for encoding the record to JSON format</param>
        Task Update<T>(Wallet wallet, T record, Func<T, JObject>? encode = null) where T : RecordBase;

        /// <summary>
        /// Gets the record async.
        /// </summary>
        /// <returns>The record async.</returns>
        /// <param name="wallet">Wallet.</param>
        /// <param name="id">Identifier.</param>
        /// <param name="decode">Func for decoding the JSON to the record</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T?> GetAsync<T>(Wallet wallet, string id, Func<JObject, T>? decode = null) where T : RecordBase, new();

        /// <summary>
        /// Deletes the record async.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <param name="wallet">Wallet.</param>
        /// <param name="id">Record Identifier.</param>
        /// <returns>Boolean status indicating if the removal succeed</returns>
        Task<bool> DeleteAsync<T>(Wallet wallet, string id) where T : RecordBase, new();

        /// <summary>
        /// Deletes the record async.
        /// </summary>
        /// <param name="wallet">Wallet.</param>
        /// <param name="record"></param>
        /// <returns>Boolean status indicating if the removal succeed</returns>
        Task<bool> Delete(Wallet wallet, RecordBase record);
    }
}
