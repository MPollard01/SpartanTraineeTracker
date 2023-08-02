using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Question;
using TraineeTracker.Application.Features.Questions.Requests.Queries;

namespace TraineeTracker.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionByCategoryRequestHandler : IRequestHandler<GetQuestionByCategoryRequest, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionByCategoryRequestHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<QuestionDto> Handle(GetQuestionByCategoryRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetQuestionByCategory(request.Category, request.Index);
            return _mapper.Map<QuestionDto>(question);
        }
    }
}
