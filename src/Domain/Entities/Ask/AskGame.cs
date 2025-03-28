﻿using Domain.Abstractions;
using Domain.Entities.Shared;
using Domain.Shared.Enums;
using Domain.Shared.ResultPattern;
using Domain.Shared.TypeScript;

namespace Domain.Entities.Ask;

/// <summary>
/// The game logic is entirely managed on the client side.
/// </summary>
public sealed class AskGame : GameBase, ITypeScriptModel
{
    public Category Category { get; private set; }
    public AskGameState State { get; private set; }
    public string? Description { get; init; }

    private readonly List<Question> _questions = [];
    public IReadOnlyList<Question> Questions => _questions.AsReadOnly();

    private AskGame()
    { }

    public Result<int> AddQuestion(Question question, RegisteredUser player)
    {
        if (question is null)
        {
            return new Error("Question cannot be null.");
        }

        _questions.Add(question);
        IterationCount++;
        return _questions.Count;
    }

    public Result<AskGame> StartGame()
    {
        State = AskGameState.Closed;
        Shuffle();
        return this;
    }

    private void Shuffle()
    {
        var random = new Random();

        int n = _questions.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var value = _questions[k];
            _questions[k] = _questions[n];
            _questions[n] = value;
        }
    }

    public AskGame Create(string name, string? description = default!, Category? category = Category.Random)
        => new()
        {
            Category = category ?? Category.Random,
            State = AskGameState.Initialized,
            UniversalId = $"{nameof(AskGame)}:{Id}",
            Name = name,
            IterationCount = 0,
            CurrentIteration = 0,
            Description = description,
        };
}