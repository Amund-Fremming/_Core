﻿using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Shared.Pagination;
using Domain.Shared.ResultPattern;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Abstractions;

[ApiController]
public abstract class ReadControllerBase<T> : ControllerBase where T : GameBase
{
    private readonly IRepository<T> _repository;

    public ReadControllerBase()
        => _repository = HttpContext.RequestServices.GetService<IRepository<T>>()
            ?? throw new RepositoryNotFoundException(nameof(IRepository<T>));

    [HttpGet]
    public async Task<ActionResult<T>> Get(int id)
        => (await _repository.GetById(id))
            .Resolve(
                suc => Ok(suc.Data),
                err => BadRequest(err.Message));

    [HttpGet("page")]
    public async Task<ActionResult<IEnumerable<T>>> GetPage(PagedRequest<T> page)
        => (await _repository.GetPage(page))
            .Resolve(
                suc => Ok(suc.Data),
                err => BadRequest(err.Message));

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
        => (await _repository.GetAll())
            .Resolve(
                suc => Ok(suc.Data),
                err => BadRequest(err.Message));
}