using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TrainerCourse.Validators;
using TraineeTracker.Application.Features.TrainerCourses.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.TrainerCourses.Handlers.Commands
{
    public class CreateTrainerCourseCommandHandler : IRequestHandler<CreateTrainerCourseCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateTrainerCourseCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainerCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainerCourseDtoValidator();

            var validationResult = await validator.ValidateAsync(request.TrainerCourseDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var trainer = _mapper.Map<TrainerCourse>(request.TrainerCourseDto);
                await _uow.TrainerCourseRepository.Add(trainer);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
            }

            return response;
        }
    }
}
