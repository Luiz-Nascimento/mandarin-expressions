using AutoMapper;
using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.DTOs;
using MandarinExpressionsAPI.Repositories;

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
        Expression newExpression = _mapper.Map<Expression>(request);
        await _repository.AddAsync(newExpression);
        ExpressionResponseDto response = _mapper.Map<ExpressionResponseDto>(newExpression);
        return response;
    }
    
    
}