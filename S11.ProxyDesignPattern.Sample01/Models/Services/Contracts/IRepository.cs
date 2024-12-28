﻿using Azure;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks.Contracts;

namespace S11.ProxyDesignPattern.Sample01.Models.Services.Contracts
{
    public interface IRepository<T, TCollection>
    {
        Task<IResponse<TCollection>> SelectAll();
        Task<IResponse<T>> Select(T obj);
        Task<IResponse<T>> Insert(T obj);
        //Task<IResponse<T>> Update(T obj);
        //Task<IResponse<T>> Delete(T obj);
    }
}
