using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.Exceptions;
using TraineeTracker.Application.Features.TraineeTests.Requests.Commands;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.TraineeTests.Handlers.Commands
{
    public class UpdateTraineeTestScoreCommandHandler : IRequestHandler<UpdateTraineeTestScoreCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTraineeTestScoreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateTraineeTestScoreCommand request, CancellationToken cancellationToken)
        {
            var traineeTest = await _unitOfWork.TraineeTestRepository.Get(request.TraineeTestId) ??
                throw new NotFoundException(nameof(TraineeTest), request.TraineeTestId);

            var testAnswer = await _unitOfWork.TraineeAnswerRepository.Get(request.TraineeAnswerId) ??
                throw new NotFoundException(nameof(TraineeAnswer), request.TraineeAnswerId);

            var question = await _unitOfWork.QuestionRepository
                .GetQuestionByCategoryId(traineeTest.SubCategoryId, request.Index) ??
                throw new NotFoundException(nameof(Question), request.Index);

            bool isCorrectAnswer = await _unitOfWork.AnswerRepository
                .HasAnswerByQuestionId(question.Id, testAnswer.Answer);

            if (isCorrectAnswer)
            {
                traineeTest.Score++;
                await _unitOfWork.TraineeTestRepository.Update(traineeTest);
                await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}
