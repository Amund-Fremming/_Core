﻿using Domain.Abstractions;
using Domain.Contracts;
using Domain.Shared.Pagination;
using Domain.Shared.ResultPattern;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions;

public abstract class RepositoryBase<T>(IAppDbContext context) : IRepository<T> where T : class
{
    public async Task<Result<T>> GetById(int id)
    {
        try
        {
            var entity = await context.Entity<T>()
                .FindAsync(id);

            if (entity != null)
            {
                return entity;
            }

            return new Error($"{typeof(T)} with id {id}, does not exist.");
        }
        catch (Exception ex)
        {
            return new Error(ex.Message, ex);
        }
    }

    public async Task<Result<IEnumerable<T>>> GetPage(PagedRequest pagedRequest)
    {
        try
        {
            return await context.Entity<T>()
                .AsNoTracking()
                .Take(pagedRequest.Take)
                .Skip(pagedRequest.Skip)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            return new Error(ex.Message, ex);
        }
    }

    public async Task<Result<IEnumerable<T>>> GetAll()
    {
        try
        {
            return await context.Entity<T>()
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            return new Error(ex.Message, ex);
        }
    }

    public async Task<Result> Create(T entity)
    {
        try
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return Result.Ok;
        }
        catch (Exception ex)
        {
            return new Error(ex.Message, ex);
        }
    }

    public async Task<Result> Update(T entity)
    {
        try
        {
            context.ApplyChanges(entity);
            await context.SaveChangesAsync();

            return Result.Ok;
        }
        catch (Exception ex)
        {
            return new Error(ex.Message, ex);
        }
    }

    public async Task<Result> Delete(int id)
    {
        try
        {
            var result = await GetById(id);
            if (result.IsError)
            {
                return result.Error;
            }

            var entity = result.Data;
            context.Delete(entity);
            await context.SaveChangesAsync();

            return Result.Ok;
        }
        catch (Exception ex)
        {
            return new Error(ex.Message, ex);
        }
    }
}