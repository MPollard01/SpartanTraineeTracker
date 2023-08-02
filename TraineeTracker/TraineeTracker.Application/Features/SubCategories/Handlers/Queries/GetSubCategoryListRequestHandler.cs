using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.SubCategory;
using TraineeTracker.Application.Features.SubCategories.Requests.Queries;

namespace TraineeTracker.Application.Features.SubCategories.Handlers.Queries
{
    public class GetSubCategoryListRequestHandler : IRequestHandler<GetSubCategoryListRequest, List<SubCategoryDto>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryListRequestHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<SubCategoryDto>> Handle(GetSubCategoryListRequest request, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategoryRepository.GetSubCategoriesByCategory(request.Category);
            return _mapper.Map<List<SubCategoryDto>>(subCategories);
        }
    }
}
