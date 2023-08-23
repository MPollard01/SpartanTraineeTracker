using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.SubCategory;
using TraineeTracker.Application.Features.SubCategories.Requests.Queries;

namespace TraineeTracker.Application.Features.SubCategories.Handlers.Queries
{
    public class GetSubCategoryDetailListRequestHandler : IRequestHandler<GetSubCategoryDetailListRequest, List<SubCategoryDetailDto>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryDetailListRequestHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<SubCategoryDetailDto>> Handle(GetSubCategoryDetailListRequest request, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategoryRepository.GetSubCategoriesWithCategory();
            return _mapper.Map<List<SubCategoryDetailDto>>(subCategories);
        }
    }
}
