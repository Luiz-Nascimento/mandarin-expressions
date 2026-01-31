using AutoMapper;
using AutoMapper.QueryableExtensions;
using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.DTOs;
using MandarinExpressionsAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MandarinExpressionsAPI.Services;

public class ExpressionService : IExpressionService
{
    private readonly IExpressionRepository _repository;
    private readonly IMapper _mapper;

    public ExpressionService(IExpressionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ExpressionResponseDto>> GetAllAsync()
    {
        return await _repository
            .GetAll()
            .ProjectTo<ExpressionResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<ExpressionResponseDto> GetByIdAsync(Guid id)
    {
        var expression = await _repository.GetByIdAsync(id);
        if (expression is null)
        {
            throw new InvalidOperationException("Expression not found");
        }

        return _mapper.Map<ExpressionResponseDto>(expression);
    } 

    public async Task<ExpressionResponseDto> GetRandomByLevelAsync(Level level)
    {
        var expressions = await _repository.GetByLevelAsync(level);

        if (!expressions.Any())
        {
            throw new KeyNotFoundException("No expressions found for this level");
        }

        var randomIndex = Random.Shared.Next(expressions.Count);
        Expression randomExpression = expressions[randomIndex];
        return _mapper.Map<ExpressionResponseDto>(randomExpression);
    }

    public async Task<ExpressionResponseDto> CreateAsync(ExpressionRequestDto request)
    {
        if (await _repository.ExistsByHanziAsync(request.Hanzi))
        {
            throw new InvalidOperationException("Expression with that hanzi already exists");
        }
        Expression newExpression = _mapper.Map<Expression>(request);
        await _repository.AddAsync(newExpression);
        ExpressionResponseDto response = _mapper.Map<ExpressionResponseDto>(newExpression);
        return response;
    }

    public async Task DeleteAsync(Guid id)
    {
        var expression = await _repository.GetByIdAsync(id);
        if (expression is null)
        {
            throw new InvalidOperationException("Expression not found");
        }

        await _repository.DeleteAsync(expression);
    }
}