﻿using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public void ApplyChanges<T>(T entity) where T : class => base.Update<T>(entity);

    public void Delete<T>(T entity) where T : class => base.Remove(entity);

    public async ValueTask<T?> FindAsync<T>(int id) where T : class => await base.Set<T>().FindAsync(id);

    public async ValueTask AddAsync<T>(T entity) where T : class => await base.AddAsync(entity);

    public async Task SaveChangesAsync() => await base.SaveChangesAsync();

    public DbSet<T> Entity<T>() where T : class => base.Set<T>();
}