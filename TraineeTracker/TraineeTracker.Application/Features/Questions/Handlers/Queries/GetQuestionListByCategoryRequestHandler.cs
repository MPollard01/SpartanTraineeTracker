using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Question;
using TraineeTracker.Application.Features.Questions.Requests.Queries;

namespace TraineeTracker.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionListByCategoryRequestHandler : IRequestHandler<GetQuestionListByCategoryRequest, List<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionListByCategoryRequestHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionDto>> Handle(GetQuestionListByCategoryRequest request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetQuestionsByCategory(request.Category);
            return _mapper.Map<List<QuestionDto>>(questions);
        }
    }
}
